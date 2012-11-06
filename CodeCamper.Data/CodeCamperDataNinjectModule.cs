using System.Data.Entity;
using CodeCamper.Data.Contracts;
using CodeCamper.Data.Ninject;
using CodeCamper.Data.Repositories;
using CodeCamper.Model;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace CodeCamper.Data
{
    public class CodeCamperDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // standard binding 

            // core data
            Bind<DbContext>().To<CodeCamperDbContext>().InRequestOrThreadScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestOrThreadScope();

            // default repos
            Bind<IRepository<Room>>().To<EFRepository<Room>>().InRequestOrThreadScope();
            Bind<IRepository<TimeSlot>>().To<EFRepository<TimeSlot>>().InRequestOrThreadScope();
            Bind<IRepository<Track>>().To<EFRepository<Track>>().InRequestOrThreadScope();

            // custom repos
            Bind<IAttendanceRepository>().To<AttendanceRepository>().InRequestOrThreadScope();
            Bind<IPersonsRepository>().To<PersonsRepository>().InRequestOrThreadScope();
            Bind<ISessionsRepository>().To<SessionsRepository>().InRequestOrThreadScope();


            // TODO: try to use convention binding at least for pairs IType/Type
            //Kernel.Bind(x => x
            //    .FromThisAssembly()
            //    .SelectAllClasses()
            //    .BindAllInterfaces()
            //    .Configure((c, s) => c.Named(s.Name))
            //);

        }
    }
}
