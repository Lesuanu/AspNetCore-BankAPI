namespace BankManagement.Infrastructure.Models.BankCustomer
{
    public class BankCustomerNextOfKin
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
       // public BankAddress BankAddress { get; set; } = new BankAddress();
       // public int BankAddressId { get; set; }
        public BankCustomer1 BankCustomer1 { get; set; } = new();
        public BankLoan BankLoan { get; set; } = new BankLoan();
        public int BankLoanId { get; set; }
    }
}