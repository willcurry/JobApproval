using System;

namespace JobApproval
{
    public class JobProcessor
    {
        private IReferenceData ReferenceData;

        public JobProcessor(IReferenceData referenceData)
        {
            ReferenceData = referenceData;
        }

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

            return jobSheet.CountItems("tyre") < 5 && !(jobSheet.CountItems("exhaust") > 1);
        }

        private int GetMinutes(string itemID)
        {
            return ReferenceData.GetTime(itemID);
        }

        public int GetLabourHours(JobSheet jobSheet)
        {
            int minutes = 0;
            foreach (JobItem item in jobSheet.Items)
            {
                minutes += ReferenceData.GetTime(item.ID);
            }
            return minutes / 60;
        }

        private bool CheckLabourTime(JobSheet jobSheet)
        {
            return jobSheet.TotalHours <= GetLabourHours(jobSheet);
        }
    }
}
