using System.Collections.Generic;
using System.Linq;

namespace JobApproval
{
    public enum Outcomes
    {
        Approve,
        Refer,
        Decline
    }

    public class JobProcessor
    {
        private IReferenceData ReferenceData;

        public JobProcessor(IReferenceData referenceData)
        {
            ReferenceData = referenceData;
        }

        public Outcomes Process(JobSheet jobSheet)
        {
            if (CheckLimits(jobSheet) && BrakesCanBeChanged(jobSheet) && TotalHoursAreValid(jobSheet))
            {
                if (TotalPriceIsValid(jobSheet))
                {
                    return Outcomes.Approve;
                }
            }
            return Outcomes.Decline;
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

        private int GetCorrectLabourTime(JobSheet jobSheet)
        {
            int minutes = 0;
            foreach (JobItem item in jobSheet.Items)
            {
                minutes += ReferenceData.GetUnitMinutes(item.ID);
            }
            return minutes;
        }

        private int GetCorrectLabourPrice(JobSheet jobSheet)
        {
            int total = 0;
            foreach (JobItem item in jobSheet.Items)
            {
                total += ReferenceData.GetUnitCost(item.ID);
            }
            return total;
        }

        private bool TotalHoursAreValid(JobSheet jobSheet)
        {
            return jobSheet.TotalMinutes <= GetCorrectLabourTime(jobSheet);
        }

        private bool TotalPriceIsValid(JobSheet jobSheet)
        {
            int correctPrice = GetCorrectLabourPrice(jobSheet);
            double max = correctPrice + (correctPrice * 0.15);
            double min = correctPrice - (correctPrice * 0.1);
            return jobSheet.TotalPrice < max && jobSheet.TotalPrice > min;
        }
    }
}
