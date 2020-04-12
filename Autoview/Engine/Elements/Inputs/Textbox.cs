using Autoview.Elements;
using Autoview.Engine;

namespace Autoview.Elements.Inputs
{
    public partial class Textbox : AElement
    {
        public Textbox() : base() { }

        public Textbox(string name, string value, string displayName, string cssId, string cssClass) : base()
        {
            Type = typeof(Textbox);

            Name = name;

            Value = value;

            DisplayName = displayName;

            CssId = cssId;

            CssClass = cssClass;
        }

        public override AElement InitialElement(Property property)
        {
            return ElementsEngine.Textbox.Generate(property);
        }
    }
}
