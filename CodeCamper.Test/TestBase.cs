using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using NUnit.Framework;
using Ninject;

namespace CodeCamper.Test
{
    public class TestBase
    {
        protected StandardKernel Kernel { get; set; }
        protected ICodeCamperUow Uow { get { return Kernel.Get<ICodeCamperUow>(); } }

        [SetUp]
        public void SetUp()
        {
            InitializeKernel();
        }

        protected void InitializeKernel()
        {
            Kernel = new StandardKernel();
            Kernel.Load<CodeCamperDataNinjectModule>();
        }
    }
}