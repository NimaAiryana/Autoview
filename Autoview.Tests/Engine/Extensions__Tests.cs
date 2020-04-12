using Autoview.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autoview.Tests.Engine
{
    [TestClass]
    public class Extensions__Tests
    {
        [TestMethod]
        public void ElementName__Test()
        {
            var name = "fullname";

            var result = Extensions.ElementName(name);

            Assert.AreEqual(expected: $"name=\"{ name }\"", actual: result);
        }

        [TestMethod]
        public void ElementValue__Test()
        {
            var value = "fullname";

            var result = Extensions.ElementValue(value);

            Assert.AreEqual(expected: $"value=\"{ value }\"", actual: result);
        }

        [TestMethod]
        public void ElementId__Test()
        {
            var id = "fullname";

            var result = Extensions.ElementId(id);

            Assert.AreEqual(expected: $"id=\"{ id }\"", actual: result);
        }

        [TestMethod]
        public void ElementCssClass__Test()
        {
            var cssClass = "fullname";

            var result = Extensions.ElementCssClass(cssClass);

            Assert.AreEqual(expected: $"class=\"{ cssClass }\"", actual: result);
        }

        [TestMethod]
        public void ElementIdWithCssClass__Test()
        {
            var cssClass = "fullname";

            var result = Extensions.ElementIdWithCssClass(cssId: default, cssClass);

            Assert.IsNotNull(value: result);
        }

        [TestMethod]
        public void PrintSelectedElementAttribute__Test()
        {
            var isSelected = true;

            var result = Extensions.PrintSelectedElementAttribute(isSelected);

            Assert.IsNotNull(value: result);

            Assert.AreEqual(expected: " selected", actual: result);
        }

        [TestMethod]
        public void ArrayOfPropetyInfos__Test()
        {
            var dto = new Fakes.SampleDto();

            var actual = Extensions.ArrayOfPropertyInfos(dto);

            Assert.IsTrue(condition: actual.Length > 0);
        }

        [TestMethod]
        public void GetPropertyInfoByName__Test()
        {
            var dto = new Fakes.SampleDto();

            var actual = Extensions.GetPropertyInfoByName(dto, propertyName: nameof(dto.FullName));

            Assert.IsNotNull(value: actual);
        }

        [TestMethod]
        public void GetPropertyValue__Test()
        {
            var dto = new Fakes.SampleDto();

            var propertyInfo = Extensions.GetPropertyInfoByName(dto, propertyName: nameof(dto.FullName));

            var actual = Extensions.GetPropertyValue(dto, propertyInfo);

            Assert.IsNull(value: actual);
        }

        [TestMethod]
        public void GetPropretyValue_ByPropertyName__Test()
        {
            var dto = new Fakes.SampleDto();

            var actual = Extensions.GetPropertyValue(dto, propertyName: nameof(dto.FullName));

            Assert.IsNull(value: actual);
        }




    }
}
