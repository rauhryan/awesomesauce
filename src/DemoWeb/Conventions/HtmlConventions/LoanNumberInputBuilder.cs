using DemoWeb.Domain;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;

namespace DemoWeb.Conventions.HtmlConventions
{
    public class LoanNumberInputBuilder : IElementBuilder
    {
        public TagBuilder CreateInitial(AccessorDef accessorDef)
        {
            if (accessorDef.ModelType.Equals(typeof(LoanNumber)))
            {
                return request =>
                {
                    var str = request.Value<LoanNumber>().ToString();
                    var tag = new HtmlTag("input")
                        .Attr("type","text")
                        .Attr("value", str);

                    return tag;
                };
            }

            return a => { return HtmlTag.Empty(); };
        }
    }
}