using System;

namespace BankManagement.Infrastructure.Models.BankCustomer.Accounts
{
    public class SavingsAccount
    {
        public int Id { get; set; }
        public int WithdrawalLimit { get; set; }
        public int LoanLimit { get; set; }
        public int Interest { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime DateClosed { get; set; }
        public string BankEmployeeName { get; set; }
    }
}
