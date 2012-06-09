using System.Collections.Generic;
using FubuCore.Reflection;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace Passport
{
    public class PassportActionSource : IActionSource
    {
        public IEnumerable<ActionCall> FindActions(TypePool types)
        {
            yield return new ActionCall(typeof(LogoutAction), ReflectionHelper.GetMethod<LogoutAction>(x=>x.Execute()));
        }
    }
}