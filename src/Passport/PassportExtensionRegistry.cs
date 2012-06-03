using System;
using FubuMVC.Core;
using FubuMVC.Core.Registration.Nodes;

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
                foreach(var c in graph.Behaviors)
                {
                    if(PassportConfiguration.RestrictedAction(c))
                    {
                        
                    }
                }
            });
        }
    }

    public class RestrictedPolicy
    {
        
    }
}
