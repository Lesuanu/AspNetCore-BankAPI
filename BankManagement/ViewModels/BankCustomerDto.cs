using BankManagement.Infrastructure.Models.BankCustomer;
using System;

namespace BankManagement.ViewModels
{
    public class BankCustomerDto
    {
        public int Id { get; set; }
        public int BankNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public BankCustomerNextOfKin BankCustomerNextOfKin { get; set; } = new();
        public int BankCustomerNextOfKinId { get; set; }
        public Gender Gender { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
        public BankAddress BankAddress { get; set; } = new();
        public int BankAddressId { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
