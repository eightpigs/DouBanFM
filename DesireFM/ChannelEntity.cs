namespace DesireFM
{
    /// <summary>
    /// 赫兹实体类
    /// </summary>
    class ChannelEntity
    {
        /// <summary>
        /// 赫兹名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 赫兹英文名
        /// </summary>
        public string name_en { get; set; }
        /// <summary>
        /// 赫兹编号
        /// </summary>
        public int channel_id { get; set; }

        public ChannelEntity() { }

        public ChannelEntity(string name, string name_en, int id)
        {
            this.name = name;
            this.name_en = name_en;
            this.channel_id = id;
        }
    }
}
