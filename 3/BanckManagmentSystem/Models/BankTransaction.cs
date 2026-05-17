using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanckManagmentSystem.Enums;

namespace BanckManagmentSystem.Models
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = null!;
    }
}