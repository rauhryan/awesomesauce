using AwesomeSauce.Configuration.Actions;
using AwesomeSauce.Configuration.Routing;
using FubuMVC.Core;

namespace AwesomeSauce.Configuration
{
    public class AwesomeSauce : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Applies.ToThisAssembly();

            registry.Actions
                .FindWith<RestfulCreateHandlerActionSource>()
                .FindWith<RestfulDeleteHandlerActionSource>()
                .FindWith<RestfulIndexHandlerActionSource>()
                .FindWith<RestfulFindHandlerActionSource>();

            registry.Routes
                .UrlPolicy<RestfulCreateRoutingConvention>()
                .UrlPolicy<RestfulDeleteRoutingConvention>()
                .UrlPolicy<RestfulIndexRoutingConvention>()
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