using System.Collections.Generic;
using System.Linq;
using AwesomeSauce.Handlers;
using AwesomeSauce.Views;
using FubuCore;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.View.Attachment;

namespace AwesomeSauce.Configuration.Views
{
    public class IndexViewPolicy :  IViewBagConvention
    {
        public void Configure(ViewBag bag, BehaviorGraph graph)
        {
            FindChainsWithoutViews(graph, bag).Each(b =>
            {
                var output = b.ActionOutputType();
                var entityType = output.GetGenericArguments()[0];
                var handlerType = typeof(RestfulIndexHandler<>).MakeGenericType(entityType);
                var method = handlerType.GetMethod("DaisyChain");
                b.AddToEnd(new ActionCall(handlerType,method));

                var token = bag.ViewsFor(typeof (AwesomeIndexModel)).First();
                b.AddToEnd(token.ToBehavioralNode());
            });

        }

        IEnumerable<BehaviorChain> FindChainsWithoutViews(BehaviorGraph graph, ViewBag bag)
        {
            return from b in graph.Behaviors
                   where b.ActionOutputType() != null
                         && b.ActionOutputType().Closes(typeof(RestfulIndexModel<>))
                   let output = b.ActionOutputType()
                   where !bag.ViewsFor(output).Any()
                   select b;
        }
    }
}