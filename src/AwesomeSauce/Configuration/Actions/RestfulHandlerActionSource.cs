using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AwesomeSauce.Handlers;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace AwesomeSauce.Configuration.Actions
{
    public class RestfulHandlerActionSource : IActionSource
    {
        public IEnumerable<ActionCall> FindActions(TypePool types)
        {
            var awesomeEntities = from entities in types.TypesMatching(AwesomeConfiguration.AwesomeEntities)
                                  where entities.IsConcrete()
                                  select entities;

            var handlers = new[]
            {
                typeof (RestfulCreateHandler<>),
                typeof (RestfulPatchHandler<>),
                typeof (RestfulDeleteHandler<>),
                typeof (RestfulFindHandler<>),
                typeof (RestfulIndexHandler<>),
                typeof (AwesomeCreateHandler<>)
            };

            foreach (var awesomeEntity in awesomeEntities)
            {
                foreach(var handler in handlers)
                {
                    var t = handler.MakeGenericType(awesomeEntity);
                    var m = handler.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance); //should drive from RestfulHandler

                    yield return new ActionCall(t, m);
                }
            }
        }


    }
}