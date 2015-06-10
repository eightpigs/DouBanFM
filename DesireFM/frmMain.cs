using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WMPLib;
using Timer = System.Windows.Forms.Timer;

namespace DesireFM
{
    public partial class frmMain : Form
    {

        [DllImport("user32")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        //注册热键的api 
        [DllImport("user32")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //消息窗体(蒙板)
        private ShowMessage message = null;

        private Thread operationThread = null;

        //显示不同效果 Timer
        private Timer effectTimer= null;

        //供字体闪烁的颜色
        List<Color> colors = new List<Color>();
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312: //这个是window消息定义的 注册的热键消息 
                    if (m.WParam.ToString().Equals("88")) //如果是我们注册的那个热键 
                        Application.Exit();
                    else if (m.WParam.ToString().Equals("12"))
                    {
                        if (this.Visible)
                        {
                            this.Visible = false;
                            if (message != null) 
                                message.Visible = false;
                        }
                        else
                        {
                            this.Visible = true;
                            if (message != null) 
                                message.Visible = true;
                            
                        }
                    }
                    else if (m.WParam.ToString().Equals("78"))
                    {
                        operationThread = null;
                        operationThread = new Thread(new ThreadStart(ChangeMusic));
                        operationThread.IsBackground = true;
                        operationThread.Start();
                    }
                    else if (m.WParam.ToString().Equals("44"))
                    {
                        operationThread = null;
                        operationThread = new Thread(new ThreadStart(NoListen));
                        operationThread.IsBackground = true;
                        operationThread.Start();
                    }
                    else if (m.WParam.ToString().Equals("66"))
                    {
                        operationThread = null;
                        operationThread = new Thread(new ThreadStart(ReadAndBlack));
                        operationThread.IsBackground = true;
                        operationThread.Start();
                    }
                    else if (m.WParam.ToString().Equals("77"))
                    {
                        operationThread = null;
                        operationThread = new Thread(new ThreadStart(ShowHertzOrClover));
                        operationThread.IsBackground = true;
                        operationThread.Start();
                    }
                    else if (m.WParam.ToString().Equals("55"))
                    {
                        operationThread = null;
                        operationThread = new Thread(new ThreadStart(PauseMusic));
                        operationThread.IsBackground = true;
                        operationThread.Start();
                    }
                    else if (m.WParam.ToString().Equals("33"))
                    {
                        operationThread = null;
                        operationThread = new Thread(new ThreadStart(Login));
                        operationThread.IsBackground = true;
                        operationThread.Start();
                    }
                    else if (m.WParam.ToString().Equals("11"))
                    {
                        operationThread = null;
                        operationThread = new Thread(new ThreadStart(FMUtil.downOneSongStream));
                        operationThread.IsBackground = true;
                        operationThread.Start();
                    }
                    else if (m.WParam.ToString().Equals("10"))
                    {
                        UpVolume();
                    }
                    else if (m.WParam.ToString().Equals("19"))
                    {
                        DownVolume();
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 减小音量
        /// </summary>
        private void DownVolume()
        {
            wmpPlayer.settings.volume -= 5;
            VCVolume.Value = wmpPlayer.settings.volume;
        }

        /// <summary>
        /// 增大音量
        /// </summary>
        private void UpVolume()
        {
            wmpPlayer.settings.volume += 5;
            VCVolume.Value = wmpPlayer.settings.volume;
        }

        public frmMain()
        {
            InitializeComponent();
            System.Drawing.Icon icon = Icon.FromHandle(Properties.Resources.logo.GetHicon());
            this.Icon = icon;
            desireFM.Icon = icon;
            
        }


        /// <summary>
        /// 扫描所有磁盘,得到最大的磁盘,并在磁盘里面新建一个目录放下载的音乐
        /// </summary>
        private void getAllDriverAndCreateMusicFolder()
        {
            //得到所有磁盘
            DriveInfo[] driveInfos = DriveInfo.GetDrives();

            for (int i = 0; i < driveInfos.Length; i++)
            {
                for (int j = 0; j < driveInfos.Length; j++)
                {
                    try
                    {
                        if (driveInfos[i].TotalSize > driveInfos[j].TotalSize)
                    {
                        DriveInfo temp = driveInfos[i];
                        driveInfos[i] = driveInfos[j];
                        driveInfos[j] = temp;
                    }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            DirectoryInfo directory = new DirectoryInfo(driveInfos[0].Name);
            //是否存在
            bool exitis = false;
            foreach (var dir in directory.GetDirectories())
            {
                if (dir.Name.Equals("SimpleFM_Music"))
                {
                    exitis = true;
                    break; 
                }
            }

            //记录下载目录
            Global.downLoadPath = driveInfos[0].Name + "SimpleFM_Music";

            if (exitis)
                return;
            else
                Directory.CreateDirectory(Global.downLoadPath);


        }


        //控制进度条,音乐时间
        private Timer timer = new Timer();
        //记录歌曲的长度
        private int songLength = 0;
      
        public static Timer moveTimer = new Timer();

        private void frmMain_Load(object sender, EventArgs e)
        {

            //添加字体闪烁的颜色
            colors.Add(Color.Turquoise);
            colors.Add(Color.Teal);
            colors.Add(Color.SpringGreen);
            colors.Add(Color.Tomato);
            colors.Add(Color.Yellow);
            colors.Add(Color.Black);

            getAllDriverAndCreateMusicFolder();

            //注册关闭窗体热键
            RegisterHotKey(this.Handle, 88, 5, Keys.C);
            //注册显示或隐藏窗体热键
            RegisterHotKey(this.Handle, 12, 5, Keys.S);
            //注册切歌热键
            RegisterHotKey(this.Handle, 78, 5, Keys.N);
            //注册不再听热键
            RegisterHotKey(this.Handle, 44, 5, Keys.U);
            //注册加红心或取消红心热键
            RegisterHotKey(this.Handle, 66, 5, Keys.L);
            //注册显示赫兹列表热键
            RegisterHotKey(this.Handle, 77, 5, Keys.H);
            //注册暂停/播放歌曲热键
            RegisterHotKey(this.Handle, 55, 5, Keys.P);
            //注册打开登录界面热键
            RegisterHotKey(this.Handle, 33, 5, Keys.D);
            //注册下载当前播放热键
            RegisterHotKey(this.Handle, 11, 5, Keys.X);
            //注册增大音量热键
            RegisterHotKey(this.Handle, 10, 3, Keys.Up);
            //注册减小音量热键
            RegisterHotKey(this.Handle, 19, 3, Keys.Down);

            lblToggle.Visible = false;

            point = this.Location;
            getChannels();
            moveTimer.Interval = 1;
            moveTimer.Tick += moveTimer_Tick;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        #region 获取赫兹
        /// <summary>
        /// 获取赫兹
        /// </summary>
        private void getChannels()
        {
            JsonUtil.JsonToChances(FMUtil.getChances());
            ;

            int btnWidth = 60;
            int btnHeight = 24;

            int n = 4;
            int m = Global.Channels.Count / n;

            int index = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Label label = new Label();
                    label.Text = Global.Channels[index].name;
                    label.Name = "lbl" + Global.Channels[index].channel_id;
                    label.Width = btnWidth;
                    label.Tag = new Point(i, j);
                    label.Location = new Point(j * btnWidth, i * btnHeight + 5);
                    if (index < 4)
                    {
                        label.Top = 5;
                        //label.Location = new Point(j * btnWidth, i * btnHeight+5);
                    }
                    label.Click += label_Click;
                    panelChance.Controls.Add(label);
                    index++;
                }
            }

        }
        #endregion


        /// <summary>
        /// 赫兹ID
        /// </summary>
        private int ClannelId = 0;

        /// <summary>
        /// 播放获取到集合的第几首歌曲
        /// </summary>
        public static int SongListIndex = 0;



        #region 点击赫兹名字的事件
        /// <summary>
        /// 点击赫兹的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void label_Click(object sender, EventArgs e)
        {
            try
            {
                string name = ((Label)sender).Name;
                ClannelId = int.Parse(name.Substring(3, name.Length - 3));
                JsonUtil.JsonToSongs(FMUtil.getSongs(ClannelId, "n", null));
                pbICover.Width = 250;
                lblToggle.Text = "<";
                lblToggle.Location = new Point(236, 235);
                panelChance.Visible = false;
                PlayMusic();
            }
            catch (Exception)
            {
            }
        }
        #endregion

       
        
        #region 播放音乐

        private void PlayMusic()
        {
            try
            {
                wmpPlayer.URL = Global.Songs[SongListIndex].url;
            pbICover.Image = Image.FromStream(FMUtil.downStream(Global.Songs[SongListIndex].picture));
            lblAlbum.Text = Global.Songs[SongListIndex].albumtitle;
            lblSinger.Text = Global.Songs[SongListIndex].artist;
            lblSong.Text = Global.Songs[SongListIndex].title;
            //用一个变量记录歌曲的长度,因为后面倒计时会导致长度改变
            songLength = Global.Songs[SongListIndex].length;

            if (Global.Songs[SongListIndex].like == 1)
                pbRed.Image = Properties.Resources.like;
            else
                pbRed.Image = Properties.Resources.unlike;

            timer.Enabled = true;

            PBSongProgress.Maximum = Global.Songs[SongListIndex].length;
            
            wmpPlayer.Enabled = true;

            if (SongListIndex == 4)
            {
                SongListIndex = 0;
                JsonUtil.JsonToSongs(FMUtil.getSongs(ClannelId, "n", null));
            }
            }
            catch (Exception)
            {
            }
        }


        private string minutes;
        private string seconds;
        /// <summary>
        /// 让窗体上的时间和进度条产生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Global.Songs[SongListIndex].length -= 1;
                minutes = (Global.Songs[SongListIndex].length / 60).ToString();

                seconds = (Global.Songs[SongListIndex].length % 60).ToString();
                if (minutes.Length == 1)
                    minutes = "0" + minutes;
                if (seconds.Length == 1)
                    seconds = "0" + seconds;

                lblTime.Text = minutes + ":" + seconds;

                if (PBSongProgress.Value == songLength)
                {
                    ChangeMusic();
                    timer = null;
                }
                PBSongProgress.Value++;
            }
            catch (Exception)
            {
            }
        }

        #endregion


        #region  鼠标拖动窗体

        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y); //设置移动后的位置
                Location = mouseSet;
                //每次拖动窗体都给point赋值.当消息窗体显示时可以准确显示在主窗体上面
                point = mouseSet;
            }

            //得到鼠标相对控件的坐标.如果鼠标移出音量控制控件外面就隐藏
            if (PbShowVolumeControl.PointToClient(Control.MousePosition).X > 70 || PBSongProgress.PointToClient(Control.MousePosition).Y > 2 || PBSongProgress.PointToClient(Control.MousePosition).Y < 2)
            {
                VCVolume.Visible = false;
                lblTime.Visible = true;
                PbShowVolumeControl.Location = new Point(492, 141);
            }
            else
            {
                VCVolume.Visible = true;
                lblTime.Visible = false;
                PbShowVolumeControl.Location = new Point(425, 141);
            }
        }

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion


