using FubuMVC.Core;
using FubuMVC.Spark;

namespace AwesomeSauce.Web.Configuration
{
    public class AwesomeSauceFubuRegistry : FubuRegistry
    {
        public AwesomeSauceFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();
            
            this.UseSpark();
            
            Views
                .TryToAttachWithDefaultConventions()
                .TryToAttachViewsInPackages();

            Import<AwesomeSauce.Configuration.AwesomeSauce>();
        }
    }
}