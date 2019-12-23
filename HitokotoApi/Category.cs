namespace HitokotoApi
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
    }

    public static class CategoryEx
    {
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
                default:
                    return "";
            }
        }
    }
}
