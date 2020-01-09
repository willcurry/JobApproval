using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public class JobSheet
    {
        public int TyresNeedingChange { get; }
        public bool ChangeBrakeDisc { get; }
        public bool ChangeBrakePad { get; }
        public int ExhaustsNeedingChange { get; }

        public JobSheet(int tyresNeedingChange, bool changeBrakeDisc, bool changeBrakePad, int exhaustsNeedingChange)
        {
            TyresNeedingChange = tyresNeedingChange;
            ChangeBrakeDisc = changeBrakeDisc;
            ChangeBrakePad = changeBrakePad;
            ExhaustsNeedingChange = exhaustsNeedingChange;
        }
    }
}
