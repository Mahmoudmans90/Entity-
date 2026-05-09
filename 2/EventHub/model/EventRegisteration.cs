using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.model
{
    public class EventRegisteration
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int EventId { get; set; }
        public DateTime RegisterationDate { get; set; }
        public Event Event { get; set; }
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }                

    }
}