using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Json
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.IO.StreamReader sr = new System.IO.StreamReader("json.txt");
            try
            {
                Dictionary<string, string> items =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                sr.Close();
                foreach (string s in items.Values)
                {
                    
                    MessageBox.Show(s);
                }
                items["name"] = "Robert";
                string newVersion = Newtonsoft.Json.JsonConvert.SerializeObject(items);
                System.IO.StreamWriter sw = new System.IO.StreamWriter("json.txt");
                sw.Write(newVersion);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
