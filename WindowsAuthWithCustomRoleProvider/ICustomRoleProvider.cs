namespace WindowsAuthWithCustomRoleProvider;

public interface ICustomRoleProvider
{
    Task<ICollection<string>> GetUserRolesAsync(string userName);
}