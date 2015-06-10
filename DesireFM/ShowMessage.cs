using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesireFM
{
    public partial class ShowMessage : Form
    {

        /// <summary>
        /// 实现窗体不显示在Alt+Tab列表
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                //cp.ExStyle &= (~WS_EX_APPWINDOW); // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW; // 不显示在Alt-Tab
                return cp;
            }
        }


        public ShowMessage()
        {
            InitializeComponent();
        }


        #region  鼠标拖动窗体

        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键

        private void showMessage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void showMessage_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
                frmMain.point = mouseSet;
                frmMain.moveTimer.Enabled = true;
            }
        }

        private void showMessage_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion


        /// <summary>
        /// 关闭窗体时关闭检测消息窗体移动的定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.moveTimer.Enabled = false;
        }

        /// <summary>
        /// 窗体启动设置显示位置和主窗体一直.用作蒙板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessage_Load(object sender, EventArgs e)
        {
            this.Location = frmMain.point;
        }
    }
}
