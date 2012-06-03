using AwesomeSauce.Configuration;
using AwesomeSauce.Domain;
using FubuMVC.Core;
using FubuMVC.Spark;
using FubuCore;

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


            //awesome config - we have defaults for all of this
            //move into the lamda
            AwesomeConfiguration.AwesomeEntities = t => t.CanBeCastTo<AwesomeEntity>();

            Import<MeSomeAwesome>();
        }
    }
}