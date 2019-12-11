using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SimpleMVC.MVC
{
    public class RawContextResult:ActionResult
    {
        public Action<TextWriter> Callback { get; private set; }

        public RawContextResult(Action<TextWriter>callback)
        {
            this.Callback = callback;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            this.Callback(context.RequestContext.HttpContext.Response.Output);
        }
    }
}