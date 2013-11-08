using AwesomeSauce.Configuration;
using DemoWeb.Conventions.Binding;
using FubuCore;
using FubuMVC.Core;
using MongoDB.Bson;

namespace DemoWeb.Configuration
{
    public class DemoWebFubuRegistry : FubuRegistry
    {
        public DemoWebFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();

            Models
                .ConvertUsing<LoanNumberConverterFamily>();

            this.Media.ApplyContentNegotiationToActions((call) => true);

//            this.UseSpark();
//            
//            Views
//                .TryToAttachWithDefaultConventions()
//                .TryToAttachViewsInPackages();


            //awesome config - we have defaults for all of this
            //move into the lamda
            AwesomeConfiguration.AwesomeEntities = t => t.CanBeCastTo<IEntity>();
        }
    }

    public interface IEntity
    {
        ObjectId Id { get; }
    }
}