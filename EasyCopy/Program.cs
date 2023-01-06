using System;
using System.Windows.Forms;
using LitJson;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

namespace EasyCopy
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        public static Form1 mainForm;
        public static string FilePath = "data.json";
        public static List<List<ItemData>> curDataLists = new List<List<ItemData>>();
        public static bool[] isHideArray;
        public static int CurPage { get => mainForm.tabControl1.SelectedIndex; }

        public static int pageCount = 2;
        public const int SHOW = 0x004A;

        ////弃用
        //[DllImport("User32.dll")]
        //private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        //[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        //public static extern int SetForegroundWindow(IntPtr hwnd);
        //[DllImport("user32.dll", EntryPoint = "SendMessage")]
        //public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_RESTORE = 0xF120;



        [STAThread]
        static void Main()
        {
            Process cur = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id == cur.Id) continue;
                if (p.ProcessName == cur.ProcessName)
                {

                    Note.SendMsg("123");
                    
                    System.Environment.Exit(0);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            pageCount = int.Parse(ConfigurationSettings.AppSettings["pageCount"]);
            ReadHideArray();
            mainForm = new Form1();
            FirstLoad();
            //Process.GetCurrentProcess().MainWindowHandle
            Application.Run(mainForm);//同步

        }


        private static void ReadHideArray()
        {
            var hideArray = (ConfigurationSettings.AppSettings["Hide"]).Split(",".ToCharArray());
            //Console.WriteLine("pageCount " + pageCount);
            isHideArray = new bool[pageCount];

            foreach (var item in hideArray)
            {
                int i = int.Parse(item);
                if (i >= isHideArray.Length)
                    i = isHideArray.Length - 1;
                //Console.WriteLine(" " + i + " "+ isHideArray.Length);
                isHideArray[i] = true;
            }
        }
        public static bool isHidePage(int i)
        {
            return isHideArray[i];
        }


        public class ItemData
        {
            public ItemData() { }

            public ItemData(bool isHide , string str)
            {
                this.isHide = isHide;
                SetText(str);
            }
            public string text;
            private string hideText;
            public bool isHide;
            public void SetText(string t)
            {
                text = t;
                if (isHide)
                {
                    if(t.Length > 5)
                        hideText = t.Substring(0, 5) + "...";
                    else
                        hideText = "...";
                }
            }
            public string showTex { get
                {
                    return isHide ? hideText : text;
                }
            }
        }

        public class SavaData
        {
            public List<List<string>> strListList = new List<List<string>>();
        }

        //需要封装号 获取数据 和 假数据

        static SavaData GetSava()
        {
            SavaData data = new SavaData();
            data.strListList = new List<List<string>>();
            int i = 0;
            foreach (var dataList in curDataLists)
            {
                data.strListList.Add(new List<string>());
                foreach (var item in dataList)
                {
                    data.strListList[i].Add(item.text);
                }
                i++;
            }

            return data;
        }


        //只有发生删除 添加 修改时 才会保存 , 并且只保存当前页面
        public static void Sava()
        {
            SavaData data = GetSava();
            string str = JsonMapper.ToJson(data);

            StreamWriter sw = new StreamWriter(FilePath, false, Encoding.Default);
            sw.Write(str);  //这里是写入的内容             
            sw.Flush();
            sw.Close();

        }

        public static void InitItemData(SavaData savaData)
        {
            curDataLists = new List<List<ItemData>>();
            int i = 0;
            //Console.WriteLine("savaData.strListList) " + savaData.strListList.Count);
            foreach (var stringList in savaData.strListList)
            {
                if(i >= pageCount)
                {
                    Console.WriteLine("Max pageCount");
                    continue;
                }
                curDataLists.Add(new List<ItemData>());
                bool isHide = isHidePage(i);
                foreach (var str in stringList)
                {
                    var itemData = new ItemData();
                    itemData.isHide = isHide;
                    itemData.SetText(str);
                    curDataLists[i].Add(itemData);
                }
                i++;
            }
        }

        public static void FirstLoad()
        {
            if (!File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(fs);
                SavaData currenrtData = new SavaData();
                for (int i = 0; i < pageCount; i++)
                {
                    currenrtData.strListList.Add(new List<string>());
                }
                InitItemData(currenrtData);
                string str = JsonMapper.ToJson(currenrtData);
                sw.Write(str);  //这里是写入的内容             
                //sw.Flush();
                sw.Close();
                fs.Close();
                MessageBox.Show("新建存档");
                //mainForml.listBox1.Items.Clear();
            }
            else
            {
                //读取文本
                StreamReader sr = File.OpenText(FilePath);
                string input = sr.ReadToEnd();
                SavaData data = JsonMapper.ToObject<SavaData>(input);
                InitItemData(data);
                sr.Close();
                mainForm.listBox1.Items.Clear();
                //读取第一页
                ReadPage(0);
            }
        }

        public static void ReadPage(int index)
        {
            if(curDataLists.Count > 0)
            {
                while(curDataLists.Count <= pageCount)
                {
                    curDataLists.Add(new List<ItemData>());
                }
                var strList = curDataLists[index];

                mainForm.listBox1.Items.Clear();
                foreach (var item in strList)
                {
                    mainForm.listBox1.Items.Add( new CCWin.SkinControl.SkinListBoxItem( item.showTex));
                }
            }
            else
            {
                //MessageBox.Show("空");
            }


        }



    }
}
