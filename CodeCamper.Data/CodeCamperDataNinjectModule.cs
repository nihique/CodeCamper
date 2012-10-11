using System.Data.Entity;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CodeCamper.Data
{
    public class CodeCamperDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<CodeCamperDbContext>().InRequestScope();
            Bind<ICodeCamperUow>().To<CodeCamperUow>().InThreadScope();

            Bind<IRepository<Room>>().To<EFRepository<Room>>().InRequestScope();
            Bind<ISessionsRepository>().To<SessionsRepository>().InRequestScope();
        }
    }
}
