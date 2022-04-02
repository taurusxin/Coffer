using System;
using System.IO;

namespace Coffer
{
    public class Constants
    {
        // this define the main SQLite3 database file path
        public static string DbPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "coffer.db3");

        public static string UserDbPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "userdata.db3");
    }
}