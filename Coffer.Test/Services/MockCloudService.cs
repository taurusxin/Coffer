using System.IO;
using Coffer.Interfaces;
using Coffer.Tools;

namespace Coffer.Test.Services
{
    public class MockCloudService : IUtil
    {
        public bool DownloadIsSuccessful = false;
        public void DownloadDB()
        {
            // Fake download here.
            DownloadIsSuccessful =  true;
        }
    }
}