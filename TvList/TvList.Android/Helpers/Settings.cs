using System;
using System.Collections.Generic;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using TvList.Model;
using TvList.Model;
using TvList.Utils;

namespace TvList.Droid.Helpers
{
    public class Settings : ITvSettings
    {
        private static Settings _instance;
        public static Settings Instance => _instance ?? (_instance = new Settings());

        private Settings()
        {

        }

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public List<Channel> SelectedChannels
        {
            get
            {
                var json = AppSettings.GetValueOrDefault<string>("SelectedChannels", null);
                return JsonUtil.Deserialize<List<Channel>>(json);
            }
            set
            {
                var json = JsonUtil.Serialize(value);
                AppSettings.AddOrUpdateValue("SelectedChannels", json);
            }
        }

        public List<XmlTvRootObject> Cache
        {
            get
            {
                var json = AppSettings.GetValueOrDefault<string>("Cache", null);
                return JsonUtil.Deserialize<List<XmlTvRootObject>>(json);
            }
            set
            {
                var json = JsonUtil.Serialize(value);
                AppSettings.AddOrUpdateValue("Cache", json);
            }
        }

        public DateTime CacheDate
        {
            get
            {
                var json = AppSettings.GetValueOrDefault<string>("CacheDate", null);
                if (string.IsNullOrEmpty(json))
                {
                    return new DateTime(1970, 1, 1);
                }
                return JsonUtil.Deserialize<DateTime>(json);
            }
            set
            {
                var json = JsonUtil.Serialize(value);
                AppSettings.AddOrUpdateValue("CacheDate", json);
            }
        }
    }
}