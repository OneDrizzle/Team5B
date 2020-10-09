using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgengry;

namespace MorgenGryTest
{

    [TestClass]
    public class UnitTest2
    {
        Book b1, b2, b3;
        Amulet a1, a2, a3;

        [TestInitialize]
        public void Init()
        {
            // Arrange

            b1 = new Book("1");
            b2 = new Book("2", "Falling in Love with Yourself");
            b3 = new Book("3", "Spirits in the Night", 123.55);

            a1 = new Amulet("11");
            a2 = new Amulet("12", Level.high);
            a3 = new Amulet("13", Level.low, "Capricorn");
        }

        [TestMethod]
        public void TestGetValueForBook1()
        {
            // Assert
            Assert.AreEqual(0.0, Utility.GetValueOfBook(b1));
        }
        [TestMethod]
        public void TestGetValueForBook2()
        {
            // Assert
            Assert.AreEqual(0.0, Utility.GetValueOfBook(b2));
        }
        [TestMethod]
        public void TestGetValueForBook3()
        {
            // Assert
            Assert.AreEqual(123.55, Utility.GetValueOfBook(b3));
        }

        [TestMethod]
        public void TestGetValueForAmulet1()
        {
            // Assert
            Assert.AreEqual(20.0, Utility.GetValueOfAmulet(a1));
        }
        [TestMethod]
        public void TestGetValueForAmulet2()
        {
            // Assert
            Assert.AreEqual(27.5, Utility.GetValueOfAmulet(a2));
        }
        [TestMethod]
        public void TestGetValueForAmulet3()
        {
            // Assert
            Assert.AreEqual(12.5, Utility.GetValueOfAmulet(a3));
        }
    }



}
