using System;
using System.IO;
using System.Net;
using Xamarin.Essentials;

namespace Coffer.Settings
{
    public static class Settings
    {
        public static bool FirstRun
        {
            get => Preferences.Get(nameof(FirstRun), true);
            set => Preferences.Set(nameof(FirstRun), value);
        }

        public static bool HasDB
        {
            get => File.Exists(Constants.DbPath);
        }

        public static void DownloadDB()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(new Uri("https://api.icoffer.app/coffer.db3"), Constants.DbPath);
        }
    }
}