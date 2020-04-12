using Autoview.Elements;
using Autoview.Engine;

namespace Autoview.Elements
{
    public class Span : AElement
    {
        public Span(string cssId, string cssClass, string rendered)
        {
            CssId = cssId;

            CssClass = cssClass;

            Rendered = rendered;
        }

        public override AElement InitialElement(Property property)
        {
            throw new System.Exception("not used in system");
        }
    }
}
