using System.Linq;
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
            var sessionsRepo = Uow.Sessions;
            var sessions = sessionsRepo.GetAll().ToList();
            var roomsRepo = Uow.Rooms;
            var rooms = roomsRepo.GetAll().ToList();
            return View();
        }
    }
}
