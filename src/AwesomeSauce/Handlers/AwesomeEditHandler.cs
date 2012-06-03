using AwesomeSauce.Views;

namespace AwesomeSauce.Handlers
{
    public class AwesomeEditHandler<TEntity> where TEntity : class 
    {
         public AwesomeEditModel Execute(TEntity request)
         {
             return new AwesomeEditModel{Entity = request};
        }

        public AwesomeEditModel DaisyChain(AwesomeEditModel<TEntity> model)
        {
            return new AwesomeEditModel(){Entity = model.Entity};
        }
    }

   public class AwesomeEditModel<T>
   {
       public T Entity { get; set; }
   }

  
    public class AwesomeEditRequest<T> : IRequestById
    {
        public string Id { get; set; }
        
    }
}
