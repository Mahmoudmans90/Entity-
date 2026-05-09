using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.model
{
    public class Attendee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Address Address {get;set;}

        public Badge Badge {get;set;}
        public ICollection<EventRegisteration> EventRegisterations {get;set;} = new List<EventRegisteration>();
    }
}