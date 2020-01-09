using System;

namespace JobApproval
{
    public class JobProcessor
    {
        public bool Process(JobSheet jobSheet)
        {
            return jobSheet.TyresNeedingChange < 5 && BrakesCanBeChanged(jobSheet) && !(jobSheet.ExhaustsNeedingChange > 1);
        }

        private bool BrakesCanBeChanged(JobSheet jobSheet)
        {
            if (jobSheet.ChangeBrakePad || jobSheet.ChangeBrakeDisc)
            {
                return jobSheet.ChangeBrakePad && jobSheet.ChangeBrakeDisc;
            }
            return true;
        }
    }
}
