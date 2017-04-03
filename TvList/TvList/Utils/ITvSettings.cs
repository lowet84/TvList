using System;
using System.Collections.Generic;
using TvList.Model;
using TvList.Model;

namespace TvList.Utils
{
    public interface ITvSettings
    {
        List<Channel> SelectedChannels { get; set; }
        List<XmlTvRootObject> Cache { get; set; }
        DateTime CacheDate { get; set; }
    }
}