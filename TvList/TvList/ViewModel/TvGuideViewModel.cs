using System.Collections.Generic;
using System.Linq;
using TvList.Model.XmlTv;
using TvList.Utils;

namespace TvList.ViewModel
{
    public class TvGuideViewModel
    {
        private readonly List<XmlTvRootObject> _channelData;

        public TvGuideViewModel(List<XmlTvRootObject> channelData)
        {
            _channelData = channelData;
        }

        public List<TvGuideItemViewModel> Items => _channelData.Select(d=>new TvGuideItemViewModel(d)).ToList();

        public RelayCommand ItemTappedCommand => new RelayCommand((p) =>
        {
            var x = p;
        });
    }
}
