namespace WindowsAuthWithCustomRoleProvider;

public interface IDbContextSimulator
{
    Task<List<string>> GetUserRolesAsync(string user);
}
