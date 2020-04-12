using Autoview.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autoview.Tests.ElementsEngine
{
    [TestClass]
    public class Div__Tests
    {
        [TestMethod]
        public void GenerateDivBody__Test()
        {
            var content = "content";

            var actual = Autoview.ElementsEngine.Div.GenerateDivBody(id: default, cssClass: default, content);

            var expected = $"<div>{ content }</div>";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetDivWithElement__Test()
        {
            var result = Autoview.ElementsEngine.Div.Generate(element: default, id: default, cssClass: default);

            var expected = "<div></div>";

            Assert.AreEqual(expected, result.Rendered);
        }
    }
}
