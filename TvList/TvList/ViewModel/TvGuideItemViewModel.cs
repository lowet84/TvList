using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvList.Model.XmlTv;
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
    }
}
