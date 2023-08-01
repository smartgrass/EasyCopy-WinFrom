using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using static EasyCopy.Program;
using System.Configuration;
using System.Diagnostics;
using CCWin;
using System.Collections.Generic;
using System.IO;

namespace EasyCopy
{
    public partial class Form1 : CCSkinMain
    {
        public const int SHOW = 0x004A;
        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_RESTORE = 0xF120;
        public Color textColor = Color.Black;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Console.WriteLine("OnLoad");

            SetBgList();
            SetFont();
        }
        public Form1()
        {
            Console.WriteLine("yns  InitializeComponent");
            InitializeComponent();
            tabs.Add(tabPage1); //Form自带一个页
            tabPage1.Text = ConfigurationManager.AppSettings["tabName1"];
            //注意 i是从1开始
            for (int i = 1; i < pageCount; i++)
            {
                CreatNewPage(i);
            }
            this.TopMost = true;
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width - 10;
            int y = 150;
            Point p = new Point(x, y);
            this.PointToScreen(p);
            this.Location = p;
            Width = int.Parse(ConfigurationManager.AppSettings["Width"]);
            Height = int.Parse(ConfigurationManager.AppSettings["Height"]);

            //this.Opacity = 0.8;
            //Process currentProcess = Process.GetCurrentProcess();
        }

        private void CreatNewPage(int i)
        {
            var tabPage = new CCWin.SkinControl.SkinTabPage();
            tabs.Add(tabPage);
            SetPageLayout(tabPage);
            tabControl1.Controls.Add(tabPage);
            tabPage.Text = ConfigurationManager.AppSettings["tabName" + (i + 1)];
        }

