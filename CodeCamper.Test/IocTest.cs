using System;
using System.Linq;
using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using NUnit.Framework;
using Ninject;

namespace CodeCamper.Test
{
    [TestFixture]
    public class IocTest
    {
        protected StandardKernel Kernel { get; set; }
        protected ICodeCamperUow Uow { get { return Kernel.Get<ICodeCamperUow>(); } }

        [SetUp]
        public void SetUp()
        {
            InitializeKernel();
        }

        [Test]
        public void CanGetUowInstance()
        {
            var uow = Kernel.Get<ICodeCamperUow>();
            Assert.NotNull(uow);
        }

        [Test]
        public void CanGetAllSessionsAndRooms()
        {
            var sessionsRepo = Uow.Sessions;
            Assert.IsNotNull(sessionsRepo);

            Console.WriteLine(DateTime.Now);
            var sessions = sessionsRepo.GetAll().ToList();
            Assert.NotNull(sessions);

            Console.WriteLine(DateTime.Now);
            var roomsRepo = Uow.Rooms;
            Assert.IsNotNull(roomsRepo);

            Console.WriteLine(DateTime.Now);
            var rooms = roomsRepo.GetAll().ToList();
            Assert.NotNull(rooms);

            Console.WriteLine(DateTime.Now);
        }

        protected void InitializeKernel()
        {
            Kernel = new StandardKernel();
            Kernel.Load<CodeCamperDataNinjectModule>();
        }

    }
}
