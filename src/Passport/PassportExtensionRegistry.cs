using System;
using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Registration.Nodes;
using System.Linq;
using FubuMVC.Core.Registration.ObjectGraph;

namespace Passport
{
    public static class PassportConfiguration
    {
        public static Func<BehaviorChain, bool> RestrictedAction { get; set; }
    }

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

    public class AuthenticationPolicy : IActionBehavior
    {
        public void Invoke()
        {
            //do authentication shit
        }

        public void InvokePartial()
        {
            //no-op
        }
    }
}
