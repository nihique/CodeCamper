using System.Collections.Generic;
using System.Linq;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Web.Controllers
{
    public class SpeakersController : ApiControllerBase
    {
        public SpeakersController(IUnitOfWork uow) : base(uow)
        {
        }

        // GET api/speakers
        public IEnumerable<Speaker> Get()
        {
            return Uow.Persons.GetSpeakers().OrderBy(s => s.LastName);
        }
    }
}
