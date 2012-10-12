using System.Web.Http;
using CodeCamper.Data.Contracts;

namespace CodeCamper.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ApiControllerBase(ICodeCamperUow uow)
        {
            Uow = uow;
        }

        protected ICodeCamperUow Uow { get; private set; }
    }
}