namespace WindowsAuthWithCustomRoleProvider;

public class DbContextSimulator: IDbContextSimulator
{
    public Task<List<string>> GetUserRolesAsync(string user)
    {
        var x = new List<string>()
        {
            CustomRoleProvider.BASIC_USER
        };
        
        return Task.FromResult(x);
    }
}