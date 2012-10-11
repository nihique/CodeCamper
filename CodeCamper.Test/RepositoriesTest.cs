using System.Linq;
using NUnit.Framework;

namespace CodeCamper.Test
{
    public class RepositoriesTest : TestBase
    {
        [Test]
        public void CanGetAllRooms()
        {
            Assert.Greater(Uow.Rooms.GetAll().Count(), 0);
        }

        [Test]
        public void CanGetAllSessions()
        {
            Assert.Greater(Uow.Sessions.GetAll().Count(), 0);
        }

        [Test]
        public void CanGetAllAttendances()
        {
            Assert.Greater(Uow.Attendance.GetAll().Count(), 0);
        }

        [Test]
        public void CanGetAllPersons()
        {
            Assert.Greater(Uow.Persons.GetAll().Count(), 0);
        }

        [Test]
        public void CanGetAllTimeslots()
        {
            Assert.Greater(Uow.TimeSlots.GetAll().Count(), 0);
        }

        [Test]
        public void CanGetAllTracks()
        {
            Assert.Greater(Uow.Tracks.GetAll().Count(), 0);
        }

        [Test]
        public void CanGetAllSpeakers()
        {
            Assert.Greater(Uow.Persons.GetSpeakers().Count(), 0);
        }

        [Test]
        public void CanGetAllTagGroups()
        {
            Assert.Greater(Uow.Sessions.GetTagGroups().Count(), 0);
        }

        [Test]
        public void CanGetAllSessionBriefs()
        {
            Assert.Greater(Uow.Sessions.GetSessionBriefs().Count(), 0);
        }
    }
}