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
            switch (category)
            {
                case Category.Anime:
                    return "a";
                case Category.Comic:
                    return "b";
                case Category.Game:
                    return "c";
                case Category.Novel:
                    return "d";
                case Category.Myself:
                    return "e";
                case Category.Internet:
                    return "f";
                case Category.Other:
                    return "g";
                case Category.Movies:
                    return "h";
                case Category.Poetry:
                    return "i";
                case Category.NeteaseCloud:
                    return "j";
                case Category.Philosophy:
                    return "k";
                case Category.抖机灵:
                    return "l";
                default:
                    return "a";
            }
        }
    }
}
