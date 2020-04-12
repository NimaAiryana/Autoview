using Autoview.Engine;
using Autoview.Validation;

namespace Autoview.ElementsEngine
{
    public class Textbox
    {
        public static Elements.Inputs.Textbox Generate(Property property)
        {
            var textboxInstance = property.Element as Elements.Inputs.Textbox;

            textboxInstance.Value = property.PropertyValue;

            textboxInstance.Rendered = GenerateTextboxBody(textbox: textboxInstance) + Initial.RenderErrorElements(errorElements: property.ErrorElements);

            return textboxInstance;
        }

        public static string GenerateTextboxBody(Elements.Inputs.Textbox textbox)
        {
            return $"<input type=\"text\"{ Extensions.ElementIdWithCssClass(cssId: textbox.CssId, cssClass: textbox.CssClass) }" +
                $" { Extensions.ElementName(name: textbox.Name) } { Extensions.ElementValue(value: textbox.Value) } />";
        }

    }
}