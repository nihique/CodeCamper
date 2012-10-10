using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Data
{
    public class CodeCamperUow : ICodeCamperUow
    {
        public CodeCamperUow(CodeCamperDbContext context)
        {
            Context = context;
        }

        protected CodeCamperDbContext Context { get; private set; }

        public IPersonsRepository Persons { get; private set; }
        public IRepository<Room> Rooms { get; private set; }
        public ISessionsRepository Sessions { get; private set; }
        public IRepository<TimeSlot> TimeSlots { get; private set; }
        public IRepository<Track> Tracks { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }

        public void Commit()
        {
            Context.SaveChanges();
        }

    }
}