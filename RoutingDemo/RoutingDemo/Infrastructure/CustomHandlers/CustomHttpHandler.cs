using System;
using System.Web;

namespace RoutingDemo.Infrastructure.CustomHandlers
{
    public class CustomHttpHandler : IHttpHandler
    {

        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<html>Hello world!</html>");
        }

        #endregion
    }
}
