using Microsoft.AspNetCore.Authorization;

namespace Shipping.API.PoliciesProvider;

public class RequireClaim : AuthorizeAttribute
{
    public RequireClaim(string policyName)
    {
        Policy = policyName;
    }
}
