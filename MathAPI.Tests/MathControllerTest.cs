using MathAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace MathAPI.Tests
{
    public class MathControllerTest
    {

        [Test]
        public void TestAddRoute()
        {
            //Arrange
            var controller = new MathController();

            //Act
            var result = controller.Add(5, 10);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(15, result.Value);
        }
        
        [Test]
        public void TestAddRouteMissingA()
        {
            //Arrange
            var controller = new MathController();

            //Act
            var result = controller.Add(null, 10);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void TestAddRouteMissingB()
        {
            //Arrange
            var controller = new MathController();

            //Act
            var result = controller.Add(5, null);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void TestMultiplyRoute()
        {
            //Arrange
            var controller = new MathController();

            //Act
            var result = controller.Multiply(5, 10);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(50, result.Value);
        }
    }
}
