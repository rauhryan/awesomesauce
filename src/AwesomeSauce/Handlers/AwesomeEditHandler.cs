using AwesomeSauce.Views;

namespace AwesomeSauce.Handlers
{
    public class AwesomeEditHandler<TEntity> where TEntity : class 
    {
         public AwesomeEditModel Execute(TEntity request)
         {
             return new AwesomeEditModel{Entity = request};
         }
    }

   

    public class AwesomeEditRequest
    {
    }
}