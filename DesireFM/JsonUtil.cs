using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DesireFM
{
    /// <summary>
    /// JSON解析类
    /// </summary>
   public static class JsonUtil
   {

       #region 解析用户登录的json
       /// <summary>
        /// 将登录返回的json解析成用户实体类
        /// </summary>
        public static void JsonToLogin(string json)
        {
            //是否登录成功

            JObject obj = JObject.Parse(json);
            UserEntity.r = obj["r"].ToString();
            if (UserEntity.r.Equals("0"))
            {
                UserEntity.email = obj["email"].ToString();
                UserEntity.expire = obj["expire"].ToString();
                UserEntity.token = obj["token"].ToString();
                UserEntity.userId = obj["user_id"].ToString();
                UserEntity.userName = obj["user_name"].ToString();
            }
            else
            {
                UserEntity.errormessage = obj["err"].ToString();
            }
        }
       #endregion


       #region 解析获取赫兹的json
       /// <summary>
        /// 解析获取赫兹的json
       /// </summary>
       /// <param name="json"></param>
        public static void JsonToChances(string json)
       {
           Global.Channels = null;
            Global.Channels=new List<ChannelEntity>();
           JObject obj = JObject.Parse(json);
           string chancesJson=obj["channels"].ToString();
           JArray array=(JArray)JsonConvert.DeserializeObject(chancesJson);
           foreach (var a in array)
           {
               //将每一个赫兹存到集合
               Global.Channels.Add(new ChannelEntity(a["name"].ToString(), a["name_en"].ToString(), int.Parse(a["channel_id"].ToString())));
           }
       }

       #endregion


        #region 解析获取歌曲的json
        /// <summary>
        /// 解析获取歌曲的json
       /// </summary>
       /// <param name="json"></param>
        public static void JsonToSongs(string json)
        {
            Global.Songs = null;
            Global.Songs=new List<SongEntity>();
            string songJson = JObject.Parse(json)["song"].ToString();
            JArray songArr = (JArray)JsonConvert.DeserializeObject(songJson);
            foreach (var s in songArr)
            {
                //将每一首歌存到集合
                Global.Songs.Add(new SongEntity(s["album"].ToString(), s["picture"].ToString(), s["ssid"].ToString(), s["artist"].ToString(), s["url"].ToString(),
                    s["company"].ToString(), s["title"].ToString(), s["rating_avg"].ToString(), int.Parse(s["length"].ToString()), s["public_time"].ToString(),
                    s["sid"].ToString(), s["aid"].ToString(), s["kbps"].ToString(), s["albumtitle"].ToString(), int.Parse(s["like"].ToString())));
            }
        }
        #endregion
   }
}
