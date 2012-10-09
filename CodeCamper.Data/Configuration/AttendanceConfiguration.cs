using System.Data.Entity.ModelConfiguration;
using CodeCamper.Model;

namespace CodeCamper.Data.Configuration
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            // Many to Many table => composite key
            HasKey(a => new { a.SessionId, a.PersonId });

            // Attendance has 1 Session;
            // Sessions has many Attendances
            HasRequired(a => a.Session)
                .WithMany(s => s.AttendanceList)
                .HasForeignKey(a => a.SessionId)
                .WillCascadeOnDelete(false);

            // Attendance has 1 Person;
            // Persons has many Attendances
            HasRequired(a => a.Person)
                .WithMany(p => p.AttendanceList)
                .HasForeignKey(a => a.SessionId)
                .WillCascadeOnDelete(false);
        }
    }
}