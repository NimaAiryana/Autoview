using Autoview.Tests.Fakes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autoview.Tests
{
    [TestClass]
    public class Generator__Tests
    {
        [TestMethod]
        public void View__Test()
        {
            var dto = new SampleDto();

            var modelstate = new ModelStateDictionary();

            modelstate.AddModelError(key: nameof(dto.FullName), errorMessage: $"{ nameof(dto.FullName) } is required");

            var result = Generator.View(dto.InitialElements(dto), modelstate);

            Assert.IsTrue(condition: result.Contains(value: "<input") && result.Contains(value: nameof(dto.FullName)));

            Assert.IsTrue(condition: result.Contains(value: "<span"));
        }
    }
}
