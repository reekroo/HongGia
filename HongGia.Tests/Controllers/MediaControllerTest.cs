using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HongGia.Controllers;
using System.Web.Mvc;

namespace HongGia.Tests.Controllers
{
    [TestClass]
    public class MediaControllerTest
    {
        [TestMethod]
        public void Articles()
        {
            // Arrange
            MediaController controller = new MediaController();

            // Act
            ViewResult result = controller.Articles() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void Books()
        //{
        //    // Arrange
        //    MediaController controller = new MediaController();

        //    // Act
        //    ViewResult result = controller.Books() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void Video()
        //{
        //    // Arrange
        //    MediaController controller = new MediaController();

        //    // Act
        //    ViewResult result = controller.Video() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
