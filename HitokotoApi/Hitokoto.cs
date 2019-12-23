namespace HitokotoApi
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class Hitokoto
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("hitokoto")]
        public string Content { get; private set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(CategoryConverter))]
        public Category Category { get; private set; }

        [JsonProperty("from")]
        public string From { get; private set; }

        [JsonProperty("creator")]
        public string Creator { get; private set; }

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
