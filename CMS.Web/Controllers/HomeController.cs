using CMS.Services.Interfaces;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly ISampleService _sampleService;
        private readonly ISample2Service _sample2Service;
        private readonly ISample3Service _sample3Service;

        public HomeController(ISampleService sampleService, ISample2Service sample2Service, ISample3Service sample3Service)
        {
            this._sampleService = sampleService;
            this._sample2Service = sample2Service;
            this._sample3Service = sample3Service;
        }

        public virtual ActionResult Index()
        {
            var result = _sampleService.FetchAll();
            return View(result);
        }
	}
}