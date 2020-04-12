using Autoview.ElementsEngine;
using Autoview.Engine;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autoview.Validation
{
    public class Initial
    {
        public static string RenderErrorElements(List<ErrorElement> errorElements)
        {
            if (errorElements is null) return null;

            string tempOfSummery = default;

            errorElements.ForEach(action: error => tempOfSummery += error.Element.Rendered);

            return tempOfSummery;
        }

        public static ModelErrorCollection InitErrorCollection(ModelStateDictionary modelstate, string propertyName)
        {
            if (modelstate is null) return null;

            var modelstateValue = modelstate.Where(model => model.Key == propertyName).FirstOrDefault().Value;

            return modelstateValue?.Errors;
        }

        public static List<ErrorElement> InitPropertyErrorElements(ModelErrorCollection errors)
        {
            if (errors is null) return null;

            var tempOfErrorElements = new List<ErrorElement>();

            foreach (var error in errors)
                tempOfErrorElements.Add(item: new ErrorElement(element: Span.Render(cssId: default, cssClass: default, spanContent: error.ErrorMessage), error));

            return tempOfErrorElements;
        }

        public static List<ModelError> GetModelStateAllModelErrors(ModelStateDictionary modelstate)
        {
            var tempOfModelErrors = new List<ModelError>();

            modelstate.Where(model => model.Value.ValidationState == ModelValidationState.Invalid).ToList()
                .ForEach(modelEntity => modelEntity.Value.Errors.ToList().ForEach(error => tempOfModelErrors.Add(item: error)));

            return tempOfModelErrors;
        }

        public static List<ErrorElement> ValidationSummeryErrors(ModelStateDictionary modelstate)
        {
            var tempOfErrorElements = new List<ErrorElement>();

            foreach (var error in GetModelStateAllModelErrors(modelstate))
                tempOfErrorElements.Add(item: new ErrorElement(Span.Render(cssId: default, cssClass: default, spanContent: error.ErrorMessage), error));

            return tempOfErrorElements;
        }

        public static ErrorBoard ValidationSummeryRender(ModelStateDictionary modelstate)
        {
            if (modelstate is null) return null;

            var validationSummeryErrors = ValidationSummeryErrors(modelstate);

            string renderElements = RenderErrorElements(errorElements: validationSummeryErrors);

            var boardDivElement = ElementsEngine.Div.Render(divContent: renderElements, id: default, cssClass: default);

            return new ErrorBoard(boardElement: boardDivElement, errors: validationSummeryErrors);
        }
    }
}
