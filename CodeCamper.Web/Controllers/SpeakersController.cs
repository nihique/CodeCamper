using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Web.Controllers
{
    public class SpeakersController : ApiControllerBase
    {
        public SpeakersController(ICodeCamperUow uow) : base(uow)
        {
        }

        // GET api/speakers
        public IEnumerable<Speaker> Get()
        {
            return Uow.Persons.GetSpeakers().OrderBy(s => s.LastName);
        }

        // GET api/speakers/5
        public Speaker Get(int id)
        {
            return new Speaker();
        }

        // POST api/speakers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/speakers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/speakers/5
        public void Delete(int id)
        {
        }
    }
}
