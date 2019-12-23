using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HitokotoApi
{
    public static class HitokotoUtils
    {
        private const string API_URL = @"https://v1.hitokoto.cn/";

        public static async Task<Hitokoto> GetHitokoto(Category cate = Category.None, bool textOnly = false)
        {
            StringBuilder param = new StringBuilder("?charset=utf-8");
            if (cate != Category.None)
                param.Append("&c=" + cate.ToParamString());

            if (textOnly)
                param.Append("&encode=text");

            HttpWebRequest req = WebRequest.Create(API_URL + param) as HttpWebRequest;

            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            WebResponse res = await req.GetResponseAsync();

            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                string content = await reader.ReadToEndAsync();

                if (textOnly)
                    return new Hitokoto(0, content);
                else
                    return JsonConvert.DeserializeObject<Hitokoto>(content);
            }
        }
    }
}
