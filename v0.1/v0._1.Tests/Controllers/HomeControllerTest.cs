using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;

using v0._1.Controllers;

namespace v0._1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            HomeController _testController = GetHomeController();
            string expected = "Server=MYSQL5002.HostBuddy.com;Database=db_9ba681_somee;Uid=9ba681_somee;Pwd=vtufntkrf1;";
            string actual=_testController.GetConnectionString();
            //Assert.Equals(expected, actual);
            Assert.AreEqual(expected, actual, "Строка соеденения не совпадает");
        }

        [TestMethod]
        public void TestGetCount()
        {
            HomeController _testController = new HomeController();
            int i = _testController.GetCount();
            Assert.AreEqual(1, i, "Равно");
        }

        private static HomeController GetHomeController()
        {
            HomeController _controller = new HomeController();
            _controller.ControllerContext = new ControllerContext()
            {
                Controller = _controller,
            };
            return _controller;
        }
    }
}
