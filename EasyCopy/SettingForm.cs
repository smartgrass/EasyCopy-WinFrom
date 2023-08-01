using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCopy
{
    public partial class SettingForm : CCSkinMain
    {


        public SettingForm()
        {
            InitializeComponent();
            //读取配置 , 逗号分割
            ReadTitle();
            ReadOther();
        }

        private void OnSavaBtn(object sender, EventArgs e)
        {
            WriteTitle();
            bool isSava = SavaOther();
            Close();

            if (isSava)
            {
                Program.mainForm.RefreshPage();

                Program.mainForm.ReSetTitle();

                Program.mainForm.SetFont();
            }
        }


        private void ReadTitle()
        {
            string nameStr = "";
            for (int i = 0; i < Program.pageCount; i++)
            {
                nameStr += ConfigurationManager.AppSettings["tabName" + (i + 1)];
                if (i < Program.pageCount - 1)
                {
                    nameStr += ",";
                }
            }
            textBox1.Text = nameStr;
        }
        private void WriteTitle()
        {
            string inputStr = textBox1.Text;

            string[] list = inputStr.Split(',');

            if (list.Length <0) {
                return;
            }

            int len = list.Length;


            for (int i = 0;i < len;i++)
            {
                Tools.AddUpdateAppSettings("tabName" + (i + 1), list[i]);
            }
        }

        private bool SavaOther()
        {
            try
            {
                int textSize = (int)float.Parse(textBox2.Text);
                int ItemHeight = (int)float.Parse(textBox3.Text);


                Tools.AddUpdateAppSettings("textSize",textSize.ToString());
                Tools.AddUpdateAppSettings("ItemHeight", ItemHeight.ToString());

                string colorStr = ColorTranslator.ToHtml(button2.BackColor);
                Tools.AddUpdateAppSettings("textColor", colorStr);
                return true;

            }
            catch (Exception)
            {
                MessageBox.Show("保存失败");
                return false;
            }

        }        
        private void ReadOther()
        {
            int textSize = int.Parse(Tools.GetAppSettings("textSize"));
            int ItemHeight = int.Parse(Tools.GetAppSettings("ItemHeight"));

            textBox2.Text = textSize.ToString();
            textBox3.Text = ItemHeight.ToString();

            string colorStr = ConfigurationManager.AppSettings["textColor"];
            button2.BackColor = ColorTranslator.FromHtml(colorStr);

        }


        private void button2_Click(object sender, EventArgs e)
        {

            ColorDialog dialog = new ColorDialog();
            DialogResult result = dialog.ShowDialog();//打开颜色选择器
            if (result == DialogResult.OK)
            {      
                button2.BackColor = dialog.Color;
            }

            
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string v_OpenFolderPath = @"Icon";
            System.Diagnostics.Process.Start("explorer.exe", v_OpenFolderPath);
        }
    }
}
