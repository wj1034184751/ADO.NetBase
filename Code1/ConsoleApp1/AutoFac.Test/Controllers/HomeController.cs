using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoFac.Test.Models;
using Autofac;
using AutoFac.Test.AutoFacModel;
using AutoFac.Test.Job;

namespace AutoFac.Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateWriter _dataWrite;
        private readonly IOutput _output;
        private readonly ConsoleOutPut _consoleOutPut;

        public HomeController(IDateWriter dataWrite,
                              IOutput output)
        {
            this._dataWrite = dataWrite;
            this._output = output;
        }
        public IActionResult Index()
        {
            TestTask job = new TestTask();
            job.StartTestAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
