using Autoview.Elements;

namespace Autoview.Engine
{
    public class Partition
    {
        public static Div OrganizeDivWithElement(AElement element)
        {
            string divCssClass = "col-sm-12 col-md-7";

            var divElementGenerated = ElementsEngine.Div.Generate(element: element, id: default, cssClass: divCssClass);

            return divElementGenerated;
        }

        public static string OrganizeDivWithDisplayName(string displayName)
        {
            string divCssClass = "col-form-label text-md-right col-12 col-md-3 col-lg-3";

            return ElementsEngine.Div.GenerateDivBody(id: default, cssClass: divCssClass, content: displayName);
        }

        public static string OrganizeSection(Property elementProperty)
        {
            string sectionCssClass = "form-group row mb-4";

            string displayNameContent = OrganizeDivWithDisplayName(displayName: elementProperty.Element.DisplayName);

            string elementContent = OrganizeDivWithElement(element: elementProperty.Element).Rendered;

            return ElementsEngine.Div.GenerateDivBody(id: default, cssClass: sectionCssClass, content: displayNameContent + elementContent);
        }

    }
}
