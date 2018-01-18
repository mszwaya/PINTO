using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinto
{
    public class CycleDataAnalysis_Parameter
    {
        public CycleDataAnalysis_Parameter(double qPump, double vWW)
        {
            this.Qpump = qPump;
            this.Vww = vWW;
        }

        public CycleDataAnalysis_Parameter(string location, double qPump, double vWW)
        {
            this.Location = location;
            this.Qpump = qPump;
            this.Vww = vWW;
        }

        public string Location { get; set; }
        public double Qpump { get; set; }
        public double Vww { get; set; }

        public override string ToString()
        {
            return String.Format("{0}:{1}", Qpump.ToString(), Vww.ToString());
        }
    }
}
