using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanckManagmentSystem.Enums;

namespace BanckManagmentSystem.Models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public OwnerShipRole OwnerShipRole { get; set; }
    }
}