        #region 点击用户名/登录事件
        /// <summary>
        /// 登录或查看用户信息
        ///     如果未登录则执行登录操作
        ///     用户登录后可以查看用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblUserName_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            //没有登录
            if (UserEntity.userName == null)
            {
                new DesireFM.frmLogin().ShowDialog();
                if (UserEntity.userName == null)
                    lblUserName.Text = "登录";
                else
                    lblUserName.Text = UserEntity.userName;
            }
        }
        #endregion


        #region 显示专辑封面或者显示赫兹列表
        private void lblToggle_Click(object sender, EventArgs e)
        {
            ShowHertzOrClover();
        }

        private void ShowHertzOrClover()
        {
            if (lblToggle.Text.Equals(">"))
            {
                pbICover.Width = 250;
                lblToggle.Text = "<";
                lblToggle.Location = new Point(236, 235);
                panelChance.Visible = false;
            }
            else
            {
                pbICover.Width = 1;
                lblToggle.Text = ">";
                lblToggle.Location = new Point(2, 235);
                panelChance.Visible = true;
            }
        }
        #endregion


        #region 切歌事件
        /// <summary>
        /// 切歌事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbNext_Click(object sender, EventArgs e)
        {
            ChangeMusic();
        }
        #endregion


        #region 执行切歌的方法
        /// <summary>
        /// 切歌
        /// </summary>
        private void ChangeMusic()
        {
            try
            {
                //切歌之后把tag改为black.
                pbRed.Tag = "black";

                if (Global.Songs == null)
                    return;
                PBSongProgress.Value = 0;
                lblTime.Text = "";

                if (SongListIndex == 4)
                {
                    PlayMusic();
                    return;
                }

                SongListIndex++;
                PlayMusic();
            }
            catch (Exception)
            {
            }
        }
        #endregion


