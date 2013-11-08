using DemoWeb.Domain;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;

namespace DemoWeb.Conventions.HtmlConventions
{
    public class LoanNumberDisplayBuilder : IElementBuilder
    {
        public TagBuilder CreateInitial(AccessorDef accessorDef)
        {
            if(accessorDef.ModelType.Equals(typeof(LoanNumber)))
            {
                return request =>
                {
                    var str = request.Value<LoanNumber>();
                    return new HtmlTag("span", tag=>tag.Text(str.ToString()));
                };
            }

            return a => { return HtmlTag.Empty(); };
        }
    }
}