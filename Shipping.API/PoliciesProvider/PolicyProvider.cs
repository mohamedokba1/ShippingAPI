//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Options;
//using System.Security.Claims;

//namespace Shipping.API.PoliciesProvider;

//public class PolicyProvider : IAuthorizationPolicyProvider
//{
//    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;
//    private readonly IHttpContextAccessor _context;

//    public PolicyProvider(IOptions<AuthorizationOptions> options, IHttpContextAccessor context)
//    {
//        _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
//        _context = context;
//    }
//    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
//    {
//        if (policyName.StartsWith("Permission.", StringComparison.OrdinalIgnoreCase))
//        {
//            var policy = new AuthorizationPolicyBuilder("Bearer")
//            .RequireClaim(policyName)
//            .RequireAuthenticatedUser()
//            .AddAuthenticationSchemes("Bearer")
//            .Build();
//            return Task.FromResult<AuthorizationPolicy?>(policy);
//        }
//        return _fallbackPolicyProvider.GetPolicyAsync(policyName);
//    }

//    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
//        => _fallbackPolicyProvider.GetDefaultPolicyAsync();

//    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
//        => _fallbackPolicyProvider.GetFallbackPolicyAsync();
//}
