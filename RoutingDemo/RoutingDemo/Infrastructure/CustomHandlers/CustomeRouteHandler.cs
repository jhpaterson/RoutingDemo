using System.Web.Routing;
using System.Web;

namespace RoutingDemo.Infrastructure.CustomHandlers
{
    public class CustomeRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext context)
        {
            return new CustomHttpHandler();
        }
    }
}