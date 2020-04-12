using Autoview.Engine;

namespace Autoview.ElementsEngine
{
    public class Span
    {
        public static string RenderSpanBody(string cssId, string cssClass, string spanContent)
        {
            return $"<span{ Extensions.ElementIdWithCssClass(cssId, cssClass) }>{ spanContent }</span>";
        }

        public static Elements.Span Render(string cssId, string cssClass, string spanContent)
        {
            return new Elements.Span(cssId, cssClass, rendered: RenderSpanBody(cssId, cssClass, spanContent));
        }
    }
}
