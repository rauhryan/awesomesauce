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
                tags.UseLabelAndFieldLayout<AwesomeFieldLayout>();
                tags.Editors.If(a => AwesomeConfiguration.AwesomeEntities(a.Accessor.PropertyType))
                    .BuildBy(BuildTypeAheadEntityFinder);

                //generic way to wrap up an ID form line
                tags.Displays.If(AwesomeConfiguration.IdField)
                    .BuildBy(hiddenLabel);
                tags.Labels.If(AwesomeConfiguration.IdField)
                    .BuildBy(hiddenLabel);
                tags.Editors.If(AwesomeConfiguration.IdField)
                    .Modify(tag=>tag.Attr("type","hidden"));
                //id line


            });
        }

        HtmlTag hiddenLabel(ElementRequest request)
        {

            return HtmlTag.Empty();
        }

        HtmlTag BuildTypeAheadEntityFinder(ElementRequest request)
        {
            return new HtmlTag("input")
                .Attr("type","text")
                .Attr("value", "type ahead");
        }
    }
}