using System.Data.Entity;
using CodeCamper.Data.SampleData;
using CodeCamper.Model;

namespace CodeCamper.Data
{
    public class CodeCamperDbContext : DbContext
    {
        static CodeCamperDbContext()
        {
            Database.SetInitializer(new CodeCamperDatabaseInitializer());
        }

        public CodeCamperDbContext() : base("CodeCamper")
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        // Lookup Lists
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Track> Tracks { get; set; }

    }
}
