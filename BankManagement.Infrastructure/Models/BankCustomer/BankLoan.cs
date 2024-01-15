using System;

namespace BankManagement.Infrastructure.Models.BankCustomer
{
    public class BankLoan
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public bool IsAccountViable { get; set; }
        public int BankAccount { get; set; }
       // public Dictionary<string, int> Collateral { get; set; }  // house -  10000
        public int AmountRequested { get; set; }
        public BankCustomerNextOfKin BankCustomerNextOfKin { get; set; } = new();
        public int BankCustomerNextOfKinId { get; set; }
        public DateTime RepaymentDate { get; set; }
        public AccountType AccountType { get; set; } 
        public int InterestOnLoan { get; set; }
        public int BankDeposit { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime LoanDate { get; set; }
    }
}
