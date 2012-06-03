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

   

    public class AwesomeEditRequest<T> 
    {
    }
}