using Autoview.Elements.Dropdown;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autoview.Tests.ElementsEngine.Dropdown
{
    [TestClass]
    public class Option__Tests
    {
        [TestMethod]
        public void GenerateOptionBody__Test()
        {
            var value = "0";

            var text = "text";

            var optionInstance = new Option(value, text, isSelected: false);

            var actual = Autoview.ElementsEngine.Dropdown.Option.GenerateOptionBody(option: optionInstance);

            var expected = $"<option value=\"{ value }\">{ text }</option>";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Generate__Test()
        {
            var value = "0";

            var text = "text";

            var result = Autoview.ElementsEngine.Dropdown.Option.Generate(value, text, isSelected: false);

            var expected = $"<option value=\"{ value }\">{ text }</option>";

            Assert.AreEqual(expected, result.Rendered);
        }
    }
}
