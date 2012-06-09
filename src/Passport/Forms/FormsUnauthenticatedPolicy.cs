using FubuMVC.Core.Runtime;
using FubuMVC.Core.Urls;

namespace Passport.Forms
{
    public class FormsUnauthenticatedPolicy : IUnauthenticatedPolicy
    {
        readonly IOutputWriter _writer;
        readonly IUrlRegistry _urls;

        public FormsUnauthenticatedPolicy(IOutputWriter writer, IUrlRegistry urls)
        {
            _writer = writer;
            _urls = urls;
        }

        public void Handle()
        {
            _writer.RedirectToUrl(_urls.UrlFor(PassportConfiguration.LogonRouteInputModel));
        }

    }
}