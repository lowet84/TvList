using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvList.Model;
using XLabs;

namespace TvList.ViewModel
{
    public class TvGuideItemViewModel
    {
        private readonly XmlTvRootObject _item;

        public TvGuideItemViewModel(XmlTvRootObject item)
        {
            _item = item;
        }

        public string Name => _item.Name;

        public IEnumerable<Programme> ShortGuide => GetShortGuide();

        private List<Programme> GetShortGuide()
        {
            return GetFutureGuide().Take(3).ToList();
        }

        private List<Programme> GetFullGuide()
        {
            return _item.jsontv.programme;
        }

        private List<Programme> GetFutureGuide()
        {
            return GetFullGuide().Where(d => d.EndDateTime > DateTime.Now).ToList();
        }
    }
}
