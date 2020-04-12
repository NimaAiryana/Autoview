using Autoview.Elements.Inputs;
using Autoview.Engine;
using Autoview.Tests.Fakes;
using Autoview.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autoview.Tests.ElementsEngine
{
    [TestClass]
    public class Textbox__Tests
    {
        [TestMethod]
        public void GetTextboxContent__Test()
        {
            var textboxName = "Property";

            var textboxValue = "Value";

            var textbox = new Textbox(name: textboxName, value: textboxValue, displayName: default, cssId: default, cssClass: default);

            var actual = Autoview.ElementsEngine.Textbox.GenerateTextboxBody(textbox);

            var expected = $"<input type=\"text\" name=\"{ textboxName }\" value=\"{ textboxValue }\" />";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Generate__Test()
        {
            var textboxName = "Property";

            var textboxValue = "Value";

            var textbox = new Textbox(name: textboxName, value: textboxValue, displayName: default, cssId: default, cssClass: default);

            var dto = new SampleDto();

            var propertyInfo = dto.GetType().GetProperty(name: nameof(dto.FullName));

            var property = new Property(propertyValue: textboxValue, element: textbox, propertyInfo);

            var result = Autoview.ElementsEngine.Textbox.Generate(property);

            var expected = $"<input type=\"text\" name=\"{ textboxName }\" value=\"{ textboxValue }\" />";

            Assert.AreEqual(expected, result.Rendered);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var textboxName = "Property";

            var textboxValue = "Value";

            var textbox = new Textbox(name: textboxName, value: textboxValue, displayName: default, cssId: default, cssClass: default);

            var dto = new SampleDto();

            var propertyInfo = dto.GetType().GetProperty(name: nameof(dto.FullName));

            var property = new Property(propertyValue: textboxValue, element: textbox, propertyInfo);

            var errorElement = new ErrorElement(Autoview.ElementsEngine.Span.Render(cssId: default, cssClass: default, spanContent: "Required"),
                new ModelError("Required"));

            property.ErrorElements = new List<ErrorElement>();

            property.ErrorElements.Add(item: errorElement);

            var result = Autoview.ElementsEngine.Textbox.Generate(property);

            var expectedElement = $"<input type=\"text\" name=\"{ textboxName }\" value=\"{ textboxValue }\" />";

            var expectedError = "<span>Required</span>";

            Assert.AreEqual(expected: expectedElement + expectedError, actual: result.Rendered);
        }
    }
}
