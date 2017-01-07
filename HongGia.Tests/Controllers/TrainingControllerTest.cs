using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HongGia.Controllers;
using System.Web.Mvc;

namespace HongGia.Tests.Controllers
{
    [TestClass]
    public class TrainingControllerTest
    {
        [TestMethod]
        public void Groups()
        {
            // Arrange
            TrainingController controller = new TrainingController();

            // Act
            ViewResult result = controller.Groups() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Online()
        {
            // Arrange
            TrainingController controller = new TrainingController();

            // Act
            ViewResult result = controller.Online() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Seminars()
        {
            // Arrange
            TrainingController controller = new TrainingController();

            // Act
            ViewResult result = controller.Seminars() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
