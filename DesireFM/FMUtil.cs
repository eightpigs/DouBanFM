using System;
using System.Net;
using System.IO;
using System.Text;

namespace DesireFM
{
    /// <summary>
    /// FM歌曲相关操作类
    /// 获取歌曲
    /// 获取赫兹
    /// 暂停歌曲
    /// 下一首
    /// 红心/取消红心
    /// 不再听
    /// 下载当前歌曲
    /// </summary>
    class FMUtil
    {

        #region 需要重复使用的变量
         

        /// <summary>
        /// 需要用到的地址
        /// </summary>
        private static string url;
        
        /// <summary>
        /// 请求响应对象
        /// </summary>
        private static WebClient client;

        /// <summary>
        /// JSON结果
        /// </summary>
        private static string jsonStr;

        #endregion


        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public static string Login()
        {
            //登录地址
             url= String.Format("http://www.douban.com/j/app/login?app_name=radio_desktop_win&version=100&email={0}&password={1}",UserEntity.email,UserEntity.password);

            client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            //模拟IE的方式访问
            client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
            client.Encoding = new UTF8Encoding();
            jsonStr = client.DownloadString(url);
            //返回的Cookie.用来获取红心列表
            Global.Cookie = client.ResponseHeaders.Get("Set-Cookie");

            return jsonStr;
        }
        #endregion

            
        #region 获取所有赫兹
        
        /// <summary>
        /// 获取所有赫兹
        /// </summary>
        public static string getChances()
        {
            url = "http://www.douban.com/j/app/radio/channels";
            client=new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            //模拟IE的方式访问
            client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
            client.Encoding = new UTF8Encoding();
            jsonStr = client.DownloadString(url);
            return jsonStr;
        }
        #endregion


        #region 歌曲操作
        /// <summary>
        /// 歌曲操作
        /// </summary>
        /// <param name="channel_id"></param>
        public static String getSongs(int channel_id,string type,string sid)
        {
            //获取新歌曲
            if (type.Equals("n"))
            {
                
                if(UserEntity.userName!=null)
                    url = string.Format("http://www.douban.com/j/app/radio/people?type=n&app_name=radio_desktop_win&version=100&channel={0}&user_id={1}&expire={2}&token={3}", channel_id, UserEntity.userId, UserEntity.expire, UserEntity.token);
                else
                    url = string.Format("http://www.douban.com/j/app/radio/people?app_name=radio_desktop_win&version=100&type=n&channel={0}", channel_id);

                client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                //模拟IE的方式访问
                client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
                client.Encoding = new UTF8Encoding();
                jsonStr = client.DownloadString(url);
            }
                //不再听
            else if (type.Equals("b"))
            {
                url = string.Format("http://www.douban.com/j/app/radio/people?app_name=radio_desktop_win&version=100&sid={0}&type=b&user_id={1}&expire={2}&token={3}&channel={4}", sid, UserEntity.userId, UserEntity.expire, UserEntity.token, channel_id);
                client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                //模拟IE的方式访问
                client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
                client.Encoding = new UTF8Encoding();
                jsonStr = client.DownloadString(url);
            }
                //加红心
            else if (type.Equals("r"))
            {
                url = string.Format("http://www.douban.com/j/app/radio/people?app_name=radio_desktop_win&version=100&sid={0}&type=r&user_id={1}&expire={2}&token={3}&channel={4}", sid, UserEntity.userId, UserEntity.expire, UserEntity.token,channel_id);
                client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                //模拟IE的方式访问
                client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
                client.Encoding = new UTF8Encoding();
                jsonStr = client.DownloadString(url);
            }
                //取消红心
            else if(type.Equals("u"))
            {
                url = string.Format("http://www.douban.com/j/app/radio/people?app_name=radio_desktop_win&version=100&sid={0}&type=u&user_id={1}&expire={2}&token={3}&channel={4}", sid, UserEntity.userId, UserEntity.expire, UserEntity.token, channel_id);
                client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                //模拟IE的方式访问
                client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
                client.Encoding = new UTF8Encoding();
                jsonStr = client.DownloadString(url);
            }

            return jsonStr;
        }
        #endregion


        #region 下载单首
        /// <summary>
        /// 下载单首流并播放
        /// </summary>
        /// <param name="songUrl"></param>
        /// <returns></returns>
        public static void downOneSongStream()
        {
            client = new WebClient(); 
            client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
            client.Encoding = new UTF8Encoding();
            client.DownloadFile(Global.Songs[frmMain.SongListIndex].url, Global.downLoadPath+"/" + Global.Songs[frmMain.SongListIndex].title+".mp3");
        }
        #endregion


        #region 得到流
        /// <summary>
        /// 得到流
        /// </summary>
        /// <param name="streamUrl"></param>
        /// <returns></returns>
        public static Stream downStream(string streamUrl)
        {
            client = new WebClient();
            client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
            client.Encoding = new UTF8Encoding();
            return client.OpenRead(streamUrl);
        }
        #endregion

        #region 获取红心列表

        public static void GetRedHreats()
        {
            //登录地址
            url = String.Format("http://douban.fm/mine#!type=liked&start=1");

            client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            //模拟IE的方式访问
            client.Headers.Add("User-Agent", "Microsoft Internet Explorer");
            client.Headers.Add("Cookie",Global.Cookie);
            client.Encoding = new UTF8Encoding();
            jsonStr = client.DownloadString(url);
        }
        #endregion
    }
}
