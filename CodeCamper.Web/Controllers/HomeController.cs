using System.Web.Mvc;
using CodeCamper.Data.Contracts;

namespace CodeCamper.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ICodeCamperUow uow)
        {
            Uow = uow;
        }

        protected ICodeCamperUow Uow { get; private set; }


        public ActionResult Index()
        {
            var sessions = Uow.Sessions.GetAll();
            return View();
        }
    }
}
