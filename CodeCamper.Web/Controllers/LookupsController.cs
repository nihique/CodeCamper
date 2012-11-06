using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Web.Controllers
{
    public class LookupsController : ApiControllerBase
    {
        public LookupsController(IUnitOfWork uow) : base(uow)
        {
        }

        // GET api/lookups
        public Lookups Get()
        {
            var lookups = new Lookups
                {
                    Rooms = GetRooms().ToList(),
                    TimeSlots = GetTimeSlots().ToList(),
                    Tracks = GetTracks().ToList(),
                };
            return lookups;
        }

        // GET api/lookups/rooms
        [ActionName("rooms")]
        public IEnumerable<Room> GetRooms()
        {
            return Uow.Rooms.GetAll().OrderBy(x => x.Name);
        }

        // GET api/lookups/timeslots
        [ActionName("timeslots")]
        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            return Uow.TimeSlots.GetAll().OrderBy(x => x.Start);
        }

        // GET api/lookups/tracks
        [ActionName("tracks")]
        public IEnumerable<Track> GetTracks()
        {
            return Uow.Tracks.GetAll().OrderBy(x => x.Name);
        }

        // GET api/lookups/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/lookups
        public void Post([FromBody]string value)
        {
        }

        // PUT api/lookups/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/lookups/5
        public void Delete(int id)
        {
        }
    }
}
