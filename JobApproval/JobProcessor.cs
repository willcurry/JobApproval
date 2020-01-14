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
                return DetermineOutCome(jobSheet);
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
                int min = ReferenceData.GetLimit(itemID).Key;
                int max = ReferenceData.GetLimit(itemID).Value;
                if (jobSheet.CountItems(itemID) > max || jobSheet.CountItems(itemID) < min)
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

        private Outcomes DetermineOutCome(JobSheet jobSheet)
        {
            int correctPrice = GetCorrectLabourPrice(jobSheet);
            bool greaterThan15 = jobSheet.TotalPrice > correctPrice + (correctPrice * 0.15);
            bool greaterThan10 = jobSheet.TotalPrice > correctPrice + (correctPrice * 0.10);
            bool lessThan10 = jobSheet.TotalPrice < correctPrice - (correctPrice * 0.10);

            if (greaterThan15)
            {
                return Outcomes.Decline;
            } 
            else if (!greaterThan10 && !lessThan10)
            {
                return Outcomes.Approve;
            }
            return Outcomes.Refer;
        }
    }
}
