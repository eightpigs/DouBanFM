using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DesireFM
{
    public partial class frmLogin : Form
    {

        [DllImport("user32")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        //注册热键的api 
        [DllImport("user32")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312: //这个是window消息定义的 注册的热键消息 
                    if (m.WParam.ToString().Equals("88")) //如果是我们注册的那个热键 
                        this.Close();

                    break;
            }
            base.WndProc(ref m);
        }


        public frmLogin()
        {
            InitializeComponent();

            //注册关闭窗体热键
            RegisterHotKey(this.Handle, 88, 0, Keys.Escape);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "/SimpleFMconfig.cfg"))
                    File.WriteAllText(Application.StartupPath + "/SimpleFMconfig.cfg","");

                String[] loginInfo = File.ReadAllLines(Application.StartupPath + "/SimpleFMconfig.cfg");
                if (loginInfo.Length < 1)
                    return;
                txtUserName.Text = loginInfo[0];
                txtPassword.Text = loginInfo[1];
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            if (txtPassword.Text.Equals("") || txtUserName.Text.Equals(""))
                return;
            //this.Visible = false;
            UserEntity.email = txtUserName.Text;
            UserEntity.password = txtPassword.Text;
            JsonUtil.JsonToLogin(FMUtil.Login());

            //如果选中了 记住我  那么就把用户登录信息写入 app.config
            if (cbRemberMe.Checked)
            {
                try
                {
                    File.WriteAllText(Application.StartupPath + "/SimpleFMconfig.cfg",
                        txtUserName.Text + "\r\n" + txtPassword.Text);
                }
                catch (Exception)
                {
                }

            }
            this.Close();
        }

    }
}
