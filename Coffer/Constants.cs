using System;
using System.IO;

namespace Coffer
{
    public class Constants
    {
        // this define the main SQLite3 database file path
        public static string DbPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "coffer.db3");
    }
}