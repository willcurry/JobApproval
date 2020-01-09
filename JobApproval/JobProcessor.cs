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

            return jobSheet.CountItems("tyre") < 5 && !(jobSheet.CountItems("exhaust") > 1);
        }

        public int GetLabourHours(JobSheet jobSheet)
        {
            int minutes = 0;
            foreach (JobItem item in jobSheet.Items)
            {
                minutes += ReferenceData.GetUnitMinutes(item.ID);
            }
            return minutes / 60;
        }

        private bool CheckLabourTime(JobSheet jobSheet)
        {
            return jobSheet.TotalHours <= GetLabourHours(jobSheet);
        }
    }
}
