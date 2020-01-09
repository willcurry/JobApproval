using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public class JobSheet
    {
        public int Tyres { get; set; }
        public int BrakeDisc { get; set; }
        public int BrakePad { get; set; }
        public int Exhaust { get; set; }
        public int Oil { get; set; }
        public int TotalHours;

        public JobSheet(int totalHours)
        {
            Tyres = 0;
            BrakeDisc = 0;
            BrakePad = 0;
            Exhaust = 0;
            Oil = 0;
            TotalHours = totalHours;
        }

        public bool RequiresBrakeDiscChange()
        {
            return BrakeDisc >= 1;
        }

        public bool RequiresBrakePadChange()
        {
            return BrakePad >= 1;
        }

        public int GetLabourHours()
        {
            int minutes = Tyres * 30 + BrakeDisc * 90 + BrakePad * 60 + Oil * 30 + Exhaust * 240;
            return minutes / 60;
        }
    }
}
