using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.model
{
    public class OrgnizerProfile
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Bio { get; set; }
        [MaxLength(200)]
        public string Website { get; set; }
        [MaxLength(200)]
        public string Logo { get; set; }
        public int OrganizerId { get; set; }
        public Oragnizer Organizer { get; set; }
    }
}