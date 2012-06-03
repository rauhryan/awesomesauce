using System.Collections.Generic;
using FubuMVC.Core.UI.Forms;
using HtmlTags;

namespace AwesomeSauce.Configuration.Html
{
    /// <summary>
    /// This needs to be tweaked to how RYAN wants it.
    /// </summary>
    public class AwesomeFieldLayout : ILabelAndFieldLayout
    {
        private HtmlTag _wrappingDiv;
        private HtmlTag _label;
        private HtmlTag _inputHolder;

        public AwesomeFieldLayout()
        {
            _inputHolder = new HtmlTag("div");
            _label = new HtmlTag("label");
        }

        public IEnumerable<HtmlTag> AllTags()
        {
            yield return _wrappingDiv;
        }

        public HtmlTag LabelTag
        {
            get { return _label; }
            set { _label = value; }
        }

        public HtmlTag BodyTag
        {
            get { return _inputHolder.FirstChild(); }
            set { _inputHolder.ReplaceChildren(value); }
        }

        public override string ToString()
        {
            _wrappingDiv = new HtmlTag("div").AddClass("clearfix");
            _wrappingDiv.Append(_label);
            var d = new HtmlTag("div").AddClass("input");
            _inputHolder.Children.Each(c => d.Append(c));
            _wrappingDiv.Append(d);
            return string.Format("{0}\n", _wrappingDiv);
        }
    }
}