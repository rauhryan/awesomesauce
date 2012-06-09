using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;

namespace AwesomeSauce.Configuration.Html
{
    public class AwesomeHtmlConventions : HtmlConventionRegistry
    {
        public AwesomeHtmlConventions()
        {
            Profile(AwesomeConfiguration.TagProfile, tags =>
            {
                tags.Editors.Always.Modify((request, tag)=>tag.Attr("name", "Entity" + request.Accessor.FieldName));

                tags.UseLabelAndFieldLayout<AwesomeFieldLayout>();

                tags.Editors.If(a => AwesomeConfiguration.AwesomeEntities(a.Accessor.PropertyType))
                    .Modify(tag => tag.Data("seach","data"));

                //generic way to wrap up an ID form line
                tags.Displays.If(AwesomeConfiguration.IdField)
                    .BuildBy(hiddenLabel);

                tags.Labels.If(AwesomeConfiguration.IdField)
                    .BuildBy(hiddenLabel);
                
                tags.Editors.If(AwesomeConfiguration.IdField)
                    .Modify(tag=>tag.Attr("type","hidden"));

                tags.Labels.Always
                    .Modify(tag => tag.TagName("span"));
                //id line
            });

        }


        HtmlTag hiddenLabel(ElementRequest request)
        {
            return HtmlTag.Empty();
        }
    }
}