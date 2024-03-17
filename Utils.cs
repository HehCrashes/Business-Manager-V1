using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EVE.Utils
{
    public static class Utils
    {

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
        public static string GetHTMLByURL(string URL)
        {
            try
            {
                string pageHtml = "";
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                Byte[] pageData = MyWebClient.DownloadData(URL); //从指定网站下载数据
                MemoryStream ms = new MemoryStream(pageData);
                using (StreamReader sr = new StreamReader(ms, Encoding.GetEncoding("UTF-8")))
                {
                    pageHtml = sr.ReadLine();
                }
                return Regex.Unescape(pageHtml);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
