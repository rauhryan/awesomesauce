using FubuMVC.Core.Runtime;
using FubuMVC.Core.Urls;

namespace Passport
{
    public interface IUnauthenticatedPolicy
    {
        void Handle();
    }

    public class UnauthenticatedPolicy : IUnauthenticatedPolicy
    {
        readonly IOutputWriter _writer;
        readonly IUrlRegistry _urls;

        public UnauthenticatedPolicy(IOutputWriter writer, IUrlRegistry urls)
        {
            _writer = writer;
            _urls = urls;
        }

        public void Handle()
        {
            _writer.RedirectToUrl(_urls.UrlFor(PassportConfiguration.LogonRouteInputModel));
        }

    }

    public class LogonAction
    {
        
    }
}