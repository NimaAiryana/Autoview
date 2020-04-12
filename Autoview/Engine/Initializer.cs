using Autoview.Elements;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Autoview.Engine
{
    public static partial class Initializer
    {
        public static Mainboard Mainboard { get; set; }

        public static void InitialDto(this IAutoviewDto autoviewDto)
        {
            Mainboard = new Mainboard(autoviewDto: autoviewDto);
        }

        public static Mainboard Return()
        {
            var mainboard = Mainboard;

            Mainboard = null;

            return mainboard;
        }

        public static void InitalElement(this IAutoviewDto autoviewDto, AElement element)
        {
            Mainboard.Elements.Add(item: element);
        }

        public static void Textbox
            (this IAutoviewDto autoviewDto, string propertyName, string displayName = default, string cssId = default, string cssClass = default)
        {
            string propertyValue = Extensions.GetPropertyValue(autoviewDto, propertyName);

            var textboxInstance = new Elements.Inputs.Textbox(propertyName, propertyValue, displayName, cssId, cssClass);

            autoviewDto.InitalElement(element: textboxInstance);
        }

        public static void Dropdown
            (this IAutoviewDto autoviewDto, string propertyName, List<SelectListItem> selectListItems, string displayName = default, string cssId = default, string cssClass = default)
        {
            string propertyValue = Extensions.GetPropertyValue(autoviewDto, propertyName);

            var dropdownInstance = new Elements.Dropdown.Dropdown(propertyName, propertyValue, selectListItems, displayName, cssId, cssClass);

            autoviewDto.InitalElement(element: dropdownInstance);
        }

    }
}
