using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hitokoto
{
    public static class HitokotoHelper
    {
        private const string GLOBAL_API_URL = @"https://v1.hitokoto.cn/";
        // private const string INTERNATIONAL_API_URL = @"https://international.v1.hitokoto.cn";

        /// <summary>
        /// 获取一言
        /// </summary>
        /// <param name="cate">分类<see cref="Category"/></param>
        /// <param name="textOnly">是否只需要内容</param>
        /// <returns>一言<see cref="HitokotoContent"/></returns>
        public static async Task<HitokotoContent> GetHitokoto(Category cate = Category.None, bool textOnly = false)
        {
            StringBuilder param = new StringBuilder("?charset=utf-8");
            if (cate != Category.None)
                param.Append("&c=" + cate.ToParamString());

            if (textOnly)
                param.Append("&encode=text");

            HttpWebRequest req = WebRequest.Create(GLOBAL_API_URL + param) as HttpWebRequest;

            // 只支持 GET 方法
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            WebResponse res = await req.GetResponseAsync();

            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                string content = await reader.ReadToEndAsync();

                if (textOnly)
                    return new HitokotoContent(0, content);
                else
                    return JsonConvert.DeserializeObject<HitokotoContent>(content);
            }
        }
    }
}
