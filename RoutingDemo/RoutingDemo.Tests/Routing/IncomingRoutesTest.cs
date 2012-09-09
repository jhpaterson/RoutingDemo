using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using RoutingDemo;

namespace RoutingDemo.Tests.Routing
{
    [TestClass]
    public class IncomingRoutesTest
    {
        [TestMethod]
        public void DefaultUrlRoutesToHomeControllerAndIndexAction()
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            var httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");

            // Act
            RouteData routeData = routes.GetRouteData(httpContextMock.Object);

            // Assert
            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Home", routeData.Values["Controller"]
                , "Expected a different controller");
            Assert.AreEqual("Index", routeData.Values["action"]
                , "Expected a different action");
        }

        [TestMethod]
        public void SearchUrlRoutesToSearchControllerAndIndexAction()
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            var httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request
                .AppRelativeCurrentExecutionFilePath)
                .Returns("~/search");

            // Act
            RouteData routeData = routes.GetRouteData(httpContextMock.Object);

            // Assert
            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Search", routeData.Values["Controller"]
                , "Expected a different controller");
            Assert.AreEqual("Index", routeData.Values["action"]
                , "Expected a different action");
        }

    }
}
