using CodeCamper.Data.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CodeCamper.Data
{
    public class CodeCamperDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICodeCamperUow>().To<CodeCamperUow>().InRequestScope();
        }
    }
}
