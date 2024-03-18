using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;

namespace EVE.Utils
{
    public static class Utils
    {
        public static void GetTypeJSON(Dictionary<int, Data.Type> typeList, int[] idList)
        {
            for(int i = 0; i < idList.Length; i++)
            {
                string typeJSON = NoHtml(GetJson("https://esi.evetech.net/latest/universe/types/" + idList[i] + "/?datasource=tranquility&language=zh"));

                byte[] buffer = Encoding.UTF8.GetBytes(typeJSON);
                string sResult = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                byte[] bomBuffer = new byte[] { 0xef, 0xbb, 0xbf };
                if (buffer[0] == bomBuffer[0] && buffer[1] == bomBuffer[1] && buffer[2] == bomBuffer[2])
                {
                    int copyLength = buffer.Length - 3;
                    byte[] dataNew = new byte[copyLength];
                    Buffer.BlockCopy(buffer, 3, dataNew, 0, copyLength);
                    sResult = System.Text.Encoding.UTF8.GetString(dataNew);
                }
                JObject jObject = JObject.Parse(sResult);
                Data.Type type = new Data.Type();
                if (jObject["capacity"] != null)        type.capacity = (float)jObject["capacity"];
                if (jObject["description"] != null)     type.description = (string)jObject["description"];
                if (jObject["group_id"] != null)        type.group_id = (int)jObject["group_id"];
                if (jObject["icon_id"] != null)         type.icon_id = (int)jObject["icon_id"];
                if (jObject["market_group_id"] != null) type.market_group_id = (int)jObject["market_group_id"];
                if (jObject["mass"] != null)            type.mass = (float)jObject["mass"];
                if (jObject["name"] != null)            type.name = (string)jObject["name"];
                if (jObject["packaged_volume"] != null) type.packaged_volume = (float)jObject["packaged_volume"];
                if (jObject["portion_size"] != null)    type.portion_size = (int)jObject["portion_size"];
                if (jObject["published"] != null)       type.published = (bool)jObject["published"];
                if (jObject["radius"] != null)          type.radius = (float)jObject["radius"];
                if (jObject["type_id"] != null)         type.id = (int)jObject["type_id"];
                if (jObject["volume"] != null)          type.volume = (float)jObject["volume"];
                typeList.Add(idList[i], type);
            }
        }
        public static string NoHtml(string html)
        {
            string StrNohtml = Regex.Replace(html, "<[^>]+>", "");
            StrNohtml = Regex.Replace(StrNohtml, "&[^;]+;", "");
            return StrNohtml;
        }
        public static int[] getIDList(int idListPage)
        {
            string str = GetJson("https://esi.evetech.net/latest/universe/types/?datasource=tranquility&page=" + 1);
            int[] idList = ResolveIDList(str);
            for (int i = 2; i <= idListPage; i++)
            {
                str = GetJson("https://esi.evetech.net/latest/universe/types/?datasource=tranquility&page=" + i);
                int[] a = ResolveIDList(str);
                idList = MergeArray(idList, a);
            }
            Array.Sort(idList);
            return idList;
        }
        public static int[] MergeArray(int[] a, int[] b)
        {
            int[] temp = new int[a.Length + b.Length];
            a.CopyTo(temp, 0);
            b.CopyTo(temp, a.Length);
            return temp;
        }
        public static int[] ResolveIDList(string s)
        {
            string a = s.Replace("[", "");
            string b = a.Replace("]", "");
            string[] sArray = b.Split(',');
            int[] ret = Array.ConvertAll(sArray, value => Convert.ToInt32(value));
            return ret;
        }
        public static string GetJson(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }
    }
}
