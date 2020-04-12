using Autoview.Elements;
using Autoview.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Autoview.Tests.Validation
{
    [TestClass]
    public class Initial__Tests
    {
        [TestMethod]
        public void RenderErrorElements__Test()
        {
            var propertyName = "Property";

            var modelstate = new ModelStateDictionary();

            modelstate.AddModelError(key: propertyName, errorMessage: $"{ propertyName } is required");

            var result = Initial.RenderErrorElements(errorElements: Initial.ValidationSummeryErrors(modelstate));

            Assert.IsTrue(condition: result.Contains(value: propertyName));
        }

        [TestMethod]
        public void InitErrorCollection__Test()
        {
            var propertyName = "Property";

            var modelstate = new ModelStateDictionary();

            modelstate.AddModelError(key: propertyName, errorMessage: $"{ propertyName } is required");

            var result = Initial.InitErrorCollection(modelstate, propertyName);

            Assert.IsTrue(condition: result.Count > 0);
        }

        [TestMethod]
        public void InitProeprtyErrorElements__Test()
        {
            var propertyName = "Property";

            var modelstate = new ModelStateDictionary();

            modelstate.AddModelError(key: propertyName, errorMessage: $"{ propertyName } is required");

            var result = Initial.InitPropertyErrorElements(errors: modelstate.First().Value.Errors);

            Assert.IsTrue(condition: result.Count > 0);

            Assert.IsTrue(condition: result.First().Element.GetType() == typeof(Span));
        }

        [TestMethod]
        public void GetModelStateAlModelErrors__Test()
        {
            var propertyName = "Property";

            var modelstate = new ModelStateDictionary();

            modelstate.AddModelError(key: propertyName, errorMessage: $"{ propertyName } is required");

            var result = Initial.GetModelStateAllModelErrors(modelstate);

            Assert.IsTrue(condition: result.Count > 0);

            Assert.IsTrue(condition: result.First().ErrorMessage.Contains(value: propertyName));
        }

        [TestMethod]
        public void ValidationSummeryErrors__Test()
        {
            var propertyName = "Property";

            var modelstate = new ModelStateDictionary();

            modelstate.AddModelError(key: propertyName, errorMessage: $"{ propertyName } is required");

            var result = Initial.ValidationSummeryErrors(modelstate);

            Assert.IsTrue(condition: result.Count > 0);

            Assert.IsTrue(condition: result.First().Element.Rendered.Contains(value: propertyName));
        }

        [TestMethod]
        public void ValidationSummeryRender__Test()
        {
            var propertyName = "Property";

            var modelstate = new ModelStateDictionary();

            modelstate.AddModelError(key: propertyName, errorMessage: $"{ propertyName } is required");

            var result = Initial.ValidationSummeryRender(modelstate);

            Assert.IsTrue(condition: result.BoardElement.Rendered.Contains(value: propertyName));
        }
    }
}
