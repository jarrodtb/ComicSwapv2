﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComicSwapv2;
using ComicSwapv2.Controllers;
using ComicSwapv2;

namespace ComicSwapv2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GreaterThanTest()
        {
            int small = 1;
            int large = 100;
            bool result = ComicSwapv2.Logic.Comparator.GreaterThan(large, small);
            bool answer = true;
            Assert.AreEqual(answer, result);

            
            result = ComicSwapv2.Logic.Comparator.GreaterThan(small, large);
            answer = false;
            Assert.AreEqual(answer, result);
            
        }
    }
}
