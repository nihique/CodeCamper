using System.Data.Entity;
using CodeCamper.Data.Contracts;
using CodeCamper.Data.Ninject;
using CodeCamper.Model;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace CodeCamper.Data
{
    public class CodeCamperDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // TODO: convention binding
            //Kernel.Bind(x => x
            //    .FromThisAssembly()
            //    .SelectAllClasses()
            //    .BindAllInterfaces()
            //    .Configure((c, s) => c.Named(s.Name))
            //);

            // standard binding 
            Bind<DbContext>().To<CodeCamperDbContext>().InRequestOrThreadScope();
            Bind<ICodeCamperUow>().To<CodeCamperUow>().InRequestOrThreadScope();

            Bind<IRepository<Room>>().To<EFRepository<Room>>().InRequestOrThreadScope();
            Bind<ISessionsRepository>().To<SessionsRepository>().InRequestOrThreadScope();
        }
    }
}
