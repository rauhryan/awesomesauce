using AwesomeSauce.Domain;
using AwesomeSauce.Views;

namespace AwesomeSauce.Handlers
{
    public class AwesomeCreateHandler<TEntity> where TEntity : AwesomeEntity, new()
    {
        public AwesomeCreateModel<TEntity> Execute()
        {
            return new AwesomeCreateModel<TEntity>() {Entity = new TEntity()};
        }

        public AwesomeEditModel DaisyChain(AwesomeCreateModel<TEntity> model)
        {
            return new AwesomeEditModel(){ Entity = model.Entity };
        }
    }

    public class AwesomeCreateModel<TEntity>
    {
        public TEntity Entity { get; set; }
    }
}