using System.Configuration;
using System.Web.Mvc;
using MosquitoLab.Application.Common.Services.Interfaces;
using MosquitoLab.Domain.Accounts.Filters;
using MosquitoLab.WingBank.Helpers;

namespace MosquitoLab.WingBank.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAdvancedSearchAppService _appService;

        public SearchController(IAdvancedSearchAppService appService)
        {
            _appService = appService;
        }

        // GET: Search
        public ActionResult Index()
        {
            //var model = _appService.GetAdancedSearchFilters();
            ViewBag.GoogleMapsKey = ConfigurationManager.AppSettings["GoogleMapsKey"];
            return View();
        }

        public JsonResultHelper GetDatabaseInfo()
        {
            var result = _appService.GetDatabaseInfo();
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper GetFamlies()
        {
            var result = _appService.GetFamlies();
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper GetSubfamilies(AdancedSearchFilter filter)
        {
            var result = _appService.GetSubfamilies(filter);
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper GetTribes(AdancedSearchFilter filter)
        {
            var result = _appService.GetTribes(filter);
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper GetSpecies(AdancedSearchFilter filter)
        {
            var result = _appService.GetSpecies(filter);
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper GetSubspecies(AdancedSearchFilter filter)
        {
            var result = _appService.GetSubspecies(filter);
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper GetGenus(AdancedSearchFilter filter)
        {
            var result = _appService.GetGenus(filter);
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper GetSubgenus(AdancedSearchFilter filter)
        {
            var result = _appService.GetSubgenus(filter);
            return new JsonResultHelper(result, JsonRequestBehavior.AllowGet);
        }
    }
}