using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TvList.Model;
using TvList.Model;
using Xamarin.Forms;

namespace TvList.Utils
{
    public static class ChannelUtil
    {
        public static XmlTvRootObject GetChannelGuide(Channel channel, DateTime date)
        {
            XmlTvRootObject data;
            using (var client = new HttpClient())
            {
                var url = $"http://json.xmltv.se/{channel.Name}_{date.Year:0000}-{date.Month:00}-{date.Day:00}.js.gz";
                var json = client.GetStringAsync(url).Result;
                data = JsonUtil.Deserialize<XmlTvRootObject>(json);
            }

            return data;
        }

        public static List<Channel> SelectedChannels
        {
            get
            {
                var data = App.Settings.SelectedChannels;
                if (data != null) return data;
                data = GetDefaultChannels();
                App.Settings.SelectedChannels = data;
                return data;
            }
            set { App.Settings.SelectedChannels = value; }
        }

        public static List<Channel> GetDefaultChannels()
        {
            return new List<Channel>
            {
                new Channel("svt1.svt.se"),
                new Channel("svt2.svt.se"),
                new Channel("tv4.se")
            };
        }
    }
}
