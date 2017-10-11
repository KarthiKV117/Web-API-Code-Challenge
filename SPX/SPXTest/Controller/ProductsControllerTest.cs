using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPX.Controllers;
using System.Collections.Generic;
using SPX;
using SPX.Models;

namespace SPXTest
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            //Arrange
            ProductsController controller = new ProductsController();

            IEnumerable<Product> listProducts = controller.Get();

            // Assert
            Assert.IsNotNull(listProducts);
        }

        [TestMethod]
        public void GetReview()
        {
            //Arrange
            ProductsController controller = new ProductsController();

            List<ProductVM> listProducts = controller.Get(3);

            // Assert
            Assert.IsNotNull(listProducts);
        }

    }
}
