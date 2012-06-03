using AwesomeSauce.Handlers;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.Diagnostics;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace AwesomeSauce.Configuration.Routing
{
    public class RestfulFindRoutingConvention : IUrlPolicy
    {
        private static Accessor accessor = ReflectionHelper.GetAccessor<IRequestById>(x => x.Id);

        public bool Matches(ActionCall call, IConfigurationObserver log)
        {
            return call.HandlerType.Closes(typeof(RestfulFindHandler<>));
        }

        public IRouteDefinition Build(ActionCall call)
        {
            var def = call.ToRouteDefinition();
            var entityType = call.HandlerType.GetGenericArguments()[0];
            def.Append(entityType.Name.ToLowerInvariant());
            def.Input.AddRouteInput(new RouteParameter(accessor),true);
            def.AddHttpMethodConstraint("GET");
            return def;
        }
    }
}