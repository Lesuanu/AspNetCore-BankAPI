namespace BankManagement.Infrastructure.Models.BankEmployee
{
    public class BankEmployeeSalary
    {
        public int Id { get; set; }
        public int MonthlySalary { get; set; }
        public int TaxPayable { get; set; }
        public int AnualSalary { get; set; }
        public int GrossPay { get; set; }

        //navigation property
        public int BankEmployee1Id { get; set; }
        public BankEmployee1 BankEmployee1 { get; set; }
    }
}