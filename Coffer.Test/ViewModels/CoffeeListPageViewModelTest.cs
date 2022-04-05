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
    public class CoffeeListPageViewModelTest
    {
        [Test]
        public async Task InitializeShouldHaveCoffee()
        {
            var mock = AutoMock.GetStrict();
            mock.Mock<ICoffeeService>().Setup(method => method.GetCoffeeAsync(1))
                .ReturnsAsync(new List<Coffee>
                {
                    new Coffee()
                    {
                        Id = 1,
                        BrandId = 1,
                        CoffeeName = "Caffe Latte"
                    }
                });

            var viewmodelToTest = mock.Create<CoffeeListPageViewModel>();

            await viewmodelToTest.LoadCoffee(new Brand
            {
                Id = 1
            });
            
            Assert.IsTrue(viewmodelToTest.ObCoffee[0].CoffeeName == "Caffe Latte");

        }
    }
}