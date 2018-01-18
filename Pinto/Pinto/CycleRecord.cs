using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinto
{
    class CycleRecord
    {

        public CycleRecord()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station_id"></param>
        /// <param name="pump_id"></param>
        /// <param name="cycle_change_time"></param>
        /// <param name="onoff_state"></param>
        /// <param name="delta_t"></param>
        /// <param name="pumpTime"></param>
        /// <param name="fillTime"></param>
        public CycleRecord(short station_id,
                            short pump_id,
                            DateTime cycle_change_time,
                            bool onoff_state,
                            long delta_t,
                            long pumpTime,
                            long fillTime)
        {
            Station_ID = station_id;
            Pump_ID = pump_id;
            CycleChangeTime = cycle_change_time;
            OnOff_State = onoff_state;
            DeltaT = delta_t;
            RunTime = pumpTime;
            FillTime = fillTime;
        }
 
        public string Location { get; set; }
        public short Station_ID { get; set; }
        public short Pump_ID { get; set; }
        public DateTime CycleChangeTime { get; set; }
        public bool OnOff_State { get; set; }
        public string RecordStatus { get; set; }
        public long DeltaT { get; set; }
        public long RunTime { get; set; }
        public long FillTime { get; set; }
        public bool DuplicateCycle { get; set; }
        public bool AddOnCycle { get; set; }
        public bool AddOffCycle { get; set; }
        public bool DeletePrevCycle { get; set; }
        public bool MultiPump { get; set; }
        public bool ShortCycle { get; set; }
        public decimal FlowRate { get; set; }
        public bool IsDirty { get; set; }
    }
}
