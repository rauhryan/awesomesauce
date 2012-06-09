using FubuMVC.Core;

namespace DemoWeb.Configuration
{
    public class DemoWebFubuRegistry : FubuRegistry
    {
        public DemoWebFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();
            
//            this.UseSpark();
//            
//            Views
//                .TryToAttachWithDefaultConventions()
//                .TryToAttachViewsInPackages();


            //awesome config - we have defaults for all of this
            //move into the lamda
//            AwesomeConfiguration.AwesomeEntities = t => t.CanBeCastTo<MyEntity>();
        }
    }
}