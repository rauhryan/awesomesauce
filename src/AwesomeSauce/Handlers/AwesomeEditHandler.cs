using AwesomeSauce.Domain;
using AwesomeSauce.Views;

namespace AwesomeSauce.Handlers
{
    public class AwesomeEditHandler<T> where T : AwesomeEntity 
    {
         public AwesomeEditModel Execute(T request)
         {
             return new AwesomeEditModel(){Entity = request};
         }
    }

    public class AwesomeCreateHandler<TEntity> where TEntity : AwesomeEntity, new()
    {
        public AwesomeCreateModel<TEntity> Execute()
        {
            return new AwesomeCreateModel<TEntity>() {Entity = new TEntity()};
        }
    }

    public class AwesomeCreateModel<TEntity>
    {
        public TEntity Entity { get; set; }
    }

    public class AwesomeEditRequest<T> 
    {
    }
}