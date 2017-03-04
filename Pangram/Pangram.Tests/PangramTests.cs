using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pangram.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangram.Tests
{
    [TestClass]
    public class PangramTests
    {
        [TestMethod]
        public void test1()
        {

            // Arrange
            PangramController controller = new PangramController();

            // Act
            string result = controller.listMissingLetter("A quick brown fox jumps over the lazy dog");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result); 
        }

        [TestMethod]
        public void test2()
        {

            // Arrange
            PangramController controller = new PangramController();

            // Act
            string result = controller.listMissingLetter("Four score and seven years ago.");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("bhijklmpqtwxz", result);
        }

        [TestMethod]
        public void test3()
        {

            // Arrange
            PangramController controller = new PangramController();

            // Act
            string result = controller.listMissingLetter("To be or not to be, that is the question!");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("cdfgjklmpvwxyz", result);
        }

        [TestMethod]
        public void test4()
        {

            // Arrange
            PangramController controller = new PangramController();

            // Act
            string result = controller.listMissingLetter("");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", result);
        }



    }
}
