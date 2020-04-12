using Autoview.Elements;
using Autoview.Engine;

namespace Autoview.ElementsEngine
{
    public class Div
    {
        public static string GenerateDivBody(string id, string cssClass, string content)
        {
            return $"<div{ Extensions.ElementIdWithCssClass(cssId: id, cssClass: cssClass) }>{ content }</div>";
        }

        public static Elements.Div Generate(AElement element, string id, string cssClass)
        {
            var newDivInstance = new Elements.Div(child: element, id: id, cssClass: cssClass);

            newDivInstance.Rendered = GenerateDivBody(id: id, cssClass: cssClass, content: element?.Rendered);

            return newDivInstance;
        }

        public static Elements.Div Render(string divContent, string id, string cssClass)
        {
            var newDivInstance = new Elements.Div(child: null, id: id, cssClass: cssClass);

            newDivInstance.Rendered = GenerateDivBody(id: id, cssClass: cssClass, content: divContent);

            return newDivInstance;
        }
    }
}