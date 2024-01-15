using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankManagement.Auth.Service
{
    //evaluates the requirements properties
    public class WithdrawalLimitHandler : AuthorizationHandler<WithDrawalLimitRequirememt>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WithDrawalLimitRequirememt requirement)
        {
            var claimHandler = context.User.FindFirst(c => c.Type == "Role");
            if (claimHandler != null)
            {
                return Task.CompletedTask;
            }
            if (requirement.WithdrawalLimit >= 60000)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;  
        }
    }

    //IAuthorizationHandler - to mark whether requirememts have been met
  
}
