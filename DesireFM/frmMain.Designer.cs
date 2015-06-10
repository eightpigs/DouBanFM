namespace DesireFM
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblSinger = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblSong = new System.Windows.Forms.Label();
            this.PBSongProgress = new System.Windows.Forms.ProgressBar();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblToggle = new System.Windows.Forms.Label();
            this.panelChance = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.desireFM = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbNo = new System.Windows.Forms.PictureBox();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.pbRed = new System.Windows.Forms.PictureBox();
            this.pbICover = new System.Windows.Forms.PictureBox();
            this.PbShowVolumeControl = new System.Windows.Forms.PictureBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.trpControl = new DesireFM.TransparentPanel();
            this.VCVolume = new DesireFM.VolumeControl();
            this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbICover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShowVolumeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSinger
            // 
            this.lblSinger.AutoSize = true;
            this.lblSinger.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinger.Location = new System.Drawing.Point(271, 39);
            this.lblSinger.Name = "lblSinger";
            this.lblSinger.Size = new System.Drawing.Size(52, 25);
            this.lblSinger.TabIndex = 1;
            this.lblSinger.Text = "歌手";
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbum.Location = new System.Drawing.Point(273, 75);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(56, 17);
            this.lblAlbum.TabIndex = 2;
            this.lblAlbum.Text = "专辑名";
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSong.Location = new System.Drawing.Point(276, 113);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(56, 17);
            this.lblSong.TabIndex = 3;
            this.lblSong.Text = "歌曲名";
            this.lblSong.Click += new System.EventHandler(this.lblSong_Click);
            // 
            // PBSongProgress
            // 
            this.PBSongProgress.BackColor = System.Drawing.Color.White;
            this.PBSongProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBSongProgress.Location = new System.Drawing.Point(276, 136);
            this.PBSongProgress.Name = "PBSongProgress";
            this.PBSongProgress.Size = new System.Drawing.Size(230, 2);
            this.PBSongProgress.Step = 1;
            this.PBSongProgress.TabIndex = 4;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblUserName.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblUserName.Location = new System.Drawing.Point(412, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(33, 15);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "登录";
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // lblToggle
            // 
            this.lblToggle.AutoSize = true;
            this.lblToggle.BackColor = System.Drawing.Color.Transparent;
            this.lblToggle.Font = new System.Drawing.Font("宋体", 10F);
            this.lblToggle.Location = new System.Drawing.Point(236, 233);
            this.lblToggle.Name = "lblToggle";
            this.lblToggle.Size = new System.Drawing.Size(14, 14);
            this.lblToggle.TabIndex = 6;
            this.lblToggle.Text = "<";
            this.lblToggle.Click += new System.EventHandler(this.lblToggle_Click);
            // 
            // panelChance
            // 
            this.panelChance.BackColor = System.Drawing.Color.Honeydew;
            this.panelChance.Location = new System.Drawing.Point(0, 0);
            this.panelChance.Name = "panelChance";
            this.panelChance.Size = new System.Drawing.Size(250, 247);
            this.panelChance.TabIndex = 7;
            this.panelChance.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.lblTime.Location = new System.Drawing.Point(450, 141);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 12);
            this.lblTime.TabIndex = 3;
            // 
            // desireFM
            // 
            this.desireFM.BalloonTipText = "Simple FM";
            this.desireFM.BalloonTipTitle = "Simple FM";
            this.desireFM.ContextMenuStrip = this.contextMenuStrip1;
            this.desireFM.Icon = ((System.Drawing.Icon)(resources.GetObject("desireFM.Icon")));
            this.desireFM.Tag = "Simple FM";
            this.desireFM.Text = "Simple FM";
            this.desireFM.Visible = true;
            this.desireFM.DoubleClick += new System.EventHandler(this.desireFM_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(98, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // pbNext
            // 
            this.pbNext.Image = global::DesireFM.Properties.Resources.next;
            this.pbNext.Location = new System.Drawing.Point(452, 185);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(36, 36);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbNext.TabIndex = 5;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbNo
            // 
            this.pbNo.Image = global::DesireFM.Properties.Resources.delete;
            this.pbNo.Location = new System.Drawing.Point(393, 185);
            this.pbNo.Name = "pbNo";
            this.pbNo.Size = new System.Drawing.Size(36, 36);
            this.pbNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbNo.TabIndex = 5;
            this.pbNo.TabStop = false;
            this.pbNo.Click += new System.EventHandler(this.pbNo_Click);
            // 
            // pbPause
            // 
            this.pbPause.Image = ((System.Drawing.Image)(resources.GetObject("pbPause.Image")));
            this.pbPause.Location = new System.Drawing.Point(475, -11);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(48, 48);
            this.pbPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPause.TabIndex = 5;
            this.pbPause.TabStop = false;
            this.pbPause.Click += new System.EventHandler(this.pbPause_Click);
            // 
            // pbRed
            // 
            this.pbRed.Image = global::DesireFM.Properties.Resources.unlike;
            this.pbRed.Location = new System.Drawing.Point(330, 185);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(36, 36);
            this.pbRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbRed.TabIndex = 5;
            this.pbRed.TabStop = false;
            this.pbRed.Tag = "black";
            this.pbRed.Click += new System.EventHandler(this.pbRed_Click);
            // 
            // pbICover
            // 
            this.pbICover.Image = global::DesireFM.Properties.Resources.milkyway5;
            this.pbICover.Location = new System.Drawing.Point(0, 0);
            this.pbICover.Name = "pbICover";
            this.pbICover.Size = new System.Drawing.Size(250, 247);
            this.pbICover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbICover.TabIndex = 0;
            this.pbICover.TabStop = false;
            this.pbICover.DoubleClick += new System.EventHandler(this.pbICover_DoubleClick);
            // 
            // PbShowVolumeControl
            // 
            this.PbShowVolumeControl.Image = global::DesireFM.Properties.Resources.volume_down;
            this.PbShowVolumeControl.Location = new System.Drawing.Point(492, 141);
            this.PbShowVolumeControl.Name = "PbShowVolumeControl";
            this.PbShowVolumeControl.Size = new System.Drawing.Size(12, 12);
            this.PbShowVolumeControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbShowVolumeControl.TabIndex = 10;
            this.PbShowVolumeControl.TabStop = false;
            this.PbShowVolumeControl.MouseEnter += new System.EventHandler(this.lbShowVolumeControl_MouseEnter);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblTip.Location = new System.Drawing.Point(268, 228);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 12);
            this.lblTip.TabIndex = 13;
            this.lblTip.Visible = false;
            // 
            // trpControl
            // 
            this.trpControl.BorderColor = System.Drawing.Color.Empty;
            this.trpControl.Location = new System.Drawing.Point(295, 9);
            this.trpControl.Name = "trpControl";
            this.trpControl.Size = new System.Drawing.Size(28, 15);
            this.trpControl.TabIndex = 12;
            this.trpControl.Text = "transparentPanel1";
            this.trpControl.Visible = false;
            // 
            // VCVolume
            // 
            this.VCVolume.BackColor = System.Drawing.Color.White;
            this.VCVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VCVolume.EmptyColor = System.Drawing.Color.Gainsboro;
            this.VCVolume.FillColor = System.Drawing.SystemColors.Highlight;
            this.VCVolume.Location = new System.Drawing.Point(439, 143);
            this.VCVolume.MaxValue = 100;
            this.VCVolume.MinValue = 0;
            this.VCVolume.Name = "VCVolume";
            this.VCVolume.Shape = DesireFM.VolumeControl.TrackShape.Circle;
            this.VCVolume.Size = new System.Drawing.Size(65, 10);
            this.VCVolume.TabIndex = 9;
            this.VCVolume.Text = "volumeControl1";
            this.VCVolume.Value = 30;
            this.VCVolume.Visible = false;
            this.VCVolume.Scroll += new System.EventHandler(this.VCVolume_Scroll);
            // 
            // wmpPlayer
            // 
            this.wmpPlayer.Enabled = true;
            this.wmpPlayer.Location = new System.Drawing.Point(257, 190);
            this.wmpPlayer.Name = "wmpPlayer";
            this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
            this.wmpPlayer.Size = new System.Drawing.Size(10, 10);
            this.wmpPlayer.TabIndex = 8;
            this.wmpPlayer.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 245);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.trpControl);
            this.Controls.Add(this.PbShowVolumeControl);
            this.Controls.Add(this.VCVolume);
            this.Controls.Add(this.wmpPlayer);
            this.Controls.Add(this.panelChance);
            this.Controls.Add(this.lblToggle);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbNo);
            this.Controls.Add(this.pbPause);
            this.Controls.Add(this.pbRed);
            this.Controls.Add(this.PBSongProgress);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSong);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.lblSinger);
            this.Controls.Add(this.pbICover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple FM";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbICover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShowVolumeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbICover;
        private System.Windows.Forms.Label lblSinger;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.ProgressBar PBSongProgress;
        private System.Windows.Forms.PictureBox pbRed;
        private System.Windows.Forms.PictureBox pbNo;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPause;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblToggle;
        private System.Windows.Forms.Panel panelChance;
        private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.NotifyIcon desireFM;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private VolumeControl VCVolume;
        private System.Windows.Forms.PictureBox PbShowVolumeControl;
        private TransparentPanel trpControl;
        private System.Windows.Forms.Label lblTip;
    }
}

