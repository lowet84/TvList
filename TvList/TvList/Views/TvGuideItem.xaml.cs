using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TvList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TvGuideItem
    {
        public TvGuideItem()
        {
            InitializeComponent();
            BindingContextChanged += TvGuideItem_BindingContextChanged;
        }

        private void TvGuideItem_BindingContextChanged(object sender, EventArgs e)
        {
            if (BindingContext != null)
            {
                
            }
        }
    }
}
