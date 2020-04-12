using Autoview.Elements;
using System.Collections.Generic;

namespace Autoview.Engine
{
    public class Mainboard
    {
        public Mainboard(IAutoviewDto autoviewDto)
        {
            AutoviewDto = autoviewDto;

            Elements = new List<AElement>();
        }

        public IAutoviewDto AutoviewDto { get; set; }

        public List<AElement> Elements { get; set; }
    }
}
