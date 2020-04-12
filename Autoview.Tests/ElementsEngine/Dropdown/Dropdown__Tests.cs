using Autoview.Elements.Dropdown;
using Autoview.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Autoview.Tests.ElementsEngine.Dropdown
{
    [TestClass]
    public class Dropdown__Tests
    {
        [TestMethod]
        public void InitialDropdownOptions__Test()
        {
            var dto = new Fakes.SampleDto();

            var mainboard = dto.InitialElements(dto);

            var findDropdownElement = mainboard.Elements.First(element => element.GetType() == typeof(Elements.Dropdown.Dropdown)) as Elements.Dropdown.Dropdown;

            var result = Autoview.ElementsEngine.Dropdown.Dropdown.InitialDropdownOptions(selectListItems: findDropdownElement.SelectListItems, dropdownSelectedValue: default);

            Assert.IsTrue(condition: result.Count > 0);
        }

        [TestMethod]
        public void GenerateOptionsBody__Test()
        {
            var dto = new Fakes.SampleDto();

            var mainboard = dto.InitialElements(dto);

            var findDropdownElement = mainboard.Elements.First(element => element.GetType() == typeof(Elements.Dropdown.Dropdown)) as Elements.Dropdown.Dropdown;

            var dropdownOptions = Autoview.ElementsEngine.Dropdown.Dropdown.InitialDropdownOptions(selectListItems: findDropdownElement.SelectListItems, dropdownSelectedValue: default);

            var result = Autoview.ElementsEngine.Dropdown.Dropdown.GenerateOptionsBody(options: dropdownOptions);

            Assert.IsNotNull(value: result);
        }

        [TestMethod]
        public void GenerateDropdownBody__Test()
        {
            var dto = new Fakes.SampleDto();

            var mainboard = dto.InitialElements(dto);

            var findDropdownElement = mainboard.Elements.First(element => element.GetType() == typeof(Elements.Dropdown.Dropdown)) as Elements.Dropdown.Dropdown;

            var dropdownOptions = Autoview.ElementsEngine.Dropdown.Dropdown.InitialDropdownOptions(selectListItems: findDropdownElement.SelectListItems, dropdownSelectedValue: default);

            findDropdownElement.Options = dropdownOptions;

            var result = Autoview.ElementsEngine.Dropdown.Dropdown.GenerateDropdownBody(dropdown: findDropdownElement);

            Assert.IsTrue(condition: result.Contains($"option value=\"0\""));
        }

        [TestMethod]
        public void CheckOptionSelect_SelectedIsDefault__Test()
        {
            var dropdownSelectedValue = default(string);

            var optionValue = "1";

            var isOptionSelected = true;

            var resultIsTrue = Autoview.ElementsEngine.Dropdown.Dropdown.CheckOptionSelect(dropdownSelectedValue, optionValue, isOptionSelected);

            Assert.IsTrue(condition: resultIsTrue);
        }

        [TestMethod]
        public void CheckOptionSelect_SelectedDropdown__Test()
        {
            var dropdownSelectedValue = "0";

            var optionValue = "1";

            var isOptionSelected = true;

            var resultIsFalse = Autoview.ElementsEngine.Dropdown.Dropdown.CheckOptionSelect(dropdownSelectedValue, optionValue, isOptionSelected);

            Assert.IsFalse(condition: resultIsFalse);
        }

        [TestMethod]
        public void Generate__Test()
        {
            var dto = new Fakes.SampleDto();

            var mainboard = dto.InitialElements(dto);

            var findDropdownElement = mainboard.Elements.First(element => element.GetType() == typeof(Elements.Dropdown.Dropdown)) as Elements.Dropdown.Dropdown;

            var propertyInfo = Extensions.GetPropertyInfoByName(dto, propertyName: nameof(dto.Dropdown));

            var propertyInstance = new Property(propertyValue: default, element: findDropdownElement, propertyInfo);

            var result = Autoview.ElementsEngine.Dropdown.Dropdown.Generate(property: propertyInstance);

            Assert.IsInstanceOfType(value: result, expectedType: typeof(Elements.Dropdown.Dropdown));

            Assert.IsTrue(condition: result.Rendered.Contains("option"));
        }
    }
}
