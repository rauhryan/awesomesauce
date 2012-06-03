using System.Reflection;
using System.Text;
using AwesomeSauce.Configuration;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.UI.Configuration;
using FubuMVC.Core.UI.Forms;
using FubuMVC.Core.UI.Security;
using FubuMVC.Core.UI.Tags;
using FubuMVC.Core.View;
using HtmlTags;

namespace AwesomeSauce.Handlers
{
    public static class AwesomeFubuPageExtensions
    {
        //returning a string is DUMB
        public static string AwesomeFields<TEntity>(this IFubuPage page, TEntity model) where TEntity : class
        {
            var result = new StringBuilder();
            var tags = page.Get<ITagGenerator<TEntity>>();
            var sl = page.Get<IServiceLocator>();

            tags.SetProfile(AwesomeConfiguration.TagProfile);

            foreach(var prop in getProperties<TEntity>())
            {
                var p = new SingleProperty(prop, typeof (TEntity));
                var elementRequest = new ElementRequest(model, p, sl);
                var accessRight = page.Get<IFieldAccessService>().RightsFor(elementRequest);
            
                var line = new FormLineExpression<TEntity>(tags, tags.NewFieldLayout(), elementRequest).Access(accessRight);


                result.Append(line.ToString());
            }

            return result.ToString();
        }

        static PropertyInfo[] getProperties<T>()
        {
            return typeof (T).GetProperties();
        }
    }
}