using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Registration.Nodes;
using System.Linq;

namespace Passport
{
    public class PassportExtensionRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Configure(graph =>
            {
                graph.Behaviors.Where(PassportConfiguration.RestrictedAction).Each(c =>
                {
                    var x = new Wrapper(typeof (AuthenticationPolicy));
                    c.Prepend(x);
                });
            });
        }
    }
}
