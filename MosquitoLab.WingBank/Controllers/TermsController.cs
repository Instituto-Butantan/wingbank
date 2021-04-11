using System.Web.Mvc;

namespace MosquitoLab.WingBank.Controllers
{
    public class TermsController : Controller
    {
        // GET: Terms
        public ActionResult Index()
        {
            return View();
        }

        // GET: Terms
        public PartialViewResult Partial()
        {
            return PartialView(@"Index");
        }

    }
}