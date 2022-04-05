using Autofac;
using NUnit.Framework;
using Autofac.Extras.Moq;
using Coffer.Interfaces;
using Coffer.Test.Services;
using Coffer.Tools;
using Coffer.ViewModels;

namespace Coffer.Test.ViewModels
{
    public class CloudServiceTest
    {
        [Test]
        public void DownloadDbShouldPass()
        {
            var mock = AutoMock.GetStrict();
            mock.Mock<Util>();

            var serviceToTest = mock.Create<MockCloudService>();
            serviceToTest.DownloadDB();

            Assert.IsTrue(serviceToTest.DownloadIsSuccessful);

        }
    }
}