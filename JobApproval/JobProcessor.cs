using System;

namespace JobApproval
{
    public class JobProcessor
    {
        public bool Process(JobSheet jobSheet)
        {
            return jobSheet.Tyres < 5 && BrakesCanBeChanged(jobSheet) && !(jobSheet.Exhaust > 1);
        }

        private bool BrakesCanBeChanged(JobSheet jobSheet)
        {
            if (jobSheet.RequiresBrakeDiscChange() || jobSheet.RequiresBrakePadChange())
            {
                return jobSheet.RequiresBrakeDiscChange() && jobSheet.RequiresBrakePadChange();
            }
            return true;
        }
    }
}
