using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public class JobSheet
    {
        public int TyresNeedingChange { get; }

        public JobSheet(int tyresNeedingChange)
        {
            TyresNeedingChange = tyresNeedingChange;
        }
    }
}
