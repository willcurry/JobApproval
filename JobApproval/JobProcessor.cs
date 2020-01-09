using System;

namespace JobApproval
{
    public class JobProcessor
    {
        public bool Process(JobSheet jobSheet)
        {
            return jobSheet.TyresNeedingChange < 5;
        }
    }
}
