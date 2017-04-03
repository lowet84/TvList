using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TvList.Model
{
    [DebuggerDisplay("{Name}")]
    public partial class XmlTvRootObject
    {
        [JsonIgnore]
        public string Name => jsontv.programme.FirstOrDefault(d => !string.IsNullOrEmpty(d.channel))?.channel;
    }
}
