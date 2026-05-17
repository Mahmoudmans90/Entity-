using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanckManagmentSystem.Enums;

namespace BanckManagmentSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string NationalId { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;
        public CustomerType CustomerType { get; set; }
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();
    
    }
}