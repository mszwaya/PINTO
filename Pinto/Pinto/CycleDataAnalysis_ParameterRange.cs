using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinto
{
    public class CycleDataAnalysis_ParameterRange
    {
        public CycleDataAnalysis_ParameterRange(string location,
                                        double upperQ,
                                        double lowerQ,
                                        double upperV,
                                        double lowerV,
                                        int intervals)
        {
            this.Location = location;
            this.UpperQ = upperQ;
            this.LowerQ = lowerQ;
            this.UpperV = upperV;
            this.LowerV = lowerV;
            this.Intervals = intervals;
        }

        public string Location { get; set; }
        public double UpperQ { get; set; }
        public double LowerQ { get; set; }
        public double UpperV { get; set; }
        public double LowerV { get; set; }
        public int Intervals { get; set; }
    }
}
