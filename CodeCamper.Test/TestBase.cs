using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using NUnit.Framework;
using Ninject;

namespace CodeCamper.Test
{
    public class TestBase
    {
        protected StandardKernel Kernel { get; set; }
        protected IUnitOfWork Uow { get { return Kernel.Get<IUnitOfWork>(); } }

        [SetUp]
        public void SetUp()
        {
            InitializeKernel();
        }

        protected void InitializeKernel()
        {
            var kernel = new StandardKernel();
            new CodeCamperNinjectKernelConfigurator(kernel).Configure();
            Kernel = kernel;
        }
    }
}