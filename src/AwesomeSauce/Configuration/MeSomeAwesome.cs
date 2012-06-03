using AwesomeSauce.Configuration.Actions;
using AwesomeSauce.Configuration.Html;
using AwesomeSauce.Configuration.Routing;
using FubuMVC.Core;

namespace AwesomeSauce.Configuration
{
    public class MeSomeAwesome : FubuPackageRegistry
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

            registry.HtmlConvention<AwesomeHtmlConventions>();
        }
    }
}