using System;
using AwesomeSauce.Configuration;
using AwesomeSauce.Configuration.Storage;
using AwesomeSauce.Handlers;
using FubuCore;
using FubuCore.Binding;
using FubuCore.Conversion;
using FubuCore.Descriptions;
using MongoDB.Driver.Builders;


namespace AwesomeSauce.Binding
{
    public class EntityModelBinder : IModelBinder
    {
        public bool Matches(Type type)
        {
            return type.Closes(typeof(RestfulPatchRequest<>));
        }

        public object Bind(Type type, IBindingContext context)
        {
            object model = Activator.CreateInstance(type);
            context.BindProperties(model);
            return model;
        }
    }
   public class EntityStrategy : IConverterStrategy
   {
       readonly Type _type;

       public EntityStrategy(Type type)
       {
           _type = type;
       }

       public void Describe(Description description)
       {
           description.Title = "Entity Strategy";
           description.ShortDescription = "Pulls entity out of mongodb ";
       }

       public object Convert(IConversionRequest request)
       {
           var session = request.Get<MongoSession>().Session;
           var collection = session.GetCollection(_type, _type.Name.ToLowerInvariant());
           var query = Query.EQ("_id", request.Text);
           return collection.FindOneAs(_type, query);
       }
   }
    public class EntityConverterFamily : IObjectConverterFamily
    {

        public bool Matches(Type type, ConverterLibrary converter)
        {
            return AwesomeConfiguration.AwesomeEntities(type);
        }

        public IConverterStrategy CreateConverter(Type type, Func<Type, IConverterStrategy> converterSource)
        {
            return new EntityStrategy(type);
        }
    }
}