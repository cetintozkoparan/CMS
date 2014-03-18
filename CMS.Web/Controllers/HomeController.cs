using CMS.Services.Interfaces;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly ISampleService _sampleService;

        public HomeController(ISampleService sampleService)
        {
            this._sampleService = sampleService;
        }

        public virtual ActionResult Index()
        {
            var result = _sampleService.FetchAll();
            return View(result);
        }
	}
}