        #region 不再听这首歌事件
        /// <summary>
        /// 不再听这首歌事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbNo_Click(object sender, EventArgs e)
        {
            NoListen();
        }


        private void NoListen()
        {
            check("登录后才能实现不再听当前音乐");
            if (UserEntity.userName == null)
            {
                ChangeMusic();
                return;
            }
            FMUtil.getSongs(ClannelId, "b", Global.Songs[SongListIndex].sid);
            pbNo.Image = Properties.Resources.delete; 
            ChangeMusic();
        }
        #endregion


        #region 加红心或取消红心
        /// <summary>
        /// 添加红心或取消红心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbRed_Click(object sender, EventArgs e)
        {
            ReadAndBlack();
        }



        private int colorIndex = 0;

        private void check(String text)
        {
            effectTimer = null;
            if (UserEntity.userName == null)
            {
                lblTip.Text = "Tips : "+text;
                lblTip.Visible = true;
                effectTimer = new Timer();
                effectTimer.Interval = 500;
                effectTimer.Tick += effectTimer_Tick;
                colorIndex = 0;
                effectTimer.Start();
                return;
            }
        }

        private void ReadAndBlack()
        {

            check("登录后才能执行此操作");

            if (wmpPlayer.playState == WMPPlayState.wmppsPaused || wmpPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                if (pbRed.Tag.ToString().Equals("black"))
                {
                    FMUtil.getSongs(ClannelId, "r", Global.Songs[SongListIndex].sid);
                    pbRed.Image = Properties.Resources.like;
                    pbRed.Tag = "red";
                }
                else
                {
                    FMUtil.getSongs(ClannelId, "u", Global.Songs[SongListIndex].sid);
                    pbRed.Image = Properties.Resources.unlike; 
                    pbRed.Tag = "black";
                }
            }
        }


