namespace Hitokoto
{
    public enum Category
    {
        /// <summary>
        /// 随机
        /// </summary>
        None,
        /// <summary>
        /// 动画
        /// </summary>
        Anime,
        /// <summary>
        /// 漫画
        /// </summary>
        Comic,
        /// <summary>
        /// 游戏
        /// </summary>
        Game,
        /// <summary>
        /// 小说
        /// </summary>
        Novel,
        /// <summary>
        /// 原创
        /// </summary>
        Myself,
        /// <summary>
        /// 网络
        /// </summary>
        Internet,
        /// <summary>
        /// 其它
        /// </summary>
        Other,
        /// <summary>
        /// 影视
        /// </summary>
        Movies,
        /// <summary>
        /// 诗词
        /// </summary>
        Poetry,
        /// <summary>
        /// 网易云
        /// </summary>
        NeteaseCloud,
        /// <summary>
        /// 哲学
        /// </summary>
        Philosophy,
        /// <summary>
        /// 抖机灵
        /// </summary>
        抖机灵
    }

    public static class CategoryEx
    {
        /// <summary>
        /// 扩展方法
        /// 将分类转换成url请求参数
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns>url参数</returns>
        public static string ToParamString(this Category category)
        {
            return category switch
            {
                Category.Anime => "a",
                Category.Comic => "b",
                Category.Game => "c",
                Category.Novel => "d",
                Category.Myself => "e",
                Category.Internet => "f",
                Category.Other => "g",
                Category.Movies => "h",
                Category.Poetry => "i",
                Category.NeteaseCloud => "j",
                Category.Philosophy => "k",
                Category.抖机灵 => "l",
                _ => "a",
            };
        }
    }
}
