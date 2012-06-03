using AwesomeSauce.Handlers;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.Diagnostics;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace AwesomeSauce.Configuration.Routing
{
    public class RestfulIndexRoutingConvention : IUrlPolicy
    {

        public bool Matches(ActionCall call, IConfigurationObserver log)
        {
            return call.HandlerType.Closes(typeof(RestfulIndexHandler<>));
        }

        public IRouteDefinition Build(ActionCall call)
        {
            var def = call.ToRouteDefinition();
            var entityType = call.HandlerType.GetGenericArguments()[0];
            def.Append(entityType.Name.ToLowerInvariant());
            def.AddHttpMethodConstraint("GET");
            return def;
        }
    }
}