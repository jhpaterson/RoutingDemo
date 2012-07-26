using System.Web.Routing;
using System.Web;

namespace RoutingDemo.Infrastructure.CustomConstraints
{
    public class UserAgentConstraint : IRouteConstraint
    {
        private string requiredUserAgent;

        public UserAgentConstraint(string agentParam)
        {
            requiredUserAgent = agentParam;
        }

        #region IRouteConstraint Members

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, 
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.UserAgent.Contains(requiredUserAgent);
        }

        #endregion
    }
}