        private void SetPageLayout(CCWin.SkinControl.SkinTabPage tabPage)
        {
            // 复制第一页的数据
            tabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            tabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            tabPage.Location = new System.Drawing.Point(0, 26);
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(335, 486);
        }
        //接收Message
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Note.WM_COPYDATA)
            {
                string s = ((Note.CopyData)Marshal.PtrToStructure(m.LParam, typeof(Note.CopyData))).lpData;
                //Console.WriteLine("Show!"+ s);
                this.Visible = true;
            }
            else
                base.WndProc(ref m);
        }

        public void OpenInputForm(CCSkinMain form)
        {
            form.Shown += new EventHandler((Object obj, EventArgs e2) =>
            {
                TopMost = false;
                form.TopMost = true;
            });

            form.FormClosed += new FormClosedEventHandler((Object obj, FormClosedEventArgs e3) =>
            {
                TopMost = true;
                //form.TopMost =  false;

            });
            form.ShowDialog();
        }

        //双击修改
        void OnListDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            InputForm form = new InputForm();
            form.index = index;
            if (index >= Program.mainForm.listBox1.Items.Count || index == -1)
            {
                //新建
            }
            else
            {
                form.SetStr(curDataLists[CurPage][index].text);
            }
            OpenInputForm(form);

        }
        //ListBox点击事件点击事件
        private void OnListBoxMouseDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("OnListBoxMouseDown " + e.Button);
            //左键复制
            if (e.Button == MouseButtons.Left)
            {
                int index = this.listBox1.IndexFromPoint(e.Location);
                //Console.WriteLine("yns index " + index);
                if (index >= listBox1.Items.Count)
                    return;
                Clipboard.SetDataObject(curDataLists[CurPage][index].text, true);
            }
            //右键添加
            else if (e.Button == MouseButtons.Right)
            {
                //Console.WriteLine("add !!");
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.UnicodeText))
                {
                    //UnicodeText
                    string s = (string)iData.GetData(DataFormats.UnicodeText);
                    AddOne(s);
                }
            }
        }
        public void RefreshPage()
        {
            ReadPage(CurPage);
        }
        public void ReSetTitle()
        {
            int length = tabs.Count;
            for (int i = 0; i < length; i++)
            {
                var tab = tabs[i];
                tab.Text = ConfigurationManager.AppSettings["tabName" + (i + 1)];
            }
        }        
        
        public void SetFont()
        {
            //Color
            string colorStr = ConfigurationManager.AppSettings["textColor"];
            listBox1.ForeColor = ColorTranslator.FromHtml(colorStr);

            //itemHeight
            int itemHeight = int.Parse(ConfigurationManager.AppSettings["ItemHeight"]);
            listBox1.ItemHeight = itemHeight;

            //textSize
            string tsStr = ConfigurationManager.AppSettings["textSize"];
            float textSize = float.Parse(tsStr);
            listBox1.Font = new Font("微软雅黑", textSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(200)));
        }


        public void AddOne(string s)
        {
            curDataLists[CurPage].Add(new ItemData(isHidePage(CurPage), s));
            listBox1.Items.Add(new CCWin.SkinControl.SkinListBoxItem(s));
            Program.Sava();
        }
        public void RemoveOne(int index)
        {
            mainForm.listBox1.Items.RemoveAt(index);
            curDataLists[CurPage].RemoveAt(index);
            Sava();
        }

        public void XiuGai(int index, string s)
        {
            curDataLists[CurPage][index].SetText(s);
            Sava();
            RefreshPage();
        }

        //添加
        private void OnAddBtn(object sender, EventArgs e)
        {
            int index = -1;
            InputForm form = new InputForm();
            form.index = index;

            OpenInputForm(form);
        }
        //上移
        public void OnMoveUpBtn(object sender, EventArgs e)
        {
            int index = this.listBox1.SelectedIndex;
            if (index >= Program.mainForm.listBox1.Items.Count || index == -1)
            {
                //
            }
            else
            {
                if (index != 0)
                {
                    Swap(curDataLists[CurPage], index, index - 1);
                    Sava();
                    RefreshPage();
                    listBox1.SelectedIndex = index - 1;
                }
            }
        }
        //下移
        private void OnMoveDownBtn(object sender, EventArgs e)
        {
            int index = this.listBox1.SelectedIndex;
            if (index >= Program.mainForm.listBox1.Items.Count || index == -1)
            {
                //
            }
            else
            {
                if (index != Program.mainForm.listBox1.Items.Count - 1)
                {
                    var tempD = curDataLists[CurPage][index];
                    Swap(curDataLists[CurPage], index, index + 1);
                    Sava();
                    RefreshPage();
                    listBox1.SelectedIndex = index + 1;

                }
            }
        }

        private void OnDeletePageBtn(object sender, MouseEventArgs e)
        {
            //
            if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show("" + tabControl1.SelectedIndex);
                //消息
                var res = MessageBox.Show("是否删除整个页面", "删除", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    listBox1.Items.Clear();
                    curDataLists[CurPage].Clear();
                    Sava();
                }
                else
                {
                    return;
                }
            }
            else
            {
                //直接删除
                listBox1.Items.Clear();
                curDataLists[CurPage].Clear();
                Sava();
            }
        }


        private void Swap(List<ItemData> list, int a, int b)
        {
            var temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }


        //切换页面
        private void OnSwitchPage(object sender, EventArgs e)
        {
            RefreshPage();
            tabs[CurPage].Controls.Add(this.listBox1);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                //thiIcon1.Visible = true;
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    this.WindowState = FormWindowState.Minimized;
            //    this.Hide();

            //}
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    //this.Show();
            //    //this.Activate();
            //    this.WindowState = FormWindowState.Normal;
            //    this.Activate();
            //}

        }


        private void skinButton2_Click(object sender, EventArgs e)
        {
            SetBgList();
        }

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            Console.WriteLine(WindowState);
            if (e.Button == MouseButtons.Left)
            {
                if (!this.Visible)
                {
                    SetBgList();
                    this.Visible = true;
                }
                else
                {
                    this.Visible = false;
                }

                Console.WriteLine(CurPage);

            }
            else
            {
                this.Close();
            }

            //this.notifyIcon1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void skinToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {

            SettingForm form = new SettingForm();

            //form.SetStr(curDataLists[CurPage][index].text);
            
            OpenInputForm(form);
        }


        private void SetBgList()
        {

            string[] filenames = Directory.GetFiles("Icon");
            filenames = Array.FindAll(filenames, f => (f.EndsWith(".png")||f.EndsWith(".jpg")));

            foreach (var item in filenames)
            {
                Console.WriteLine(item);
            }

            if (filenames.Length > 0)
            {
                int seek = unchecked((int)DateTime.Now.Ticks);
                int index = new Random(seek).Next(0, filenames.Length);
                var f = new FileInfo(filenames[index]);
                Console.WriteLine(f.FullName);
                var image = Image.FromFile(f.FullName);
                listBox1.Back = image;
            }
            else
            {
                listBox1.Back = null;
            }

        }
    }
}
