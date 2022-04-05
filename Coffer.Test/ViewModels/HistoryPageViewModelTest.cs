using System;
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
    public class HistoryPageViewModelTest
    {
        [Test]
        public async Task InitializeShouldHaveHistories()
        {
            var mock = AutoMock.GetStrict();
            mock.Mock<IHistoryService>().Setup(method => method.GetHistoriesAsync())
                .ReturnsAsync(new List<History>
                {
                    new History
                    {
                        Id = 1,
                        ContentId = 1,
                        Datetime = DateTime.Now,
                        CoffeeName = "Caffe Latte",
                        Count = 1,
                        Size = "Grande (470ml)",
                        BrandName = "Starbucks",
                        TotalCaffeine = 150
                    }
                });

            var viewmodelToTest = mock.Create<HistoryPageViewModel>();

            await viewmodelToTest.LoadHistories();
            
            Assert.IsTrue(viewmodelToTest.ObHistories[0].TotalCaffeine == 150);

        }
    }
}