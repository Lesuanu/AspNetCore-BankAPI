using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace BankManagement.Infrastructure.Models.BankEmployee
{
    public class BankEmployee1
    {
        public int BankEmployee1Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateEmployed { get; set; } = DateTime.Now;
        public DateTime DatePromoted { get; set; } = DateTime.Now;
        public EmployeeDepartment EmployeeDepartment { get; set; }
        public BankEmployeeSalary BankEmployeeSalary { get; set; }


        public BankEmployee1(string firstName, string lastName, DateTime dateEmployed, DateTime datePromoted, EmployeeDepartment employeeDepartment)
        {
            FirstName = firstName;
            LastName = lastName;
            DateEmployed = dateEmployed;
            DatePromoted = datePromoted;
            EmployeeDepartment = employeeDepartment;
        }


    }
}
