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
        private HtmlTag _wrappingLabel;
        private HtmlTag _labelSpan;
        private HtmlTag _inputHolder;

        public AwesomeFieldLayout()
        {
            _inputHolder = new HtmlTag("div");
            _labelSpan = new HtmlTag("span");
        }

        public IEnumerable<HtmlTag> AllTags()
        {
            yield return _wrappingLabel;
        }

        public HtmlTag LabelTag
        {
            get { return _labelSpan; }
            set { _labelSpan = value; }
        }

        public HtmlTag BodyTag
        {
            get { return _inputHolder.FirstChild(); }
            set { _inputHolder.ReplaceChildren(value); }
        }

        public override string ToString()
        {
            _wrappingLabel = new HtmlTag("label").AddClass("clearfix");
            _wrappingLabel.Append(_labelSpan);

            _inputHolder.Children.Each(c => _wrappingLabel.Append(c));
           
            return string.Format("{0}\n", _wrappingLabel);
        }
    }
}