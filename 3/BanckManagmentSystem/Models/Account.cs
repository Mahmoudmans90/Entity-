using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanckManagmentSystem.Enums;

namespace BanckManagmentSystem.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = null!;
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public OwnerShipRole OwnerShipRole { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();
        public ICollection<BankTransaction> Transactions { get; set; } = new List<BankTransaction>();
    }
}