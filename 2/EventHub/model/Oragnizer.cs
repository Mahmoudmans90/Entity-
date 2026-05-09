using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.model
{
    public class Oragnizer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? CompanyName { get; set; }
        public bool IsVerified { get; set; }

        public OrgnizerProfile? OrgnizerProfile { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}