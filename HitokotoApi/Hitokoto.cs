namespace HitokotoApi
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    /// <summary>
    /// 一言
    /// </summary>
    public class Hitokoto
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// 一言内容
        /// </summary>
        [JsonProperty("hitokoto")]
        public string Content { get; private set; }

        /// <summary>
        /// 分类
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(CategoryConverter))]
        public Category Category { get; private set; }

        /// <summary>
        /// 出自哪里
        /// </summary>
        [JsonProperty("from")]
        public string From { get; private set; }

        /// <summary>
        /// 上传者
        /// </summary>
        [JsonProperty("creator")]
        public string Creator { get; private set; }

        /// <summary>
        /// 上传时间
        /// 使用Unix时间戳
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]  // Unix 时间戳
        public DateTime Time { get; private set; }

        [JsonConstructor]
        public Hitokoto(
            int id,
            string content,
            Category cate = Category.None,
            string from = null,
            string creator = null,
            DateTime time = new DateTime())
        {
            Id = id;
            Content = content;
            Category = cate;
            From = from;
            Creator = creator;
            Time = time;
        }
    }
}
