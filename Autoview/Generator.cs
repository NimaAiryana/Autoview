using Autoview.Engine;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Autoview
{
    public class Generator
    {
        protected static string RenderView(Mainboard mainboard, ModelStateDictionary modelstate)
        {
            var properties = Property.InitPropertiesOfDto(mainboard, modelstate);

            string view = Validation.Initial.ValidationSummeryRender(modelstate)?.BoardElement?.Rendered;

            foreach (var property in properties) view += Partition.OrganizeSection(elementProperty: property);

            return view;
        }

        public static string View(Mainboard mainboard, ModelStateDictionary modelstate = default)
        {
            ValidateMainboard(mainboard);

            string view = default;

            view += RenderView(mainboard, modelstate);

            return view;
        }

        protected static void ValidateMainboard(Mainboard mainboard)
        {
            if (mainboard is null) throw new Exception(message: "mainboard is null");

            if (mainboard.AutoviewDto is null) throw new Exception(message: "autoview dto is null");
        }
    }
}