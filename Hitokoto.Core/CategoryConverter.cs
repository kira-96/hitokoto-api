namespace Hitokoto
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 自定义分类转换
    /// </summary>
    internal class CategoryConverter : JsonConverter
    {
        private readonly Dictionary<string, Category> _categoryDic =
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

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Category);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!(reader?.Value is string key))
                return Category.None;
            
            return _categoryDic[key];
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false.");
        }
    }
}
