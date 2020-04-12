using Autoview.Engine;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Autoview.Tests.Fakes
{
    public class SampleDto : IAutoviewDto
    {
        public string FullName { get; set; }

        public string Dropdown { get; set; }


        public Mainboard InitialElements(IAutoviewDto dto)
        {
            dto.InitialDto();

            dto.Textbox(nameof(FullName));

            dto.Dropdown(propertyName: nameof(Dropdown), selectListItems: DropdownItems());

            return Initializer.Return();
        }

        public static List<SelectListItem> DropdownItems()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem(text: "text", value: "0")
            };
        }
    }
}
