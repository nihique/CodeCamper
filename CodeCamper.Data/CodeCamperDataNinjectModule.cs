using System.Data.Entity;
using CodeCamper.Data.Contracts;
using CodeCamper.Data.Ninject;
using CodeCamper.Model;
using Ninject.Modules;

namespace CodeCamper.Data
{
    public class CodeCamperDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<CodeCamperDbContext>().InRequestFallbackScope();
            Bind<ICodeCamperUow>().To<CodeCamperUow>().InRequestFallbackScope();

            Bind<IRepository<Room>>().To<EFRepository<Room>>().InRequestFallbackScope();
            Bind<ISessionsRepository>().To<SessionsRepository>().InRequestFallbackScope();
        }
    }
}
