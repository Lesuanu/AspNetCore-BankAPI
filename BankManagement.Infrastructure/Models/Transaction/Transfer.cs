namespace BankManagement.Infrastructure.Models.Transaction
{
    public class Transfer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountToTransfer { get; set; }
        public int AmountLeft { get; set; }
       
    }
}
