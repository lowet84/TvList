using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvList.Utils;

namespace TvList.Model
{
    [DebuggerDisplay("{title.sv}")]
    public partial class Programme
    {
        [JsonIgnore]
        public string TimeText => $"{StartDateTime.Hour:00}:{StartDateTime.Minute:00}-{EndDateTime.Hour:00}:{EndDateTime.Minute:00}";
        [JsonIgnore]
        public string Name => title.sv;
        [JsonIgnore]
        public DateTime StartDateTime => ConverterUtil.UnixTimeStampToDateTime(double.Parse(start));
        [JsonIgnore]
        public DateTime EndDateTime => ConverterUtil.UnixTimeStampToDateTime(double.Parse(stop));
    }
}
