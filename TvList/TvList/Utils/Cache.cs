using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TvList.Model;
using TvList.Model.XmlTv;
using Xamarin.Forms;

namespace TvList.Utils
{
    public class Cache
    {
        private static Cache _cache;
        private List<XmlTvRootObject> _xmlTvRootObjectsCache;
        private DateTime _cacheDate = new DateTime(1970, 1, 1);

        public static Cache Instance => _cache ?? (_cache = new Cache());

        public List<XmlTvRootObject> GetCache()
        {
            if (_xmlTvRootObjectsCache != null && _cacheDate.Date.Equals(DateTime.Today))
            {
                return _xmlTvRootObjectsCache;
            }
            var settingsCache = App.Settings.Cache;
            var settingsDate = App.Settings.CacheDate;

            if (settingsCache != null && settingsDate.Date.Equals(DateTime.Today))
            {
                _xmlTvRootObjectsCache = settingsCache;
                _cacheDate = settingsDate;
                return _xmlTvRootObjectsCache;
            }

            UpdateCache();
            return _xmlTvRootObjectsCache;
        }

        public void UpdateCache()
        {
            var channels = ChannelUtil.SelectedChannels;
            var tasks = channels.Select(d => GetUpdateTask(d, DateTime.Now.Date)).ToList();
            foreach (var task in tasks)
            {
                task.Start();
            }
            while (!tasks.All(d => d.IsCompleted))
            {

            }
            var results = tasks.Select(d => d.Result).ToList();
            App.Settings.Cache = _xmlTvRootObjectsCache = results;
            App.Settings.CacheDate = _cacheDate = DateTime.Now;
        }

        private Task<XmlTvRootObject> GetUpdateTask(Channel channel, DateTime date)
        {
            return new Task<XmlTvRootObject>(() =>
            {
                try
                {
                    var ret = ChannelUtil.GetChannelGuide(channel, date);
                    return ret;
                }
                catch (Exception e)
                {
                    throw e;
                }

            });
        }
    }
}
