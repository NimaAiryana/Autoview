using Autoview.Engine;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Autoview.Elements.Dropdown
{
    public class Dropdown : AElement
    {
        public Dropdown(string propertyName, string propertyValue, List<SelectListItem> selectListItems, string displayName, string id, string cssClass)
        {
            Type = typeof(Dropdown);

            Name = propertyName;

            Value = propertyValue;

            SelectListItems = selectListItems;

            DisplayName = displayName;

            CssId = id;

            CssClass = cssClass;
        }

        public List<SelectListItem> SelectListItems { get; set; }

        public List<Option> Options { get; set; }

        public override AElement InitialElement(Property property)
        {
            return ElementsEngine.Dropdown.Dropdown.Generate(property);
        }
    }
}
