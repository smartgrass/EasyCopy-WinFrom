using System;
using System.Windows.Forms;
using CCWin;

namespace EasyCopy
{
    public partial class InputForm : CCSkinMain
    {
        public InputForm()
        {
            InitializeComponent();
        }

        public int index = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //提交
        private void button1_Click(object sender, EventArgs e)
        {
            if(index>= Program.mainForm.listBox1.Items.Count || index == -1)
            {
                //新建
                if (!string.IsNullOrEmpty(textBox1.Text))
                    Program.mainForm.AddOne(textBox1.Text);
            }
            else
            {
                if(string.IsNullOrEmpty(textBox1.Text))
                {
                    Program.mainForm.RemoveOne(index);
                }
                else
                {
                    //修改
                    Program.mainForm.XiuGai(index, textBox1.Text);
                }
                
            }
            this.Close();
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            if (index >= Program.mainForm.listBox1.Items.Count || index == -1)
            {

            }
            else{
                Program.mainForm.RemoveOne(index);
            }
            this.Close();
        }


    }
}
