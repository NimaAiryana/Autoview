using Autoview.Engine;
using System;

namespace Autoview.Elements
{
    public abstract class AElement
    {
        public Type Type { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string CssId { get; set; }

        public string CssClass { get; set; }

        public string DisplayName { get; set; }

        public string Rendered { get; set; }


        public abstract AElement InitialElement(Property property);
    }
}
