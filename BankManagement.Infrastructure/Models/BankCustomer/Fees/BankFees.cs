namespace BankManagement.Infrastructure.Models.BankCustomer.Fees
{
    public class BankFees
    {
        public int Id { get; set; }
        public int SavingsFees { get; set; }
        public int SavingsCommission { get; set; }
        public int DepositFees { get; set; }
        public int DepositCommission { get; set; }
        public int CurrentFees { get; set; }
        public int CurrentCommissiion { get; set; }
        public int CheckingFees { get; set; }
        public int CheckingCommissiion { get; set; }
        public int BankCharges { get; set; }

    }
}
