using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCopy
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new CCWin.SkinControl.SkinButton();
            this.button3 = new CCWin.SkinControl.SkinButton();
            this.button1 = new CCWin.SkinControl.SkinButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button4 = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.tabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.listBox1 = new CCWin.SkinControl.SkinListBox();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button2.DownBack = null;
            this.button2.Font = new System.Drawing.Font("宋体", 10F);
            this.button2.Location = new System.Drawing.Point(43, 543);
            this.button2.MouseBack = null;
            this.button2.Name = "button2";
            this.button2.NormlBack = null;
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "↑";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnMoveUpBtn);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button3.DownBack = null;
            this.button3.Font = new System.Drawing.Font("宋体", 10F);
            this.button3.Location = new System.Drawing.Point(76, 543);
            this.button3.MouseBack = null;
            this.button3.Name = "button3";
            this.button3.NormlBack = null;
            this.button3.Size = new System.Drawing.Size(27, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "↓";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnMoveDownBtn);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button1.DownBack = null;
            this.button1.Font = new System.Drawing.Font("宋体", 13F);
            this.button1.Location = new System.Drawing.Point(10, 543);
            this.button1.MouseBack = null;
            this.button1.Name = "button1";
            this.button1.NormlBack = null;
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnAddBtn);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Easy Copy";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button4.DownBack = null;
            this.button4.Font = new System.Drawing.Font("宋体", 10F);
            this.button4.Location = new System.Drawing.Point(109, 543);
            this.button4.MouseBack = null;
            this.button4.Name = "button4";
            this.button4.NormlBack = null;
            this.button4.Size = new System.Drawing.Size(27, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "×";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnDeletePageBtn);
            // 
            // skinButton1
            // 
            this.skinButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Font = new System.Drawing.Font("宋体", 10F);
            this.skinButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.skinButton1.Image = global::EasyCopy.Properties.Resources._3_1_设置;
            this.skinButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.skinButton1.Location = new System.Drawing.Point(291, 542);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinButton1.Size = new System.Drawing.Size(29, 23);
            this.skinButton1.TabIndex = 8;
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.tabControl1.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(20)));
            this.tabControl1.HeadBack = null;
            this.tabControl1.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.tabControl1.ItemSize = new System.Drawing.Size(55, 26);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(1, 3);
            this.tabControl1.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageArrowDown")));
            this.tabControl1.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageArrowHover")));
            this.tabControl1.PageBaseColor = System.Drawing.Color.Gray;
            this.tabControl1.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageCloseHover")));
            this.tabControl1.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageCloseNormal")));
            this.tabControl1.PageDown = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageDown")));
            this.tabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("tabControl1.PageHover")));
            this.tabControl1.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.tabControl1.PageNorml = null;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(335, 512);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.OnSwitchPage);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(0, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(335, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.TabItemImage = null;
            // 
            // listBox1
            // 
            this.listBox1.Back = null;
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(200)));
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ImagePoint = false;
            this.listBox1.ImageVisble = false;
            this.listBox1.ItemHeight = 40;
            this.listBox1.ItemHoverGlassVisble = true;
            this.listBox1.ItemImageLayout = false;
            this.listBox1.ItemRadius = 20;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.MouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(130)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.listBox1.Name = "listBox1";
            this.listBox1.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(130)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.listBox1.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(130)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.listBox1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(130)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.listBox1.Size = new System.Drawing.Size(329, 480);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnListDoubleClick);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnListBoxMouseDown);
            // 
            // skinButton2
            // 
            this.skinButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Font = new System.Drawing.Font("宋体", 10F);
            this.skinButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.skinButton2.Image = global::EasyCopy.Properties.Resources.刷新;
            this.skinButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.skinButton2.Location = new System.Drawing.Point(256, 542);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinButton2.Size = new System.Drawing.Size(29, 23);
            this.skinButton2.TabIndex = 9;
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(338, 573);
            this.Controls.Add(this.skinButton2);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.949999988079071D;
            this.ShowInTaskbar = false;
            this.Text = "EasyCopy";
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }







        #endregion

        public List<TabPage> tabs = new List<TabPage>();
        private NotifyIcon notifyIcon1;
        private CCWin.SkinControl.SkinButton button2;
        private CCWin.SkinControl.SkinButton button3;
        private CCWin.SkinControl.SkinButton button1;
        public CCWin.SkinControl.SkinTabControl tabControl1;
        private CCWin.SkinControl.SkinTabPage tabPage1;
        private CCWin.SkinControl.SkinButton button4;
        public CCWin.SkinControl.SkinListBox listBox1;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinButton skinButton2;
    }
}

