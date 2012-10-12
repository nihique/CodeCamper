using System.Diagnostics;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;
using Microsoft.Practices.ServiceLocation;

namespace CodeCamper.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(CodeCamperDbContext context)
        {
            Debug.WriteLine("new UnitOfWork()");
            Context = context;
            ServiceLocator = Microsoft.Practices.ServiceLocation.ServiceLocator.Current;
            SetupDbContext();
        }

        // default repos
        public IRepository<Room> Rooms           { get { return ServiceLocator.GetInstance<IRepository<Room>>(); } }
        public IRepository<TimeSlot> TimeSlots   { get { return ServiceLocator.GetInstance<IRepository<TimeSlot>>(); } }
        public IRepository<Track> Tracks         { get { return ServiceLocator.GetInstance<IRepository<Track>>(); } }

        // custom repos
        public IAttendanceRepository Attendance  { get { return ServiceLocator.GetInstance<IAttendanceRepository>(); } }
        public IPersonsRepository Persons        { get { return ServiceLocator.GetInstance<IPersonsRepository>(); } }
        public ISessionsRepository Sessions      { get { return ServiceLocator.GetInstance<ISessionsRepository>(); } }

        // service locator
        protected IServiceLocator ServiceLocator { get; set; }

        // core data
        protected CodeCamperDbContext Context { get; private set; }

        public void Commit()
        {
            Context.SaveChanges();
        }

        private void SetupDbContext()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            Context.Configuration.LazyLoadingEnabled = false;
            Context.Configuration.ValidateOnSaveEnabled = false;
        }

    }
}