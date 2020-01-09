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

            return jobSheet.Tyres < 5 && !(jobSheet.Exhaust > 1);
        }

        private int GetMinutes(string itemID)
        {
            Item item = ReferenceData.GetItem(itemID);
            return item.Time;
        }

        public int GetLabourHours(JobSheet jobSheet)
        {
            int minutes = jobSheet.Tyres * GetMinutes("tyre") 
                + jobSheet.BrakeDisc * GetMinutes("brake disc")
                + jobSheet.BrakePad * GetMinutes("brake pad") 
                + jobSheet.Oil * GetMinutes("oil") 
                + jobSheet.Exhaust * GetMinutes("exhaust");
            return minutes / 60;
        }

        private bool CheckLabourTime(JobSheet jobSheet)
        {
            return jobSheet.TotalHours <= GetLabourHours(jobSheet);
        }
    }
}
