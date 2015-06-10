using System;
using System.Collections.Generic;

namespace DesireFM
{
    /// <summary>
    /// 全局类
    /// </summary>
    class Global
    {
        /// <summary>
        /// 赫兹集合
        /// </summary>
        public static List<ChannelEntity> Channels { get; set; }

        /// <summary>
        /// 歌曲集合
        /// </summary>
        public static List<SongEntity> Songs { get; set; }

        /// <summary>
        /// 登录时返回的Cookie
        /// </summary>
        public static string Cookie { get; set; }

        /// <summary>
        /// 下载歌曲的路径
        /// </summary>
        public static String downLoadPath { get; set; }
    }
}
