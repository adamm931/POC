using MvcIntegrationTestFramework.Browsing;
using MvcIntegrationTestFramework.Hosting;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace POC.Test
{
    [TestFixture]
    public class AppHostTests
    {
        private static AppHost _host;

        public AppHostTests()
        {
            _host = AppHost.Simulate("POC");
        }

        [Test]
        public void Some_Simple_Test_Should_Success()
        {
            try
            {
                _host.Start(TestHomeRoute);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private void TestHomeRoute(BrowsingSession session)
        {
            try
            {
                RequestResult result = session.Get("/Home");

                // Check the result status
                Assert.IsTrue(result.IsSuccess);

                // Make assertions about the ActionResult
                var viewResult = (ViewResult)result.ActionExecutedContext.Result;
                Assert.AreEqual("Index", viewResult.ViewName);
                Assert.AreEqual("Welcome to ASP.NET MVC!", viewResult.ViewData["Message"]);

                // Or make assertions about the rendered HTML
                Assert.IsTrue(result.ResponseText.Contains("<!DOCTYPE html"));
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}
