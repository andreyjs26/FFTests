using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorLibrary;
using VendorLibrary.Controllers;

namespace VendorLibrary.Tests.Controllers
{
    [TestClass]
    public class VendorControllerTest
    {
        [TestMethod]
        public void test1()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            int result = controller.getSoldQuantity("1/31/2017");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(320, result);                  
        }

        [TestMethod]
        public void test2()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            int result = controller.getSoldQuantity("1/25/2017");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void test3()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            int result = controller.getSoldQuantityPerItem("1/31/2017","chips");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(110, result);
        }


        [TestMethod]
        public void test4()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            int result = controller.getSoldQuantityPerItem("1/29/2017", "cola soda");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }
        

        [TestMethod]
        public void test5()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            List<string> result = controller.getMostSoldItems("1/31/2017");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }


        [TestMethod]
        public void test6()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            List<string> result = controller.getMostSoldItems("1/27/2017");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }


        [TestMethod]
        public void test7()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            List<string> result = controller.getMostSoldDates("cola soda");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void test8()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            List<string> result = controller.getMostSoldDates("cream cookie");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void test9()
        {
            // Arrange
            VendorController controller = new VendorController();

            // Act
            List<string> result = controller.getMostSoldDates("chocolate");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }


    }
}
