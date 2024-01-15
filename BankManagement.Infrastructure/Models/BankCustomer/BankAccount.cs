using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Models.BankCustomer
{
    public class BankAccount
    {
        public int Id { get; set; }
        public Guid BankNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int AmountDeposited { get; set; }
        public AccountType AccountType { get; set; }
    }
}
