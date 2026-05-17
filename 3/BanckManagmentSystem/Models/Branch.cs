using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanckManagmentSystem.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string BranchCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        public int managerId { get; set; }
        public Manger? Manger { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>(); 
    }
}