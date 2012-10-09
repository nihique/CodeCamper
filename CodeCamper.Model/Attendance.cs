namespace CodeCamper.Model
{
    public class Attendance
    {
        // Composite key
        public int PersonId { get; set; }
        public int SessionId { get; set; }

        public Session Session { get; set; }
        public Person Person { get; set; }

        public int Rating { get; set; }
        public string Text { get; set; }

    }
}