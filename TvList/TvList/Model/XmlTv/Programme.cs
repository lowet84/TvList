using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using TvList.Utils;
using Xamarin.Forms;

namespace TvList.Model
{
    public partial class Programme
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
    }

    
}