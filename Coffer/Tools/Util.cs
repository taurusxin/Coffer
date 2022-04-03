using System;
using System.Net;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Coffer.Tools
{
    public class Util
    {
        public void DownloadDB()
        {
            var hasNetwork = Connectivity.NetworkAccess;
            if (hasNetwork == NetworkAccess.Internet)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri("https://api.icoffer.app/coffer.db3"), Constants.DbPath);
                webClient.DownloadFileCompleted += (sender, args) =>
                {
                    Settings.Settings.LatestUpdate = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
                    MessagingCenter.Send(this, "UpdateComplete");
                    MessagingCenter.Send(this, "ReloadBrands");
                };
            }
            else
            {
                NoInternet();
            }
        }
        public static void NoInternet()
        {
            Application.Current.MainPage.DisplayAlert("Error", 
                "You need ethernet connect to donwload database!", 
                "OK");
        }
    }
}