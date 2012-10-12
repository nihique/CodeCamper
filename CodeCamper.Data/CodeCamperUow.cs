using System.Diagnostics;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;
using Ninject;

namespace CodeCamper.Data
{
    public class CodeCamperUow : ICodeCamperUow
    {
        public CodeCamperUow(CodeCamperDbContext context, IKernel kernel)
        {
            Debug.WriteLine("new CodeCamperUow()");
            Context = context;
            Kernel = kernel;
            SetupDbContext();
        }

        // core data
        protected CodeCamperDbContext Context { get; private set; }
        protected IKernel Kernel { get; private set; }

        // default repos
        public IRepository<Room> Rooms           { get { return Kernel.Get<IRepository<Room>>(); } }
        public IRepository<TimeSlot> TimeSlots   { get { return Kernel.Get<IRepository<TimeSlot>>(); } }
        public IRepository<Track> Tracks         { get { return Kernel.Get<IRepository<Track>>(); } }

        // custom repos
        public IAttendanceRepository Attendance  { get { return Kernel.Get<IAttendanceRepository>(); } }
        public IPersonsRepository Persons        { get { return Kernel.Get<IPersonsRepository>(); } }
        public ISessionsRepository Sessions      { get { return Kernel.Get<ISessionsRepository>(); } }

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