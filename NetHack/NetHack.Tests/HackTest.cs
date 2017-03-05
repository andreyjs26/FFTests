using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetHack.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHack.Tests
{
    [TestClass]
    public class HackTest
    {
        [TestMethod]
        public void test1()
        {

            // Arrange
            NetHackController controller = new NetHackController();
            String[] expected = new String[] { "..B....", "<...>..", "......>", "......." };

            // Act
            String[] result = controller.explode("..B....", 2);

            // Assert
            CollectionAssert.AreEqual(expected, result);

        }

        [TestMethod]
        public void test2()
        {

            // Arrange
            NetHackController controller = new NetHackController();
            String[] expected = new String[] {"..B.B..B","........" };

            // Act
            String[] result = controller.explode("..B.B..B", 10);

            // Assert
            CollectionAssert.AreEqual(expected, result);

        }

        [TestMethod]
        public void test3()
        {

            // Arrange
            NetHackController controller = new NetHackController();
            String[] expected = new String[] {"B.B.B.BB.","<.X.X<>.>","<.<<>.>.>","<<....>.>","........>","........." };

            // Act
            String[] result = controller.explode("B.B.B.BB.", 2);

            // Assert
            CollectionAssert.AreEqual(expected, result);

        }


        [TestMethod]
        public void test4()
        {

            // Arrange
            NetHackController controller = new NetHackController();
            String[] expected = new String[] { "..B.B..B", ".<.X.><.", "<.<.><>.", ".<..<>.>", "<..<..>.", "..<....>", ".<......", "<.......", "........" };

            // Act
            String[] result = controller.explode("..B.B..B", 1);

            // Assert
            CollectionAssert.AreEqual(expected, result);

        }

         [TestMethod]
        public void test5()
        {

            // Arrange
            NetHackController controller = new NetHackController();
            String[] expected = new String[] {"..B.BB..B.B..B...",".<.X<>><.X.><.>..","<.<<>.X><.><>..>.",".<<..X.X>.<>.>..>","<<..<.X.>X..>.>..","<..<.<.><>>..>.>.","..<.<..<>.>>..>.>",".<.<..<..>.>>..>.","<.<..<....>.>>..>",".<..<......>.>>..","<..<........>.>>.","..<..........>.>>",".<............>.>","<..............>.","................>","................."};

            // Act
            String[] result = controller.explode("..B.BB..B.B..B...", 1);

            // Assert
            CollectionAssert.AreEqual(expected, result);

        }
    }
}
