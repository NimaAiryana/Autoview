using Autoview.Elements.Inputs;
using Autoview.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autoview.Tests.Engine
{
    [TestClass]
    public class Partition__Tests
    {
        [TestMethod]
        public void OrganizeDivWithDisplayName__Test()
        {
            var displayName = "display";

            var result = Partition.OrganizeDivWithDisplayName(displayName);

            Assert.IsTrue(condition: result.Contains(value: $">{ displayName }<"));
        }

        [TestMethod]
        public void OrganizeDivWithElement__Test()
        {
            var textbox = new Textbox(name: default, value: default, displayName: default, cssId: default, cssClass: default);

            textbox.Rendered = Autoview.ElementsEngine.Textbox.GenerateTextboxBody(textbox);

            var result = Partition.OrganizeDivWithElement(element: textbox);

            Assert.IsTrue(condition: result.Rendered.Contains(value: "input type=\"text\""));
        }

        [TestMethod]
        public void OrganizeSection__Test()
        {
            var textbox = new Textbox(name: default, value: default, displayName: default, cssId: default, cssClass: default);

            textbox.Rendered = Autoview.ElementsEngine.Textbox.GenerateTextboxBody(textbox);

            var propertyInstance = new Property(propertyValue: default, element: textbox, propertyInfo: default);

            var result = Partition.OrganizeSection(elementProperty: propertyInstance);

            Assert.IsTrue(condition: result.Contains(value: "input type=\"text\""));
        }
    }
}
