using System.Collections.Generic;
using System.Linq;
using AwesomeSauce.Domain;
using AwesomeSauce.Handlers;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace AwesomeSauce.Configuration.Actions
{
    public class RestfulIndexHandlerActionSource : IActionSource
    {
        private static readonly string _methodName =
            ReflectionHelper.GetMethod<RestfulIndexHandler<string>>(x => x.Get(null)).Name;

        public IEnumerable<ActionCall> FindActions(TypePool types)
        {
            return from entities in types.TypesMatching(t =>t.CanBeCastTo<AwesomeEntity>()) 
                   where entities.IsConcrete()
                   select typeof(RestfulIndexHandler<>).MakeGenericType(entities) 
                   into handlerType 
                   let method = handlerType.GetMethod(_methodName) 
                   select new ActionCall(handlerType,method);
        }
    }
}