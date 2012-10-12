using System.Web.Http;
using CodeCamper.Data.Contracts;

namespace CodeCamper.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ApiControllerBase(IUnitOfWork uow)
        {
            Uow = uow;
        }

        protected IUnitOfWork Uow { get; private set; }
    }
}