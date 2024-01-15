using Microsoft.AspNetCore.Authorization;

namespace BankManagement.Auth.Service
{
    public class WithDrawalLimitRequirememt : IAuthorizationRequirement
    {
        public int WithdrawalLimit { get; }

        public WithDrawalLimitRequirememt(int id)
        {
            this.WithdrawalLimit = id;
        }
    }
}
