using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.model
{
    public enum BadgeTire
    {
        Standerd=1,
        Vip=2,
    }
    public class Badge
    {
        public int Id { get; set; }
        public BadgeTire Tire { get; set; }
        public string UniqueCode { get; set; }
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}