using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC.Routing
{
    public class RequestContext
    {
        public virtual HttpContextBase HttpContext { get; set; }

        public virtual RouteData RouteData { get; set; }

        public RequestContext()
        {
        }

        public RequestContext(HttpContextBase httpContext,RouteData routeData)
        {
            if(httpContext==null)
            {
                throw new ArgumentNullException("httpContext");
            }
            if(routeData==null)
            {
                throw new ArgumentNullException("routeData");
            }
            HttpContext = httpContext;
            RouteData = routeData;
        }
    }
}