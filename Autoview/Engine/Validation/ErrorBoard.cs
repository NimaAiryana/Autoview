using Autoview.Elements;
using Autoview.Validation;
using System.Collections.Generic;

namespace Autoview.Validation
{
    public class ErrorBoard
    {
        public ErrorBoard(AElement boardElement, List<ErrorElement> errors)
        {
            BoardElement = boardElement;

            Errors = errors;
        }


        public AElement BoardElement { get; set; }

        public List<ErrorElement> Errors { get; set; }
    }
}
