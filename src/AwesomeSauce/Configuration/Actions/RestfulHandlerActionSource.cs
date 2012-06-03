using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
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
            var awesomeEntities = (from entities in types.TypesMatching(AwesomeConfiguration.AwesomeEntities)
                                  where entities.IsConcrete()
                                  select entities).ToList()
                                  .Distinct();

            var openHandlers = new[]
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
                foreach(var openHandler in openHandlers)
                {
                    var closedHandler = openHandler.MakeGenericType(awesomeEntity);
                    var closedMethod = closedHandler.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance); //should drive from RestfulHandler

                    guard(closedHandler, closedMethod);

                    yield return new ActionCall(closedHandler, closedMethod);
                }
            }
        }

        void guard(Type type, MethodInfo methodInfo)
        {
            if(methodInfo == null)
            {
                throw new AwesomeException("No 'Execute' method was found on '{0}'".ToFormat(type.Name));
            }
        }
    }

    [Serializable]
    public class AwesomeException : Exception
    {
        public AwesomeException()
        {
        }

        public AwesomeException(string message) : base(message)
        {
        }

        public AwesomeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AwesomeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}