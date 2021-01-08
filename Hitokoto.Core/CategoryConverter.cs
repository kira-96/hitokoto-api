#if NET45
using Newtonsoft.Json;
#else
using System.Text.Json;
using System.Text.Json.Serialization;
#endif
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hitokoto
{
    /// <summary>
    /// 自定义分类转换
    /// </summary>
#if NET45
    internal class CategoryConverter : JsonConverter
#else
    internal class CategoryConverter : JsonConverter<Category>
#endif
    {
        internal static readonly Dictionary<string, Category> _categoryDic =
            new Dictionary<string, Category>()
            {
                { "a", Category.Anime },
                { "b", Category.Comic },
                { "c", Category.Game  },
                { "d", Category.Novel },
                { "e", Category.Myself},
                { "f", Category.Internet },
                { "g", Category.Other },
                { "h", Category.Movies },
                { "i", Category.Poetry },
                { "j", Category.NeteaseCloud },
                { "k", Category.Philosophy },
                { "l", Category.抖机灵 }
            };

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(Category);
        }

#if NET45
        public override bool CanRead => true;

        public override bool CanWrite => true;
#endif

#if NET45
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string key = reader.ReadAsString();
#else
        public override Category Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string key = reader.GetString();
#endif

            if (_categoryDic.TryGetValue(key, out Category category))
            {
                return category;
            }
            else
            {
                return Category.None;
            }
        }

#if NET45
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string key = _categoryDic.FirstOrDefault(x => x.Value == (Category)value).Key;

            writer.WriteValue(key);
        }
#else
        public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
        {
            string key = _categoryDic.FirstOrDefault(x => x.Value == value).Key;

            writer.WriteStringValue(key);
        }
#endif
    }
}
