using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            idList = getIDList(ID_LIST_PAGE);
            Dictionary<int, Data.Type> typeList = new Dictionary<int, Data.Type>();
            GetTypeJSON(typeList, idList);
            /* TODO :
             * idList => typeList
             * 仓库管理
             * 角色管理
             * 加载条
            */



            //Text1.Text = 
        }
    }
}