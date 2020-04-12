using Autoview.Elements;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Autoview.Validation
{
    public class ErrorElement
    {
        public ErrorElement(AElement element, ModelError error)
        {
            Element = element;

            Error = error;
        }


        public AElement Element { get; set; }

        public ModelError Error { get; set; }
    }
}
