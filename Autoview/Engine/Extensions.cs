using System.Reflection;

namespace Autoview.Engine
{
    public class Extensions
    {
        public static string ElementName(string name)
        {
            return $"name=\"{ name }\"";
        }

        public static string ElementValue(string value)
        {
            return $"value=\"{ value }\"";
        }

        public static string ElementId(string cssId)
        {
            return cssId is default(string) ? default(string) : $"id=\"{ cssId }\"";
        }

        public static string ElementCssClass(string cssClass)
        {
            return cssClass is default(string) ? default(string) : $"class=\"{ cssClass }\"";
        }

        public static string ElementIdWithCssClass(string cssId, string cssClass)
        {
            string idWithCssClassTemp = default;

            if (!string.IsNullOrEmpty(cssId)) idWithCssClassTemp += $" { ElementId(cssId: cssId) }";

            if (!string.IsNullOrEmpty(cssClass)) idWithCssClassTemp += $" { ElementCssClass(cssClass: cssClass) }";

            return idWithCssClassTemp;
        }

        public static string PrintSelectedElementAttribute(bool isSelected)
        {
            if (isSelected is false) return default(string);

            return " selected";
        }

        public static PropertyInfo[] ArrayOfPropertyInfos(IAutoviewDto autoviewDto)
        {
            return autoviewDto.GetType().GetProperties();
        }

        public static PropertyInfo GetPropertyInfoByName(IAutoviewDto autoviewDto, string propertyName)
        {
            return autoviewDto.GetType().GetProperty(name: propertyName);
        }

        public static string GetPropertyValue(IAutoviewDto autoviewDto, PropertyInfo propertyInfo)
        {
            var propertyValue = propertyInfo.GetValue(obj: autoviewDto);

            if (propertyValue is null) return default;

            return propertyValue.ToString();
        }

        public static string GetPropertyValue(IAutoviewDto autoviewDto, string propertyName)
        {
            return GetPropertyValue(autoviewDto, propertyInfo: GetPropertyInfoByName(autoviewDto, propertyName));
        }

    }
}