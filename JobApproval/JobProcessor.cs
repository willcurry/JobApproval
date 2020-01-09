using System.Collections.Generic;
using System.Linq;

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

            return CheckLimits(jobSheet) && BrakesCanBeChanged(jobSheet) && TotalHoursAreValid(jobSheet);
        }

        private bool BrakesCanBeChanged(JobSheet jobSheet)
        {
            if (RequiresBrakeDiscChange(jobSheet) || RequiresBrakePadChange(jobSheet))
            {
                return RequiresBrakeDiscChange(jobSheet) && RequiresBrakePadChange(jobSheet);
            }
            return true;
        }

        private bool RequiresBrakeDiscChange(JobSheet jobSheet)
        {
            return jobSheet.CountItems("brake disc") >= 1;
        }

        private bool RequiresBrakePadChange(JobSheet jobSheet)
        {
            return jobSheet.CountItems("brake pad") >= 1;
        }

        private bool CheckLimits(JobSheet jobSheet)
        {
            List<string> distinctItems = jobSheet.Items.Select(item => item.ID).Distinct().ToList();
            foreach (string itemID in distinctItems)
            {
                if (jobSheet.CountItems(itemID) > ReferenceData.GetLimit(itemID))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetLabourMinutes(JobSheet jobSheet)
        {
            int minutes = 0;
            foreach (JobItem item in jobSheet.Items)
            {
                minutes += ReferenceData.GetUnitMinutes(item.ID);
            }
            return minutes;
        }

        private bool TotalHoursAreValid(JobSheet jobSheet)
        {
            return jobSheet.TotalMinutes <= GetLabourMinutes(jobSheet);
        }
    }
}
