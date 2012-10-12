using System.Data.Entity;
using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;
using NUnit.Framework;
using Ninject;

namespace CodeCamper.Test
{
    [TestFixture]
    public class IocTest : TestBase
    {
        [Test]
        public void CanGetInstancesViaIoc()
        {
            // core data
            Assert.NotNull(Kernel.Get<DbContext>() as CodeCamperDbContext);
            Assert.NotNull(Kernel.Get<IUnitOfWork>() as UnitOfWork);

            // default repos
            Assert.NotNull(Kernel.Get<IRepository<Room>>() as EFRepository<Room>);
            Assert.NotNull(Kernel.Get<IRepository<TimeSlot>>() as EFRepository<TimeSlot>);
            Assert.NotNull(Kernel.Get<IRepository<Track>>() as EFRepository<Track>);

            // custom repos
            Assert.NotNull(Kernel.Get<IAttendanceRepository>() as AttendanceRepository);
            Assert.NotNull(Kernel.Get<IPersonsRepository>() as PersonsRepository);
            Assert.NotNull(Kernel.Get<ISessionsRepository>() as SessionsRepository);
        }
    }
}
