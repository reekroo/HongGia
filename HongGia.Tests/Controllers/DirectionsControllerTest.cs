using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HongGia.Controllers;
using System.Web.Mvc;

namespace HongGia.Tests.Controllers
{
    [TestClass]
    public class DirectionsControllerTest
    {
        [TestMethod]
        public void HongGiaVietnam()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.HongGiaVietnam() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void KungFu()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.KungFu() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ChiKong()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.ChiKong() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TaiChi()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.TaiChi() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WuChi()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.WuChi() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NgaMi()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.NgaMi() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void VinChun()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.VinChun() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PaKua()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.PaKua() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SinI()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.SinI() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BaiMy()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.BaiMy() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FiveEnimals()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.FiveEnimals() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Weapon()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.Weapon() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Meditation()
        {
            // Arrange
            DirectionsController controller = new DirectionsController();

            // Act
            ViewResult result = controller.Meditation() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
