using System;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;
using Ninject;

namespace CodeCamper.Data
{
    public class CodeCamperUow : ICodeCamperUow
    {
        public CodeCamperUow(CodeCamperDbContext context, IKernel kernel)
        {
            Console.WriteLine("CodeCamperUow ctor");
            Context = context;
            Kernel = kernel;
        }

        protected CodeCamperDbContext Context { get; private set; }
        protected IKernel Kernel { get; private set; }

        public IPersonsRepository Persons        { get { return Kernel.Get<IPersonsRepository>(); } }
        public IRepository<Room> Rooms           { get { return Kernel.Get<IRepository<Room>>(); } }
        public ISessionsRepository Sessions      { get { return Kernel.Get<ISessionsRepository>(); } }
        public IRepository<TimeSlot> TimeSlots   { get { return Kernel.Get<IRepository<TimeSlot>>(); } }
        public IRepository<Track> Tracks         { get { return Kernel.Get<IRepository<Track>>(); } }
        public IAttendanceRepository Attendance  { get { return Kernel.Get<AttendanceRepository>(); } }

        public void Commit()
        {
            Context.SaveChanges();
        }

    }
}