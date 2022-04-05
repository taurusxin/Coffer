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
    public class CoffeeDetailPageViewModelTest
    {
        [Test]
        public async Task InitializeShouldHaveContents()
        {
            var mock = AutoMock.GetStrict();
            mock.Mock<IContentService>().Setup(method => method.GetContentAsync(1))
                .ReturnsAsync(new List<Content>
                {
                    new Content()
                    {
                        Id = 1,
                        CoffeeId = 1,
                        SizeName = "Grande (470ml)",
                        Caffeine = 150
                    }
                });

            var viewmodelToTest = mock.Create<CoffeeDetailPageViewModel>();

            await viewmodelToTest.LoadContent(new Coffee
            {
                Id = 1
            });
            
            Assert.IsTrue(viewmodelToTest.ObContent[0].Caffeine == 150);

        }
    }
}