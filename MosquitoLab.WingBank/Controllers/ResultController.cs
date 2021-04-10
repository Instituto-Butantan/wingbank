using System.Web.Mvc;
using MosquitoLab.Application.Individuals.Services.Interfaces;
using MosquitoLab.Domain.Individuals.Filters;
using MosquitoLab.Domain.Individuals.Repositories;
using MosquitoLab.WingBank.Helpers;

namespace MosquitoLab.WingBank.Controllers
{
    public class ResultController : Controller
    {
        private readonly IWingImageAppService _appService;
        private readonly IWingImageRepository _wingImageRepository;

        public ResultController(IWingImageAppService appService, IWingImageRepository wingImageRepository)
        {
            _appService = appService;
            _wingImageRepository = wingImageRepository;
        }

        // GET: Result
        public ActionResult Index(WingFilter filter = null)
        {
            var wings = _wingImageRepository.Find(filter);
            return View(wings);
        }

        public JsonResultHelper Find(WingFilter filter = null)
        {
            var wings = _wingImageRepository.Find(filter);
            return new JsonResultHelper(wings, JsonRequestBehavior.AllowGet);
        }

        public JsonResultHelper ByIds(string wingsIds)
        {
            var wings = _wingImageRepository.GetByIds(wingsIds);
            return new JsonResultHelper(wings, JsonRequestBehavior.AllowGet);
        }
    }
}