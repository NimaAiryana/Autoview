using Autoview.ElementsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autoview.Tests.ElementsEngine
{
    [TestClass]
    public class Span__Tests
    {
        [TestMethod]
        public void RenderSpanBody__Test()
        {
            var spanContent = "hi";

            var actual = Span.RenderSpanBody(cssId: default, cssClass: default, spanContent);

            var expected = $"<span>{ spanContent }</span>";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Render__Test()
        {
            var spanContent = "hi";

            var result = Span.Render(cssId: default, cssClass: default, spanContent);

            var expected = $"<span>{ spanContent }</span>";

            Assert.IsInstanceOfType(value: result, expectedType: typeof(Elements.Span));

            Assert.AreEqual(expected, result.Rendered);
        }
    }
}
