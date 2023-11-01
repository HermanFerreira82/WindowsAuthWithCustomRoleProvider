using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace WindowsAuthWithCustomRoleProvider;

public class CustomRoleAuthorizationTransform : IClaimsTransformation
{
    private static readonly string RoleClaimType = $"http://{typeof(CustomRoleAuthorizationTransform).FullName.Replace('.', '/')}/role";
    private readonly ICustomRoleProvider _roleProvider;

    public CustomRoleAuthorizationTransform(ICustomRoleProvider roleProvider)
    {
        _roleProvider = roleProvider ?? throw new ArgumentNullException(nameof(roleProvider));
    }
    
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var windowsIdentity = (ClaimsIdentity)principal.Identity;
        
        var customIdentity = new ClaimsIdentity(
            windowsIdentity.Claims,
            windowsIdentity.AuthenticationType,
            windowsIdentity.NameClaimType,
            RoleClaimType);

        // Fetch the roles for the user and add the claims of the correct type so that roles can be recognized.
        var roles = await _roleProvider.GetUserRolesAsync(customIdentity.Name);
        customIdentity.AddClaims(roles.Select(r => new Claim(RoleClaimType, r)));

        // Create and return a new claims principal
        return new ClaimsPrincipal(customIdentity);
    }
}