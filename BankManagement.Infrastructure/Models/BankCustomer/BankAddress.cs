namespace BankManagement.Infrastructure.Models.BankCustomer
{
    public class BankAddress
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
       // public BankCustomerNextOfKin BankCustomerNextOfKin { get; set; } = new();
        public BankCustomer1 BankCustomer1 { get; set; } = new();
    }
}