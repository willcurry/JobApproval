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

        public JobSheet(int tyresNeedingChange, bool changeBrakeDisc, bool changeBrakePad)
        {
            TyresNeedingChange = tyresNeedingChange;
            ChangeBrakeDisc = changeBrakeDisc;
            ChangeBrakePad = changeBrakePad;
        }
    }
}
