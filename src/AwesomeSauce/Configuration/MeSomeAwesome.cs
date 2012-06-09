using AwesomeSauce.Binding;
using AwesomeSauce.Configuration.Actions;
using AwesomeSauce.Configuration.Html;
using AwesomeSauce.Configuration.Routing;
using AwesomeSauce.Configuration.Views;
using FubuMVC.Core;
using FubuMVC.Spark;

namespace AwesomeSauce.Configuration
{
    public class MeSomeAwesome : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Applies
                .ToAllPackageAssemblies()
                .ToThisAssembly();

            registry.Actions
                .FindWith<RestfulHandlerActionSource>();

            registry.Routes
                .UrlPolicy<AwesomeCreateRoutingConvention>()
                .UrlPolicy<AwesomeEditRoutingConvention>()
                .UrlPolicy<RestfulCreateRoutingConvention>()
                .UrlPolicy<RestfulDeleteRoutingConvention>()
                .UrlPolicy<RestfulIndexRoutingConvention>()
                .UrlPolicy<RestfulPatchRoutingConvention>()
                .UrlPolicy<RestfulFindRoutingConvention>();

            registry.Models
                .BindModelsWith<EntityModelBinder>();

            registry.Output.ToJson.WhenCallMatches(x => x.HandlerType.IsGenericType);

            registry.UseSpark();

            registry.Views
                .TryToAttachWithDefaultConventions()
                .TryToAttachViewsInPackages()
                .ApplyConvention<IndexViewPolicy>()
                .ApplyConvention<CreateViewPolicy>();

            registry.HtmlConvention<AwesomeHtmlConventions>();

            
        }
    }
}
