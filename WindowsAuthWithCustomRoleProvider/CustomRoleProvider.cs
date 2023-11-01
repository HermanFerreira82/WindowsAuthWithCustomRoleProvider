namespace WindowsAuthWithCustomRoleProvider;

public class CustomRoleProvider : ICustomRoleProvider
{
    private readonly IDbContextSimulator _dbContextSimulator;
    
    public const string ADMIN = "Admin";
    public const string BASIC_USER = "BasicUser";

    public CustomRoleProvider(IDbContextSimulator dbContextSimulator)
    {
        _dbContextSimulator = dbContextSimulator;
    }
    
    public async Task<ICollection<string>> GetUserRolesAsync(string userName)
    {
        return await _dbContextSimulator.GetUserRolesAsync(userName);
    }
}