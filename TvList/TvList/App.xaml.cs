using TvList.ContentPages;
using TvList.Utils;
using TvList.ViewModel;
using Xamarin.Forms;

namespace TvList
{
    public partial class App
    {
        public static ITvSettings Settings { get; private set; }

        public App(ITvSettings settings)
        {
            Settings = settings;
            InitializeComponent();
            var channelData = Cache.Instance.GetCache();
            MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new TvGuide())
                    {
                        Title = "TV Guide",
                        BindingContext = new TvGuideViewModel(channelData)
                        //Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new MainPage())
                    {
                        Title = "Browse2",
                        //Icon = Device.OnPlatform("tab_feed.png",null,null)
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
