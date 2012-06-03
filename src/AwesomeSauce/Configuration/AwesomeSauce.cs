using System;
using AwesomeSauce.Configuration.Actions;
using AwesomeSauce.Configuration.Routing;
using AwesomeSauce.Domain;
using FubuCore;
using FubuMVC.Core;

namespace AwesomeSauce.Configuration
{
    public static class AwesomeConfiguration
    {
        static AwesomeConfiguration()
        {
            AwesomeEntities = t => t.CanBeCastTo<AwesomeEntity>();
        }

        public static Func<Type, bool> AwesomeEntities { get; set; }
    }

    public class AwesomeSauce : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Applies.ToThisAssembly();

            registry.Actions
                .FindWith<RestfulHandlerActionSource>();

            registry.Routes
                .UrlPolicy<RestfulCreateRoutingConvention>()
                .UrlPolicy<RestfulDeleteRoutingConvention>()
                .UrlPolicy<RestfulIndexRoutingConvention>()
                .UrlPolicy<RestfulPatchRoutingConvention>()
                .UrlPolicy<RestfulFindRoutingConvention>();

            registry.Output.ToJson.WhenCallMatches(x => x.HandlerType.IsGenericType);
        }
    }

    public static class AwesomeSauceExtensions
    {
        public static AwesomeSauceExpression AwesomeSauce()
        {
            return new AwesomeSauceExpression();
        }
    }

    public class AwesomeSauceExpression
    {
        
    }
}