namespace Hitokoto
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    /// <summary>
    /// 一言
    /// </summary>
    public class HitokotoContent
    {
        /// <summary>
        /// 一言标识
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// 一言正文
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
        /// 一言的出处
        /// </summary>
        [JsonProperty("from")]
        public string From { get; private set; }

        /// <summary>
        /// 一言的作者
        /// </summary>
        [JsonProperty("from_who")]
        public string FromWho { get; private set; }

        /// <summary>
        /// 添加者
        /// </summary>
        [JsonProperty("creator")]
        public string Creator { get; private set; }

        /// <summary>
        /// 添加者用户标识
        /// </summary>
        [JsonProperty("creator_uid")]
        public string CreatorUid { get; private set; }

        /// <summary>
        /// 审核员标识
        /// </summary>
        [JsonProperty("reviewer")]
        public string Reviewer { get; private set; }

        /// <summary>
        /// 一言唯一标识；可以链接到 https://hitokoto.cn?uuid=[uuid] 查看这个一言的完整信息
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; private set; }

        /// <summary>
        /// 提交方式
        /// </summary>
        [JsonProperty("commit_from")]
        public string CommitFrom { get; private set; }

        /// <summary>
        /// 上传时间
        /// 使用Unix时间戳
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]  // Unix 时间戳
        public DateTime Time { get; private set; }

        /// <summary>
        /// 句子长度
        /// </summary>
        [JsonProperty("length")]
        public int Length { get; private set; }

        [JsonConstructor]
        public HitokotoContent(
            int id,
            string content,
            Category cate = Category.None,
            string from = null,
            string fromWho = null,
            string creator = null,
            string creatorUid = null,
            string reviewer = null,
            string uuid = null,
            string commitFrom = null,
            DateTime time = new DateTime(),
            int length = 0)
        {
            Id = id;
            Content = content;
            Category = cate;
            From = from;
            FromWho = fromWho;
            Creator = creator;
            CreatorUid = creatorUid;
            Reviewer = reviewer;
            Uuid = uuid;
            CommitFrom = commitFrom;
            Time = time;
            Length = length;
        }
    }
}
