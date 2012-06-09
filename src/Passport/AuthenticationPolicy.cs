using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Security;

namespace Passport
{
    public class AuthenticationPolicy : IActionBehavior
    {
        readonly ISecurityContext _context;
        readonly IUnauthenticatedPolicy _failure;

        public AuthenticationPolicy(ISecurityContext context, IUnauthenticatedPolicy failure)
        {
            _context = context;
            _failure = failure;
        }

        public void Invoke()
        {
            if(_context.IsAuthenticated())
            {
                InnerBehavior.Invoke();
            }

            _failure.Handle();
        }


        public void InvokePartial()
        {
            InnerBehavior.InvokePartial();
        }

        public IActionBehavior InnerBehavior { get; set; }
    }
}