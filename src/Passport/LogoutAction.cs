using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;

namespace Passport
{
    public class LogoutAction
    {
        readonly IAuthenticationContext _context;

        public LogoutAction(IAuthenticationContext context)
        {
            _context = context;
        }

        public FubuContinuation Execute()
        {
            _context.SignOut();
            return FubuContinuation.RedirectTo(PassportConfiguration.LogonRouteInputModel);
        }
    }
}