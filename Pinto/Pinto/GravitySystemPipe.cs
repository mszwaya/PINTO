using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinto
{
    public class GravitySystemPipe
    {
        // These are all properties that are read-only and defined by the class when it is created
        private CaseType _pipeFillScenario;
        private MeasurementType _depthMeasurementType;
        private double _pipeSlope;
        private double _pipeAngleInDegrees;
        private double _pipeAngleInRadians;
        private double _volume;
        private double _usce;
        private double _dsce;
        private CoverType _dsCover;
        private CoverType _usCover;
        private double _manholeSize;

        private double _diam_ft;
        private double _radius_ft;

        // private static readonly log4net.ILog log = LogHelper.GetLogger();

        // Distance along cylinder from sylinder bottom to measurement location
        /*
        private double distance_S_fromBottom;
        private double collectionOfTerms_G;
        private double Hdry;
        private double y2;
        private double y1;
        private double z2;
        private double z1;
        private double x2;
        private double x1;
        private double integralX;
        private double integralZ;
        private double integralY;
        */

        /// <summary>
        /// Lists the 3 possible states that a cylinder end will have with the liquid level
        /// </summary>
        public enum CoverType
        {
            Dry,
            Partial,
            Full
        };

        /// <summary>
        /// There are 3 methods for measuring liquid depth in an inclined cylinder
        /// Each method is applicable to 1 or more scenarios that are a function of the CoverTyper of each 
        /// end of the cylinder
        /// </summary>
        public enum MeasurementType
        {
            CylinderWall,
            LiquidSurface,
            AlongWall,
            NotNeeded
        };

        /// <summary>
        /// These are the 6 possible scenarios that a pipe can have if it contains any liquid
        /// Volume calculations are dependant on the scenario
        /// </summary>
        public enum CaseType
        {
            BottomFull_TopDry,
            BottomPartial_TopDry,
            BottomFull_TopPartial,
            BottomPartial_TopPartial,
            BottomFull_TopFull,
            BottomDry_TopDry
        };

        // Constructor (no overload)
        public GravitySystemPipe(int mlinkid, string usnode, string dsnode, double diam_in, double usie, double dsie, double length, double wse)
        {
            this.MLinkID = mlinkid;
            this.USNode = usnode;
            this.DSNode = dsnode;
            this.Diam_inches = diam_in;
            this.USIE = usie;
            this.DSIE = dsie;
            this.PipeLength = length;
            this.WSE = wse;
            this._diam_ft = Diam_inches / 12;
            this._radius_ft = _diam_ft / 2;
            this._manholeSize = setManholeSize();

            this._usce = USIE + (Diam_inches / 12);
            this._dsce = DSIE + (Diam_inches / 12);
            this._pipeSlope = (USIE - DSIE) / PipeLength;
            this._pipeAngleInRadians = Math.Asin(PipeSlope);
            this._pipeAngleInDegrees = PipeAngleInRadians * 180 / Math.PI;

            this._dsCover = setCoverType(DSIE,DSCE);
            this._usCover = setCoverType(USIE, USCE);

            this._pipeFillScenario = setPipeFillScenario();
            this._depthMeasurementType = setDepthMeasurementType();

            this._volume = calculateVolume();

        }

        public int MLinkID { get; private set; }
        public string USNode { get; private set; }
        public string DSNode { get; private set; }
        public double Diam_inches { get; private set; }
        public double USIE { get; private set; }
        public double DSIE { get; private set; }
        public double PipeLength { get; private set; }
        public double WSE { get; private set; }

        public double USCE
        {
            get { return _usce; }
            private set {_usce = value;}
        }

        public double DSCE
        {
            get { return _dsce; }
            private set {_dsce = value;}
        }

        public double PipeSlope
        {
            get { return _pipeSlope; }
            private set {_pipeSlope = value;}
        }

        public double PipeAngleInDegrees
        {
            get { return _pipeAngleInDegrees; }
            private set {_pipeAngleInDegrees = value;}
        }

        public double PipeAngleInRadians
        {
            get { return _pipeAngleInRadians; }
            private set {_pipeAngleInRadians = value;}
        }

        private double setManholeSize()
        {
            double thisManholeSize = 0;

            if (Diam_inches <= 30)
                thisManholeSize = 48;
            else if (Diam_inches <= 36)
                thisManholeSize = 60;
            else if (Diam_inches <= 48)
                thisManholeSize = 72;
            else if (Diam_inches <= 60)
                thisManholeSize = 84;
            else if (Diam_inches <= 72)
                thisManholeSize = 96;
            else if (Diam_inches <= 84)
                thisManholeSize = 108;
            else if (Diam_inches <= 96)
                thisManholeSize = 120;

            return thisManholeSize;
        }

        private CoverType setCoverType(double invert, double crown)
        {
            if (WSE > invert)
            {
                // end has some liquid in it.
                // Check how much
                if (WSE > crown)
                {
                    // WSE is higher than the  Crown.
                    // It is full
                    return CoverType.Full;
                }
                else
                {
                    // WSE is NOT higher than DS Crown
                    // It is partially full
                    return CoverType.Partial;
                }
            }
            else
            {
                // WSE is NOT greater than the DS Invert.
                // Bottom end is dry.
                return CoverType.Dry;
            }
        }

        private CaseType setPipeFillScenario()
        {
            if (DSCover == CoverType.Dry)
            {
                // Easy
                // If DS is dry, US must be dry (CASE 6).
                // No need to test any US conditions
                return CaseType.BottomDry_TopDry;
            }
            else 
            {
                // DS has some liquid in it
                if (DSCover == CoverType.Partial)
                {
                    if (USCover == CoverType.Dry)
                    {
                        // Bottom is Partial - Top is Dry (CASE 2)
                        return CaseType.BottomPartial_TopDry;
                    }
                    else if (USCover == CoverType.Partial)
                    {
                        // Bottom is partial & Top is partial (CASE 4)
                        // Prob. a shallow pipe where dy is < diam
                        return CaseType.BottomPartial_TopPartial;
                    }
                    else
                    {
                        // Bottom is partial and top is full?!
                        // Impossible scenario.  Assign nothing
                    }
                }
                else
                {
                    // DS Cover is full
                    if (USCover == CoverType.Dry)
                    {
                        // Bottom is Full - Top is Dry (CASE 1)
                        return CaseType.BottomFull_TopDry;
                    }
                    else if (USCover == CoverType.Partial)
                    {
                        // Bottom is full & Top is partial (CASE 3)
                        return CaseType.BottomFull_TopPartial;
                    }
                    else
                    {
                        // Bottom is full and top is full (CASE 5)
                        // Full pipe
                        return CaseType.BottomFull_TopFull;
                    }
                }
            }
            return CaseType.BottomDry_TopDry;
        }

        private MeasurementType setDepthMeasurementType()
        {
            MeasurementType thisMeasurementType;
            // Measurement type is dependant on the PipeFIllScenario
            switch (PipeFillScenario)
            {
                case CaseType.BottomFull_TopDry:
                case CaseType.BottomFull_TopPartial:
                    // The bottom is full
                    // We can measure along the cylinder walll
                    thisMeasurementType = MeasurementType.AlongWall;
                    break;
                case CaseType.BottomPartial_TopDry:
                case CaseType.BottomPartial_TopPartial:
                    // The bottom is partially full
                    // We will need to measure perpendicular to the cylinder wall
                    thisMeasurementType = MeasurementType.CylinderWall;
                    break;
                case CaseType.BottomDry_TopDry:
                case CaseType.BottomFull_TopFull:
                    // Pipe is totally dry OR completely full
                    // No depth measurement is needed for these scenarios
                    thisMeasurementType = MeasurementType.NotNeeded;
                    break;
                default:
                    thisMeasurementType = MeasurementType.NotNeeded;
                    break;
            }
            return thisMeasurementType;
        }

        public CoverType DSCover
        {
            get { return _dsCover; }
            private set {_dsCover = value;}
        }

        public CoverType USCover
        {
            get { return _usCover; }
            private set {_usCover = value;}
        }

        public CaseType PipeFillScenario
        {
            get { return _pipeFillScenario; }
            private set
            {_pipeFillScenario = value;}
        }

        public MeasurementType DepthMeasurementType
        {
            get { return _depthMeasurementType; }
            private set{_depthMeasurementType = value;}
        }

        private double calculateVolume()
        {
            double thisVolume = 0;

            // Let's archive the volume calculation using calculus for now.
            // Getting a number of errors related to Case 3 and Case 4.
            // Even Case 2 is failing when the D/S end of the pipe is just below full.
            // Need to do more research

            // Switch to a method of averages where the volume of the pipe is broken into 2 parts
            // 1 is the calculations for a full cylinder (easy)
            // 2 is the calculations for the pipe that is not full.
            
             // DS Depth
            double dsDepth = 0;
            if (DSCover == CoverType.Dry)
            { dsDepth = 0; }
            else
            {
                if (WSE > DSCE)
                { dsDepth = _diam_ft; }
                else
                { dsDepth = _diam_ft - (DSCE - WSE); }
            }

            // US Depth
            double usDepth = 0;
            if (WSE > USIE)
            { usDepth = WSE - USIE; }
            else
            { usDepth = 0; }

            // DS Area
            double dsArea = 0;
            if(DSCover==CoverType.Dry)
            { dsArea = 0; }
            else
            { dsArea = CircleArea(dsDepth); }

            // US Area
            double usArea = 0;
            if (USCover == CoverType.Full)
            { usArea = dsArea; }
            else
            { usArea = CircleArea(usDepth); }

            // Total Liquid Distance
            double totalDistance = 0;
            if (DSCover == CoverType.Dry)
            { totalDistance = 0; }
            else
            {
                if (((WSE - DSIE) / Math.Tan(PipeAngleInRadians)) > PipeLength)
                { totalDistance = PipeLength; }
                else
                { totalDistance = ((WSE - DSIE) / Math.Tan(PipeAngleInRadians)); }
            }

            // Pipe-Full Distance
            double pipeFullDistance = 0;
            if (USCover == CoverType.Full)
            { pipeFullDistance = PipeLength; }
            else
            {
                if (WSE > DSCE)
                { pipeFullDistance = ((WSE - DSCE) / Math.Tan(PipeAngleInRadians)); }
                else
                { pipeFullDistance = 0; }
            }

            // Pipe partially-full distance
            double partialFullDistance = totalDistance-pipeFullDistance;

            // Full Pipe Volume
            double fullPipeVolume = dsArea * pipeFullDistance;

            // Partial Pipe Volume
            // Just the average of the US and DS areas x the length
            double partialPipeVolume = partialFullDistance * ((dsArea - usArea) / 2);

            // Manhole Volume
            // Need to take MH Size and divide by 12 (in to ft) and 2 (diam to rad)
            double manholeVolume = 0;
            if (WSE > USIE)
            { 
                manholeVolume = ((WSE - USIE) * Math.PI * Math.Pow((_manholeSize/(2*12)) , 2)); 
            }
            else
            { manholeVolume = 0; }

            // Total Volume
            thisVolume = fullPipeVolume + partialPipeVolume + manholeVolume;
             
            /*
            switch (PipeFillScenario)
            {
                case CaseType.BottomFull_TopDry:
                    // CASE 1
                    // Bottom end covered, top end dry
                    // Since top end is dry, the volume is bounded in the upper z-direction
                    // by the liquid surface.

                    // Solve for the distance along the pipe crown where the liquid level rises to.
                    distance_S_fromBottom = (WSE - DSCE) / Math.Sin(PipeAngleInRadians);

                    // Solve for the collection of terms - G
                    collectionOfTerms_G = distance_S_fromBottom + (_radius_ft / Math.Tan(PipeAngleInRadians));

                    // All the nasty dz dx dy integrals even out to V = Pi * R^2 * G
                    // Do not ask me to prove it...
                    thisVolume = Math.PI * Math.Pow(_radius_ft, 2) * collectionOfTerms_G;

                    break;

                case CaseType.BottomPartial_TopDry:
                    // CASE 2
                    // Bottom end partially covered, top end dry
                    // Since top end is dry, the volume is bounded in the upper z-direction
                    // by the liquid surface.
                    // With bottom end partially covered, y1 = -Gtan(theta)

                    // Determine the horizontal distance, Dliquid, that the liquid level extends up the pipe.
                    // We will det the measurement distance, S, as 1/2 Dliquid.
                    // Determine depth at the DS Invert
                    double depthAtDS = WSE - DSIE;
                    // Calculate the horizontal distance, Dliquid, that the liquid level extends up the pipe.
                    double dLiquid = depthAtDS / Math.Sin(PipeAngleInRadians);
                    // Set S to 1/2 Dliquid
                    distance_S_fromBottom = dLiquid / 2;
                    // Since S is 1/2 D, Hwet will be 1/2 Depth at DS
                    double Hwet = depthAtDS / 2;
                    // Because we measure perpendicular to the cylinder wall, Hdry is diameter - Hwet
                    Hdry = _diam_ft - Hwet;
                    // Calculate G using the equation for measuring perpendicular to the cylinder wall
                    collectionOfTerms_G = distance_S_fromBottom + ((_radius_ft - Hdry) / Math.Tan(PipeAngleInRadians));

                    y1 = -collectionOfTerms_G * Math.Tan(PipeAngleInRadians);
                    y2 = _radius_ft;
                    x1 = -Math.Sqrt(Math.Pow(_radius_ft, 2) - Math.Pow(y1, 2));
                    x2 = -x1;
                    z1 = 0;
                    z2 = (y2 / Math.Tan(PipeAngleInRadians)) + collectionOfTerms_G;

                    integralZ = z2 - z1;
                    integralX = (x2 * integralZ) - (x1 * integralZ);
                    integralY = (y2 * integralX) - (y1 * integralX);

                    thisVolume = integralY;

                    break;

                case CaseType.BottomFull_TopPartial:
                    // CASE 3
                    // Bottom end covered, top end partially covered
                    // Since top end is partially covered, the integral is split into 2 parts.
                    // First part has the liquid surface as its upper limit.
                    // Second part is limited by the slanted cylinder top end.

                    // Solve for the distance from the DS pipe crown where the liquid level rises to.
                    distance_S_fromBottom = (WSE - DSCE) / Math.Sin(PipeAngleInRadians);
                    // Solve for the collection of terms - G
                    collectionOfTerms_G = distance_S_fromBottom + (_radius_ft / Math.Tan(PipeAngleInRadians));

                    // INTEGRAL 1
                    y2 = (PipeLength - collectionOfTerms_G) * Math.Tan(PipeAngleInRadians);
                    y1 = -_radius_ft;
                    x2 = Math.Sqrt(Math.Pow(_radius_ft, 2) - Math.Pow(y2, 2));
                    x1 = -x2;
                    z2 = (y2 / Math.Tan(PipeAngleInRadians)) + collectionOfTerms_G;
                    z1 = 0;

                    integralZ = z2 - z1;
                    integralX = (x2 * integralZ) - (x1 * integralZ);
                    integralY = (y2 * integralX) - (y1 * integralX);
                    thisVolume = integralY;

                    // INTEGRAL 2
                    // Some components remain unchanged.
                    y2 = _radius_ft;
                    y1 = (PipeLength - collectionOfTerms_G) * Math.Tan(PipeAngleInRadians);
                    z2 = PipeLength;

                    integralZ = z2 - z1;
                    integralX = (x2 * integralZ) - (x1 * integralZ);
                    integralY = (y2 * integralX) - (y1 * integralX);

                    thisVolume += integralY;

                    // US Manhole Volume
                    // We are going to assume that if the top end is partially covered, the US manhole is starting to fill
                    // Calculate the MH Volume by determining the liquid depth at the US end 
                    // Then multiply by the MH surface area (3 foot diam. MH assumed)
                    thisVolume += (Math.PI * Math.Pow(1.5, 2) * (WSE - USIE));

                    break;

                case CaseType.BottomPartial_TopPartial:
                    // CASE 4
                    // Bottom and top ends partially covered
                    // Same procedure as Case 3 where we need 2 integrals
                    // However, we will take the measuremend distance, S, ad PipeLength/2

                    distance_S_fromBottom = PipeLength / 2;
                    // Because we measure perpendicular to the cylinder wall, Hdry is diameter - Hwet
                    // Hwet = WSE - (S x Sin(PipeAngle))
                    Hdry = _diam_ft - (WSE - (distance_S_fromBottom * Math.Sin(PipeAngleInRadians)));
                    // Calculate G using the equation for measuring perpendicular to the cylinder wall
                    collectionOfTerms_G = distance_S_fromBottom + ((_radius_ft - Hdry) / Math.Tan(PipeAngleInRadians));

                    // INTEGRAL 1
                    y2 = (PipeLength - collectionOfTerms_G) * Math.Tan(PipeAngleInRadians);
                    y1 = -(collectionOfTerms_G * Math.Tan(PipeAngleInRadians));
                    x2 = Math.Sqrt(Math.Pow(_radius_ft, 2) - Math.Pow(y2, 2));
                    x1 = -x2;
                    z2 = (y2 / Math.Tan(PipeAngleInRadians)) + collectionOfTerms_G;
                    z1 = 0;

                    integralZ = z2 - z1;
                    integralX = (x2 * integralZ) - (x1 * integralZ);
                    integralY = (y2 * integralX) - (y1 * integralX);
                    thisVolume = integralY;

                    // INTEGRAL 2
                    // Some components remain unchanged.
                    y2 = _radius_ft;
                    y1 = (PipeLength - collectionOfTerms_G) * Math.Tan(PipeAngleInRadians);
                    z2 = PipeLength;

                    integralZ = z2 - z1;
                    integralX = (x2 * integralZ) - (x1 * integralZ);
                    integralY = (y2 * integralX) - (y1 * integralX);

                    thisVolume += integralY;

                    // US Manhole Volume
                    // We are going to assume that if the top end is partially covered, the US manhole is starting to fill
                    // Calculate the MH Volume by determining the liquid depth at the US end 
                    // Then multiply by the MH surface area (3 foot diam. MH assumed)
                    thisVolume += (Math.PI * Math.Pow(1.5, 2) * (WSE - USIE));

                    break;

                case CaseType.BottomFull_TopFull:
                    // CASE 5
                    // Pipe is full
                    // Easy peasy
                    thisVolume = Math.PI * Math.Pow(_radius_ft, 2) * PipeLength;

                    // US Manhole Volume
                    // We are going to assume that if the top end is covered, the US manhole is holding some volume
                    // Calculate the MH Volume by determining the liquid depth at the US end 
                    // Then multiply by the MH surface area (3 foot diam. MH assumed)
                    thisVolume += (Math.PI * Math.Pow(1.5, 2) * (WSE - USIE));

                    break;

                case CaseType.BottomDry_TopDry:
                    // CASE 6
                    // Pipe is empty
                    thisVolume = 0;
                    break;
            } // close Switch
             */
            // Finally...
            return thisVolume;
        }

        public double Volume
        {
            get { return _volume; }
            private set{_volume = value;}
        }

        private double CircleArea(double depth)
        {
            double thisArea = 0;

            double part1a = Math.Pow(_radius_ft, 2);
            double part1b = Math.Acos((_radius_ft - depth) / _radius_ft);
            double part1 = part1a * part1b;

            double part2a = _radius_ft - depth;
            double part2b = Math.Sqrt((2 * _radius_ft * depth) - Math.Pow(depth, 2));
            double part2 = part2a * part2b;

            thisArea = part1-part2;

            return thisArea;
        }

    }
}
