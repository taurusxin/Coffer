using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Coffer.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Coffer.Tools
{
    public class Util : IUtil
    {
        public void DownloadDB()
        {
            var hasNetwork = Connectivity.NetworkAccess;
            if (hasNetwork == NetworkAccess.Internet)
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, errors) => true;
                WebClient webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri("https://api.icoffer.app/coffer.db3"), Constants.DbPath);
                webClient.DownloadFileCompleted += (sender, args) =>
                {
                    Settings.Settings.LatestUpdate = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
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