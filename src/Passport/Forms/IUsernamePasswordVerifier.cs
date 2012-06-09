namespace Passport.UsernamePassword
{
    public interface IUsernamePasswordVerifier
    {
        bool Verify(string username, string password);
    }
}