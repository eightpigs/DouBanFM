namespace DesireFM
{
    /// <summary>
    /// 歌曲信息
    /// </summary>
    class SongEntity
    {
        /// <summary>
        /// 专辑跳转地址
        /// </summary>
        public string album { get; set; }
        
        /// <summary>
        /// 专辑图片
        /// </summary>
        public string picture { get; set; }

        /// <summary>
        /// SSID
        /// </summary>
        public string ssid { get; set; }

        /// <summary>
        /// 歌手
        /// </summary>
        public string artist { get; set; }

        /// <summary>
        /// 歌曲地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 唱片公司
        /// </summary>
        public string company { get; set; }

        /// <summary>
        /// 歌曲名
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 平均分数
        /// </summary>
        public string rating_avg { get; set; }

        /// <summary>
        /// 歌曲时长
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// 出版年份
        /// </summary>
        public string public_time { get; set; }

        /// <summary>
        /// 歌曲编号
        /// </summary>
        public string sid { get; set; }

        /// <summary>
        /// 专辑编号
        /// </summary>
        public string aid { get; set; }

        /// <summary>
        /// Kbps
        ///
        /// </summary>
        public string kbps{ get; set; }

        /// <summary>
        /// 专辑名称
        /// </summary>
        public string albumtitle { get; set; }

        /// <summary>
        /// 是否喜欢
        /// </summary>
        public int like { get; set; }

        public SongEntity(){}

        public SongEntity(string album, string picture, string ssid,
            string artist, string url, string company, string title,
                   string rating_avg, int length, string public_time, 
            string sid, string aid, string kbps, string albumtitle,int like)
        {
            this.aid = aid;
            this.album = album;
            this.albumtitle = albumtitle;
            this.artist = artist;
            this.rating_avg = rating_avg;
            this.company = company;
            this.kbps = kbps;
            this.length = length;
            this.like = like;
            this.picture = picture;
            this.public_time = public_time;
            this.sid = sid;
            this.ssid = ssid;
            this.title = title;
            this.url = url;
        }
    }
}
