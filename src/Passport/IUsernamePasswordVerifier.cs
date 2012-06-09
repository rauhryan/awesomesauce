namespace Passport
{
    public interface IUsernamePasswordVerifier
    {
        bool Verify(string username, string password);
    }
}