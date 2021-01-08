#if NET45
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#else
using System.Text.Json.Serialization;
#endif
using System;

namespace Hitokoto
{
    /// <summary>
    /// 一言
    /// </summary>
    public class HitokotoContent
    {
        /// <summary>
        /// 一言标识
        /// </summary>
#if NET45
        [JsonProperty("id")]
#else
        [JsonPropertyName("id")]
#endif
        public int Id { get; set; }

        /// <summary>
        /// 一言正文
        /// </summary>
#if NET45
        [JsonProperty("hitokoto")]
#else
        [JsonPropertyName("hitokoto")]
#endif
        public string Content { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
#if NET45
        [JsonProperty("type")]
#else
        [JsonPropertyName("type")]
#endif
        [JsonConverter(typeof(CategoryConverter))]
        public Category Category { get; set; }

        /// <summary>
        /// 一言的出处
        /// </summary>
#if NET45
        [JsonProperty("from")]
#else
        [JsonPropertyName("from")]
#endif
        public string From { get; set; }

        /// <summary>
        /// 一言的作者
        /// </summary>
#if NET45
        [JsonProperty("from_who")]
#else
        [JsonPropertyName("from_who")]
#endif
        public string FromWho { get; set; }

        /// <summary>
        /// 添加者
        /// </summary>
#if NET45
        [JsonProperty("creator")]
#else
        [JsonPropertyName("creator")]
#endif
        public string Creator { get; set; }

        /// <summary>
        /// 添加者用户标识
        /// </summary>
#if NET45
        [JsonProperty("creator_uid")]
#else
        [JsonPropertyName("creator_uid")]
#endif
        public int CreatorUid { get; set; }

        /// <summary>
        /// 审核员标识
        /// </summary>
#if NET45
        [JsonProperty("reviewer")]
#else
        [JsonPropertyName("reviewer")]
#endif
        public int Reviewer { get; set; }

        /// <summary>
        /// 一言唯一标识；可以链接到 https://hitokoto.cn?uuid=[uuid] 查看这个一言的完整信息
        /// </summary>
#if NET45
        [JsonProperty("uuid")]
#else
        [JsonPropertyName("uuid")]
#endif
        public string Uuid { get; set; }

        /// <summary>
        /// 提交方式
        /// </summary>
#if NET45
        [JsonProperty("commit_from")]
#else
        [JsonPropertyName("commit_from")]
#endif
        public string CommitFrom { get; set; }

        /// <summary>
        /// 上传时间
        /// 使用Unix时间戳
        /// </summary>
#if NET45
        [JsonProperty("created_at")]
#else
        [JsonPropertyName("created_at")]
#endif
        [JsonConverter(typeof(UnixDateTimeConverter))]  // Unix 时间戳
        public DateTime Time { get; set; }

        /// <summary>
        /// 句子长度
        /// </summary>
#if NET45
        [JsonProperty("length")]
#else
        [JsonPropertyName("length")]
#endif
        public int Length { get; set; }
    }
}
