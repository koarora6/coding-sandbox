using Xunit;
using SimpleUnitTestingApp.Models;
using SimpleUnitTestingApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;

namespace SimpleUnitTestingApp.Tests
{
    public class HomeControllerTests
    {
        //class FakeDataSource : IDataSource
        //{
        //    public FakeDataSource(Product[] data)
        //        => Products = data;

        //    public IEnumerable<Product> Products { get; set; }
        //}

        [Fact]
        public void IndexActionModelIsComplete()
        {
            //Arrange
            Product[] testData = new Product[]
            {
                new Product{Name = "P1", Price = 275M},
                new Product{Name = "P2", Price = 48.95M},
                new Product{Name = "P3", Price = 11.95M}
            };

            //IDataSource data = new FakeDataSource(testData);

            //create a new instance of the mock object, specifying
            //the interface it should implement
            var mock = new Mock<IDataSource>();

            //user SetupGet to create implementation of the Product property
            mock.SetupGet(m => m.Products).Returns(testData);
            
            var controller = new HomeController();
            controller.dataSource = mock.Object;

            //Act
            var model = (controller.Index() as ViewResult)?
                        .ViewData
                        .Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(testData, model,
            Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
            && p1.Price == p2.Price));
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
