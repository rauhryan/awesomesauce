using AwesomeSauce.Views;

namespace AwesomeSauce.Handlers
{
    public class AwesomeCreateHandler<TEntity> where TEntity : class, new()
    {
        public AwesomeCreateModel<TEntity> Execute()
        {
            return new AwesomeCreateModel<TEntity>() {Entity = new TEntity()};
        }

        public AwesomeEditModel DaisyChain(AwesomeCreateModel<TEntity> model)
        {
            return new AwesomeEditModel(){ Entity = model.Entity, IsNew = true};
        }
    }

    public class AwesomeCreateModel<TEntity>
    {
        public TEntity Entity { get; set; }
    }
}