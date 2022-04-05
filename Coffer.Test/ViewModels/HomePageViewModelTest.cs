using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Coffer.Interfaces;
using Coffer.Models;
using Coffer.ViewModels;
using Moq;
using NUnit.Framework;

namespace Coffer.Test.ViewModels
{
    public class HomePageViewModelTest
    {
        [Test]
        public async Task InitializeShouldHaveBrands()
        {
            var mock = AutoMock.GetStrict();
            mock.Mock<IBrandService>().Setup(method => method.GetBrandsAsync())
                .ReturnsAsync(new List<Brand>
                {
                    new Brand
                    {
                        Id = 1,
                        BrandName = "Starbucks",
                        BrandIcon = "https://assets.icoffer.app/image/starbucks.png"
                    }
                });

            var viewmodelToTest = mock.Create<HomePageViewModel>();

            await viewmodelToTest.Initialise();
            
            Assert.IsTrue(viewmodelToTest.ObBrands[0].Id == 1);

        }
    }
}