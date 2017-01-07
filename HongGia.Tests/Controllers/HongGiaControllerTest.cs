using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HongGia.Controllers;
using System.Web.Mvc;

namespace HongGia.Tests.Controllers
{
    [TestClass]
    public class HongGiaControllerTest
    {
        [TestMethod]
        public void About()
        {
            // Arrange
            HongGiaController controller = new HongGiaController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void History()
        {
            // Arrange
            HongGiaController controller = new HongGiaController();

            // Act
            ViewResult result = controller.History() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Levels()
        {
            // Arrange
            HongGiaController controller = new HongGiaController();

            // Act
            ViewResult result = controller.Levels() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ToBeginner()
        {
            // Arrange
            HongGiaController controller = new HongGiaController();

            // Act
            ViewResult result = controller.ToBeginner() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Program()
        {
            // Arrange
            HongGiaController controller = new HongGiaController();

            // Act
            ViewResult result = controller.Program() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
