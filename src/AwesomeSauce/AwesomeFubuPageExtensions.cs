using System;
using System.Linq;
using System.Reflection;
using System.Text;
using AwesomeSauce.Configuration;
using AwesomeSauce.Handlers;
using AwesomeSauce.Views;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.UI.Configuration;
using FubuMVC.Core.UI.Forms;
using FubuMVC.Core.UI.Security;
using FubuMVC.Core.UI.Tags;
using FubuMVC.Core.View;
using HtmlTags;

namespace FubuMVC.Core.UI
{
    public static class AwesomeFubuPageExtensions
    {
        public static string AwesomeUrlFor(this IFubuPage page, object model, bool isNew)
        {
            var editType = typeof (RestfulPatchRequest<>).MakeGenericType(model.GetType());
            var request = Activator.CreateInstance(editType).As<IRequestById>();
            request.Id = AwesomeConfiguration.GetIdValue(model);
            return isNew
                       ? page.Urls.UrlFor(typeof (RestfulCreateHandler<>).MakeGenericType(model.GetType()))
                       : page.Urls.UrlFor(request);
        }
        public static string EditUrlFor(this IFubuPage page, object model)
        {
            var editType = typeof(AwesomeEditRequest<>).MakeGenericType(model.GetType());
            var request = Activator.CreateInstance(editType).As<IRequestById>();
            request.Id = AwesomeConfiguration.GetIdValue(model);
            return page.Urls.UrlFor(request);
        }
        public static string DeleteUrlFor(this IFubuPage page, object model)
        {
            var editType = typeof(RestfulDeleteRequest<>).MakeGenericType(model.GetType());
            var request = Activator.CreateInstance(editType).As<IRequestById>();
            request.Id = AwesomeConfiguration.GetIdValue(model);
            return page.Urls.UrlFor(request);
        }

        public static string AwesomeDisplay(this IFubuPage page, object model)
        {
            var type = model.GetType();
            var result = new StringBuilder();
            var tags = page.Tags(model);
            var sl = page.Get<IServiceLocator>();

            tags.SetProfile(AwesomeConfiguration.TagProfile);
            var tr = new HtmlTag("tr");
            foreach (var prop in getProperties(type))
            {

                var p = new SingleProperty(prop, type);
                var elementRequest = new ElementRequest(model, p, sl);
                var accessRight = page.Get<IFieldAccessService>().RightsFor(elementRequest);


                HtmlTag display = tags.DisplayFor(elementRequest).Authorized(accessRight.Read);
                var td = new HtmlTag("td").Append(display);
                tr.Append(td);
                
            }
            var editLink = new LinkTag("Edit", page.EditUrlFor(model));
            tr.Append(new HtmlTag("td").Append(editLink));
            var deleteLink = new LinkTag("Delete", page.DeleteUrlFor(model));
            tr.Append(new HtmlTag("td").Append(deleteLink));
            result.Append(tr.ToString());

            return result.ToString();
        }
        public static string AwesomeHeaders(this IFubuPage page, object model)
        {
            var type = model.GetType();
            var result = new StringBuilder();
            var tags = page.Tags(model);
            var sl = page.Get<IServiceLocator>();

            tags.SetProfile(AwesomeConfiguration.TagProfile);
            var tr = new HtmlTag("tr");
            foreach (var prop in getProperties(type))
            {

                var p = new SingleProperty(prop, type);
                var elementRequest = new ElementRequest(model, p, sl);
                var accessRight = page.Get<IFieldAccessService>().RightsFor(elementRequest);


                HtmlTag display = tags.LabelFor(elementRequest).Authorized(accessRight.Read);
                var td = new HtmlTag("th").Append(display);
                tr.Append(td);

            }
            tr.Append(new HtmlTag("th"));
            tr.Append(new HtmlTag("th"));
            result.Append(tr.ToString());

            return result.ToString();
        }
        public static string AwesomeFields(this IFubuPage page, object model)
        {
            var type = model.GetType();
            var result = new StringBuilder();
            var tags = page.Tags<AwesomeEditModel>();
            var sl = page.Get<IServiceLocator>();

            tags.SetProfile(AwesomeConfiguration.TagProfile);

            foreach(var prop in getProperties(type))
            {

                var p = new SingleProperty(prop, type);
                var elementRequest = new ElementRequest(model, p, sl);
                var accessRight = page.Get<IFieldAccessService>().RightsFor(elementRequest);
            
                var line = new FormLineExpression<AwesomeEditModel>(tags, tags.NewFieldLayout(), elementRequest)
                    .Access(accessRight)
                    .Editable(true);

                result.Append(line.ToString());
            }
            
            return result.ToString();
        }

        static PropertyInfo[] getProperties(Type type)
        {
            return type.GetProperties();
        }
    }
}