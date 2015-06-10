namespace DesireFM
{
    /// <summary>
    /// 用户实体类.记录用户信息
    /// </summary>
   public static class UserEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
       public static string userId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
       public static string userName { get; set; }

        /// <summary>
        /// 用户令牌
        /// </summary>
        public static string token { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public static string expire { get; set; }

        /// <summary>
        /// 用户邮箱(登录帐号)
        /// </summary>
        public static string email { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public static string password { get; set; }

       /// <summary>
       /// 是否登录错误
       /// </summary>
        public static string r { get; set; }

        //登录失败的错误消息
        public static string errormessage { get; set; }
    }
}
