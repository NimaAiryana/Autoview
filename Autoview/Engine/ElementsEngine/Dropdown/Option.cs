using Autoview.Engine;

namespace Autoview.ElementsEngine.Dropdown
{
    public class Option
    {
        public static string GenerateOptionBody(Elements.Dropdown.Option option)
        {
            return $"<option { Extensions.ElementValue(value: option.Value) }{ Extensions.PrintSelectedElementAttribute(option.IsSelected) }>{ option.Text }</option>";
        }

        public static Elements.Dropdown.Option Generate(string value, string text, bool isSelected)
        {
            var newOptionElementInstance = new Elements.Dropdown.Option(value: value, text: text, isSelected: isSelected);

            newOptionElementInstance.Rendered = GenerateOptionBody(option: newOptionElementInstance);

            return newOptionElementInstance;
        }
    }
}
