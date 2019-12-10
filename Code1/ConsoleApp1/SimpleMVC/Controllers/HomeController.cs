using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC.Controllers
{
    public class HomeController:ControllerBase
    {
        public ActionResult Index(SimpleModel model)
        {
            Action<TestWriter> callback=d=>
            {
            }
        }
    }
}