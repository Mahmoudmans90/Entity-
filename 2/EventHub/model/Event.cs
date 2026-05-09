using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.model
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxAttendees { get; set; }
        public int? ParentId { get; set; }
        public Event Parent { get; set; }
        public ICollection<Event> SubEvents { get; set; } = new List<Event>();

        public int? OrganizerId { get; set; }
        public Oragnizer Organizer { get; set; }
        public ICollection<EventRegisteration> EventRegisterations { get; set; } = new List<EventRegisteration>();
        
        
    }
}