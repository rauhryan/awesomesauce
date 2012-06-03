using System.Reflection;
using AwesomeSauce.Configuration;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.UI.Configuration;
using FubuMVC.Core.UI.Tags;
using FubuMVC.Core.View;
using HtmlTags;

namespace AwesomeSauce.Handlers
{
    public static class Class1
    {
        public static HtmlTag AwesomeFields<TEntity>(this IFubuPage page, TEntity model)
        {
            var tagGenerator = page.Get<ITagGenerator>();
            var sl = page.Get<IServiceLocator>();

            tagGenerator.SetProfile(AwesomeConfiguration.TagProfile);

            var result = HtmlTag.Placeholder();

            foreach(var prop in getProperties<TEntity>())
            {
                var p = new SingleProperty(prop, typeof (TEntity));
                var elementRequest = new ElementRequest(model, p, sl);

                var label = tagGenerator.LabelFor(elementRequest);
                var input = tagGenerator.InputFor(elementRequest);

                result.Children.Add(label);
                result.Children.Add(input);
            }

            return result;
        }

        static PropertyInfo[] getProperties<T>()
        {
            return typeof (T).GetProperties();
        }
    }
}