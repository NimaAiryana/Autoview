using Autoview.Engine;
using Autoview.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Autoview.ElementsEngine.Dropdown
{
    public class Dropdown
    {
        public static List<Elements.Dropdown.Option> InitialDropdownOptions(List<SelectListItem> selectListItems, string dropdownSelectedValue)
        {
            var tempOfAutoViewOptionList = new List<Elements.Dropdown.Option>();

            foreach (var item in selectListItems)
                tempOfAutoViewOptionList.Add(item: Option.Generate(value: item.Value, text: item.Text,
                    isSelected: CheckOptionSelect(dropdownSelectedValue, optionValue: item.Value, isOptionSelected: item.Selected)));

            return tempOfAutoViewOptionList;
        }

        public static Elements.Dropdown.Dropdown Generate(Property property)
        {
            var dropdownInstance = property.Element as Elements.Dropdown.Dropdown;

            dropdownInstance.Options = InitialDropdownOptions(selectListItems: dropdownInstance.SelectListItems, dropdownSelectedValue: property.PropertyValue);

            dropdownInstance.Rendered = GenerateDropdownBody(dropdown: dropdownInstance) + Initial.RenderErrorElements(errorElements: property.ErrorElements);

            return dropdownInstance;
        }

        public static string GenerateOptionsBody(List<Elements.Dropdown.Option> options)
        {
            string tempOfOptionsBody = default;

            foreach (var option in options) tempOfOptionsBody += Option.Generate(value: option.Value, text: option.Text, isSelected: option.IsSelected).Rendered;

            return tempOfOptionsBody;
        }

        public static string GenerateDropdownBody(Elements.Dropdown.Dropdown dropdown)
        {
            return $"<select { Extensions.ElementName(dropdown.Name) }" +
                $"{ Extensions.ElementIdWithCssClass(cssId: dropdown.CssId, cssClass: dropdown.CssClass) }>" +
                $"{ GenerateOptionsBody(options: dropdown.Options) }</select>";
        }

        public static bool CheckOptionSelect(string dropdownSelectedValue, string optionValue, bool isOptionSelected)
        {
            if (dropdownSelectedValue is default(string)) return isOptionSelected;

            return dropdownSelectedValue.Equals(value: optionValue) ? true : false;
        }
    }
}
