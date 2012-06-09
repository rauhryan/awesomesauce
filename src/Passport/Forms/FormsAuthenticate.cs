using FubuMVC.Core.Continuations;
using FubuMVC.Core.Urls;
using Passport.UsernamePassword;

namespace Passport.Forms
{
    public class FormsAuthenticate
    {
        readonly IUsernamePasswordVerifier _verifier;
        IUrlRegistry _urls;

        public FormsAuthenticate(IUsernamePasswordVerifier verifier, IUrlRegistry urls)
        {
            _verifier = verifier;
            _urls = urls;
        }

        public FubuContinuation Execute(FormsLoginRequest request)
        {
            if(_verifier.Verify(request.Username, request.Password))
            {
                //home url
                var homeUrl = _urls.UrlFor(PassportConfiguration.HomeInputModel);
                return FubuContinuation.RedirectTo(homeUrl);
            }

            //something like that?
            return FubuContinuation.RedirectTo(PassportConfiguration.LogonRouteInputModel);

        }
    }
}