using Autoview.Engine;

namespace Autoview.Elements.Dropdown
{
    public class Option : AElement
    {
        public Option(string value, string text, bool isSelected)
        {
            Type = typeof(Dropdown);

            Value = value;

            Text = text;

            IsSelected = isSelected;
        }

        public string Text { get; private set; }

        public bool IsSelected { get; private set; }

        public override AElement InitialElement(Property property)
        {
            var option = property.Element as Option;

            return ElementsEngine.Dropdown.Option.Generate(option.Value, option.Text, option.IsSelected);
        }
    }
}
