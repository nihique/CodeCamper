using System;

namespace CodeCamper.Model
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public bool IsSessionSlot { get; set; }
    }
}