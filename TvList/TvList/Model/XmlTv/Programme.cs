using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using TvList.Utils;
using Xamarin.Forms;

namespace TvList.Model.XmlTv
{
    [DebuggerDisplay("{title.sv}")]
    public class Programme
    {
        public Category category { get; set; }
        public string start { get; set; }
        public string channel { get; set; }
        public string @new { get; set; }
        public Desc desc { get; set; }
        public EpisodeNum episodeNum { get; set; }
        public string stop { get; set; }
        public string date { get; set; }
        public Video video { get; set; }
        public Title title { get; set; }
        public Credits credits { get; set; }
        public SubTitle subTitle { get; set; }
        public Rating rating { get; set; }
        public List<string> url { get; set; }
        public List<string> country { get; set; }


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