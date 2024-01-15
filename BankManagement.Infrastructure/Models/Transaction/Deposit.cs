namespace BankManagement.Infrastructure.Models.Transaction
{
    public class Deposit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountToDepsit { get; set; }
        public int AmountBsfore { get; set; }
        public int AmountAfter { get; set; }
        public int BankNumber { get; set; }    //needed if's not your account
        
    }
}
