using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC.MVC
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(ControllerContext context);
    }
}