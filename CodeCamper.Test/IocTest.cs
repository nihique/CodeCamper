using System.Linq;
using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;
using NUnit.Framework;
using Ninject;

namespace CodeCamper.Test
{
    [TestFixture]
    public class IocTest
    {
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
        public void CanGetAllSessions()
        {
            IQueryable<Session> sessions = Kernel.Get<ICodeCamperUow>().Sessions.GetAll();
            Assert.NotNull(sessions);
        }

        protected void InitializeKernel()
        {
            Kernel = new StandardKernel();
            Kernel.Load<CodeCamperDataNinjectModule>();
        }

        protected StandardKernel Kernel { get; set; }
    }
}