        void effectTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (colorIndex == colors.Count && effectTimer != null)
                {
                    effectTimer.Stop();
                    effectTimer = null;
                    lblTip.Visible = false;
                    return;
                }
                lblTip.ForeColor = colors[colorIndex];
                colorIndex++;
            }
            catch (Exception)
            {
            }
        }

        #endregion


        #region 暂停或播放
        /// <summary>
        /// 如果播放则暂停,反之...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbPause_Click(object sender, EventArgs e)
        {
         
            PauseMusic();
        }

        private void PauseMusic()
        {
            if (message != null)
                return;
            try
            {
                if (wmpPlayer.playState == WMPPlayState.wmppsPaused)
                {
                    wmpPlayer.Ctlcontrols.play();
                    if (message.Visible == true)
                    {
                        message.Visible = false;
                        message = null;
                    }
                }
                else if (wmpPlayer.playState == WMPPlayState.wmppsPlaying)
                {
                    wmpPlayer.Ctlcontrols.pause();
                    message = new ShowMessage();
                    message.Width = this.Width;
                    message.Height = this.Height;
                    message.Location = this.Location;
                    Label label = new Label();
                    label.Text = "点击继续";
                    label.Width = 160;
                    label.Height = 50;
                    label.Font = new Font("Segoe UI", 20);
                    label.Location = new Point(this.Width / 2 - 60, this.Height / 2 - 30);
                    label.Click += messageLabel_Click;
                    message.Controls.Add(label);
                    //message.ShowDialog();
                    message.Visible = this.Visible;
                }
            }
            catch (Exception)
            {
            }
        }

        private void messageLabel_Click(object sender, EventArgs e)
        {
            ((Form)(((Label)sender).Parent)).Close();
            message = null;
            wmpPlayer.Ctlcontrols.play();
        }

        #endregion


        #region 定时获取消息窗体的位置.让主窗体跟随移动
        public static Point point = new Point();
        void moveTimer_Tick(object sender, EventArgs e)
        {
            this.Location = point;
        }
        #endregion

        private void lblSong_Click(object sender, EventArgs e)
        {
            try
            {
                FMUtil.GetRedHreats();
            }
            catch (Exception)
            {
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                UnregisterHotKey(this.Handle, 88);
                UnregisterHotKey(this.Handle, 12);
            }
            catch (Exception)
            {
            }

        }

        private void VCVolume_Scroll(object sender, EventArgs e)
        {
            wmpPlayer.settings.volume = VCVolume.Value;
        }

        /// <summary>
        /// 鼠标移动到喇叭上显示音量控制控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbShowVolumeControl_MouseEnter(object sender, EventArgs e)
        {
            VCVolume.Visible = true;
            lblTime.Visible = false;
            PbShowVolumeControl.Location = new Point(425, 141);
        }

        private void pbICover_DoubleClick(object sender, EventArgs e)
        {
            ShowHertzOrClover();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {


            if (message != null)
            {
                message.Visible = false;
                message.Visible = true;

            }
        }

        private void desireFM_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }
    }

}

