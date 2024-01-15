namespace BankManagement.Models.Transaction
{
    public class Withdrawal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountToWithdraw { get; set; }
        public int AmountLeft { get; set; }
        public int BankNumber { get; set; }    //needed if's not your account
    }
}
