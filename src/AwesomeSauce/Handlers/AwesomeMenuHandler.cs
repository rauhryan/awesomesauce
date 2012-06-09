using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Routes;

namespace AwesomeSauce.Handlers
{
    public class AwesomeMenuHandler
    {
        readonly BehaviorGraph _graph;

        public AwesomeMenuHandler(BehaviorGraph graph)
         {
             _graph = graph;
         }
        [FubuPartial]
        public AwesomeMenuModel Execute(AwesomeMenuRequest request)
        {
            var routes = _graph
                .Behaviors
                .Where(b => b.FirstCall() != null && b.FirstCall().HandlerType.Closes(typeof (RestfulIndexHandler<>)))
                .Select(
                    b =>
                    new AwesomeMenuModel.AwesomeMenuToken()
                    {Route = b.Route, Text = b.FirstCall().HandlerType.GetGenericArguments()[0].Name});

            return new AwesomeMenuModel(){Routes = routes};
        }
    }

    public class AwesomeMenuRequest
    {
    }

    public class AwesomeMenuModel
    {
        public IEnumerable<AwesomeMenuToken> Routes { get; set; }
        public class AwesomeMenuToken
        {
            public string Text { get; set; }
            public IRouteDefinition Route { get; set; }
        }
    }
}