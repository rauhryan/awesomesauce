using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;

namespace AwesomeSauce.Configuration
{
    public class AwesomeHtmlConventions : HtmlConventionRegistry
    {
        public AwesomeHtmlConventions()
        {
            Profile(AwesomeConfiguration.TagProfile, tags =>
            {
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