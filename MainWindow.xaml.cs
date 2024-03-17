using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static EVE.Utils.Utils;

namespace EVE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //int list
    public partial class MainWindow : Window
    {
        public const int ID_LIST_PAGE = 48;
        int[]? idList;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            idList = MainUtils.Func.getIDList();
            Dictionary<int, Type> typeList = new Dictionary<int, Type>();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /* TODO :
             * idList => typeList
             * 仓库管理
             * 角色管理
             * 加载条
            */



            //Text1.Text = Regex.Unescape(GetHTMLByURL("https://esi.evetech.net/latest/universe/types/"+TextBox1.Text+"/?datasource=tranquility&language=zh"));
        }
    }
}
namespace EVE.MainUtils
{
    public static class Func
    {
        public static int[] getIDList()
        {
            string str = GetHTMLByURL("https://esi.evetech.net/latest/universe/types/?datasource=tranquility&page=" + 1);
            int[] idList = ResolveIDList(str);
            for (int i = 2; i < MainWindow.ID_LIST_PAGE; i++)
            {
                str = GetHTMLByURL("https://esi.evetech.net/latest/universe/types/?datasource=tranquility&page=" + i);
                int[] a = ResolveIDList(str);
                idList = MergeArray(idList, a);
            }
            Array.Sort(idList);
            return idList;
        }
    }
}
