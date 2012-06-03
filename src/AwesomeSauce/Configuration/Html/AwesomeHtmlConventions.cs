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
                tags.Editors.If(a => AwesomeConfiguration.AwesomeEntities(a.ModelType))
                    .BuildBy(BuildTypeAheadEntityFinder);
            });
        }

        HtmlTag BuildTypeAheadEntityFinder(ElementRequest request)
        {
            return new HtmlTag("input")
                .Attr("value", "type ahead");
        }
    }
}