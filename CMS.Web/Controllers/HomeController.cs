using CMS.Services.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISampleService _sampleService;
        private readonly ISampleService2 _sampleService2;
        [InjectionConstructor]
        public HomeController(ISampleService sampleService, ISampleService2 sampleService2)
        {
            this._sampleService = sampleService;
            this._sampleService2 = sampleService2;
        }

        public ActionResult Index()
        {
            var result = _sampleService.FetchAll();
            var result2 = _sampleService2.FetchAll();
            return View(result);
        }
	}
}