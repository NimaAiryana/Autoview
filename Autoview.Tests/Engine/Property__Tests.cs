using Autoview.Elements.Inputs;
using Autoview.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autoview.Tests.Engine
{
    [TestClass]
    public class Property__Tests
    {
        [TestMethod]
        [ExpectedException(exceptionType: typeof(Exception))]
        public void GerPropertyInfoOfDtoByName__Test()
        {
            var dto = new Fakes.SampleDto();

            var actual = Property.GetPropertyInfoOfDtoByName(dto, propertyName: "NotExist");
        }

        [TestMethod]
        public void InitProperty__Test()
        {
            var dto = new Fakes.SampleDto();

            var element = new Textbox(name: nameof(dto.FullName), value: default, displayName: default, cssId: default, cssClass: default);

            var result = Property.InitProperty(dto, element, null);

            Assert.IsNotNull(value: result);

            Assert.IsInstanceOfType(value: result, expectedType: typeof(Property));

            Assert.IsNotNull(value: result.Element.Rendered);
        }

        [TestMethod]
        public void InitPropertiesOfDto__Test()
        {
            var dto = new Fakes.SampleDto();

            var mainboard = new Mainboard(dto);

            var element = new Textbox(name: nameof(dto.FullName), value: default, displayName: default, cssId: default, cssClass: default);

            mainboard.Elements.Add(item: element);

            var result = Property.InitPropertiesOfDto(mainboard, modelstate: null);

            Assert.IsNotNull(value: result);

            Assert.IsTrue(condition: result.Count > 0);
        }
    }
}
