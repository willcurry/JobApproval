using System;

namespace JobApproval
{
    public class JobProcessor
    {
        public bool Process(JobSheet jobSheet)
        {
            return CheckLimits(jobSheet) && BrakesCanBeChanged(jobSheet) && CheckLabourTime(jobSheet);
        }

        private bool BrakesCanBeChanged(JobSheet jobSheet)
        {
            if (jobSheet.RequiresBrakeDiscChange() || jobSheet.RequiresBrakePadChange())
            {
                return jobSheet.RequiresBrakeDiscChange() && jobSheet.RequiresBrakePadChange();
            }
            return true;
        }

        private bool CheckLimits(JobSheet jobSheet)
        {

            return jobSheet.Tyres < 5 && !(jobSheet.Exhaust > 1);
        }

        private bool CheckLabourTime(JobSheet jobSheet)
        {
            return jobSheet.TotalHours <= jobSheet.GetLabourHours();
        }
    }
}
