using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TvList.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TvGuide : ContentPage
    {
        public TvGuide()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
