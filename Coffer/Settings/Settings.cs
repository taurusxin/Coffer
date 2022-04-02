using System;
using System.IO;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;

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

        public static bool AutoUpdate
        {
            get => Preferences.Get(nameof(AutoUpdate), false);
            set => Preferences.Set(nameof(AutoUpdate), value);
        }

        public static string LatestUpdate
        {
            get => Preferences.Get(nameof(LatestUpdate), "Never");
            set => Preferences.Set(nameof(LatestUpdate), value);
        }

    }
}