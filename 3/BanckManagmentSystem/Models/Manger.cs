using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanckManagmentSystem.Models
{
    public class Manger
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Branch? Branch { get; set; }
        public DateTime HireDate { get; set; }
    }
}