using NUnit.Framework;

namespace MathAPI.Tests
{
    public class MathHelperTest
    {

        [Test]
        [TestCase(3, 5, 8)]
        [TestCase(500, 300, 800)]
        [TestCase(-3, 50, 47)]
        public void TestAddingNumbers(int a, int b, int expected)
        {
            //Act
            var result = MathHelper.Add(a, b);
            
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(3,5,15)]
        [TestCase(500, 300, 150000)]
        [TestCase(-3,50,-150)]
        public void TestMultiplyingNumbers(int a, int b, int expected)
        {
            //Act
            var result = MathHelper.Multiply(a, b);
            
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
