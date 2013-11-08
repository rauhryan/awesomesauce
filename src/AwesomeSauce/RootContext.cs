using System;
using System.Reflection;
using FubuCore.Reflection;

namespace AwesomeSauce
{
    public class Test
    {
         public void aTest()
         {
             var type = typeof (object);
             new AggRootProcessor().Process(type);
         }

    }

    public class AggRootProcessor
    {
        public void Process(Type type)
        {
            if (!isEntity(type)) return;

            var cxt = new RootContext();
            processType(cxt, null, type);
        }

        void processType(IContext cxt, PropertyInfo property, Type type)
        {
            if (!isEntity(type)) return;

            var childContext = cxt.GetChildContext(type, property, () => 1);
            foreach (var prop in type.GetProperties())
            {
                processType(childContext, prop, prop.PropertyType);
            }
        }

        bool isEntity(Type type)
        {
            return true;
        }
    }

    public interface IContext
    {
        IContext GetChildContext(Type type, PropertyInfo property, Func<int> idFinder);
    }

    public class RootContext : IContext
    {
        readonly IContext _parentContext;
        readonly Type _type;
        readonly PropertyInfo _property;
        readonly Func<int> _idFinder;

        public RootContext()
        {
            _parentContext = null;
            _type = null;
            _property = null;
            _idFinder = null;
        }

        RootContext(IContext parentContext, Type type, PropertyInfo property, Func<int> idFinder)
        {
            _parentContext = parentContext;
            _type = type;
            _property = property;
            _idFinder = idFinder;
        }

        public IContext GetChildContext(Type type, PropertyInfo property, Func<int> idFinder)
        {
            return new RootContext(this, type, property, idFinder);
        }
    }
}