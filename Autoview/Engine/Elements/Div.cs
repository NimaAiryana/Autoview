using Autoview.Engine;

namespace Autoview.Elements
{
    public class Div : AElement
    {
        public Div() : base() { }

        public Div(AElement child) : base()
        {
            Type = typeof(Div);

            Child = child;
        }

        public Div(AElement child, string id, string cssClass) : base()
        {
            Type = typeof(Div);

            Child = child;

            CssId = id;

            CssClass = cssClass;
        }

        public AElement Child { get; set; }

        public override AElement InitialElement(Property property)
        {
            return ElementsEngine.Div.Generate(element: null, property.Element.CssId, property.Element.CssClass);
        }
    }
}
