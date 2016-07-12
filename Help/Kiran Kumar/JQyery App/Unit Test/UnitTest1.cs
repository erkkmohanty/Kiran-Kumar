using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JQyery_App.Controllers;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           var result= new HomeController().IsUserExists("kiran.mohanty1992@gmail.com");
        }
    }
}
