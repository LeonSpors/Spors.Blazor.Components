using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spors.Blazor.Charts
{
    public class DonutChartItem
    {
        public string Name { get; set; }

        public int Percentage { get; set; }

        public Color Fill { get; set; }
    }
}
