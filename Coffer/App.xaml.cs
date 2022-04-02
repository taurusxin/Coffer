using System;
using System.Net;
using Coffer.Navigation;
using Coffer.Tools;
using Coffer.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: ExportFont("AvenirNext-Regular.ttf", Alias = "AN-R")]
[assembly: ExportFont("AvenirNext-Bold.ttf", Alias = "AN-B")]
[assembly: ExportFont("AvenirNext-UltraLight.ttf", Alias = "AN-U")]
[assembly: ExportFont("AvenirNext-Medium.ttf", Alias = "AN-M")]

namespace Coffer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            IocProvider.Init();
            MainPage = new NavigationPage(new TabbedAppPage());
            NavigationDispatcher.Instance.Initialize(MainPage.Navigation);
        }

        protected override void OnStart()
        {
            if (Settings.Settings.FirstRun)
            {
                Settings.Settings.FirstRun = false;
            }

            if (Settings.Settings.AutoUpdate)
            {
                IocProvider.ServiceProvider.GetService<Util>().DownloadDB();
            }
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