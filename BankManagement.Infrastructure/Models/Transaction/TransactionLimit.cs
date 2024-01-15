namespace BankManagement.Infrastructure.Models.Transaction
{
    public class TransactionLimit
    {
        public int Id { get; set; }
        public int DepositLimit { get; set; }
        public int WithdrawalLimit { get; set; }
        public int TransferLimit { get; set; }

    }
}
