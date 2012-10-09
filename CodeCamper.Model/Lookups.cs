using System.Collections.Generic;

namespace CodeCamper.Model
{
    public class Lookups
    {
        public ICollection<Room> Rooms { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}