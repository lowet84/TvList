using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;

namespace TvList.Model.XmlTv
{
    [DebuggerDisplay("{Name}")]
    public class XmlTvRootObject
    {
        public Jsontv jsontv { get; set; }


        [JsonIgnore]
        public string Name => jsontv.programme.FirstOrDefault(d => !string.IsNullOrEmpty(d.channel))?.channel;
    }
}