using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TvList.Utils
{
    public static class JsonUtil
    {
        public static string Serialize(object item)
        {
            var sb = new StringBuilder();
            var tw = new StringWriter(sb);
            var js = JsonSerializer.Create();
            js.Serialize(tw,item);
            return sb.ToString();
        }

        public static T Deserialize<T>(string json)
        {
            var js = JsonSerializer.Create();
            var rd = new JsonTextReader(new StringReader(json));
            return js.Deserialize<T>(rd);
        }
    }
}
