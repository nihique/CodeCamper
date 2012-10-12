using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace CodeCamper.Data
{
    public class CodeCamperNinjectKernelConfigurator
    {
        private readonly IKernel _kernel;

        public CodeCamperNinjectKernelConfigurator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Configure()
        {
            RegisterServices();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(_kernel));
        }

        private void RegisterServices()
        {
            _kernel.Load<CodeCamperDataNinjectModule>();
        }        
    }
}