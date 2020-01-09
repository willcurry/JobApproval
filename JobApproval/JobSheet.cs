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

        public JobSheet()
        {
        }

        public bool RequiresBrakeDiscChange()
        {
            return BrakeDisc >= 1;
        }

        public bool RequiresBrakePadChange()
        {
            return BrakePad >= 1;
        }
    }
}
