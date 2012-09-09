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
    public class OutgoingRoutesTest
    {
        [TestMethod]
        public void HomeControllerAndIndexActionRoutesToDefaultUrl()
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            var httpContextMock = GetMockHttpContext();

            RouteData routeData = new RouteData();
            RequestContext context = new RequestContext(httpContextMock.Object, routeData);

            // Act
            string result = UrlHelper.GenerateUrl("Default", "Index", "Home", null,
                routes, context, true);

            // Assert
            Assert.AreEqual("/", result, "Expected a different url");
        }

        [TestMethod]
        public void SearchControllerAndIndexActionRoutesToSearchUrl()
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            var httpContextMock = GetMockHttpContext();  

            RouteData routeData = new RouteData();
            RequestContext context = new RequestContext(httpContextMock.Object, routeData);

            // Act
            string result = UrlHelper.GenerateUrl("Search", "Index", "Search", 
                null,routes, context, true);

            // Assert
            Assert.AreEqual("/search", result, "Expected a different url");
        }

        // Helper method - could be in separate class 
        private static Mock<HttpContextBase> GetMockHttpContext()
        {
            var httpContextMock = new Mock<HttpContextBase>();

            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns<string>(null);
            httpContextMock.Setup(c => c.Request.HttpMethod)
                .Returns("GET");
            httpContextMock.Setup(c => c.Response.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns<string>(s => s);
            return httpContextMock;
        }
    }
}
