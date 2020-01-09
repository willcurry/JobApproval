using NUnit.Framework;
using JobApproval;

namespace JobApprovalTests
{
    [TestFixture, Category("Job Processor Denies")]
    public class JobProcessorDenies
    {
        JobProcessor JobProcessor;
        IReferenceData ReferenceData;

        [SetUp]
        public void Setup()
        {
            ReferenceData = new ReferenceData();
            JobProcessor = new JobProcessor(ReferenceData);
        }

        [Test]
        public void IfTyresAreGreaterThan4()
        {
            JobSheet jobSheet = new JobSheet(ReferenceData.GetUnitMinutes("tyre") * 5, ReferenceData.GetUnitCost("tyre") * 5);
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            Assert.AreEqual(JobProcessor.Process(jobSheet), Outcomes.Decline);
        }

        [Test]
        public void IfBrakePadsAndDiscAreNotBothBeingChanged()
        {
            JobSheet jobSheet = new JobSheet(ReferenceData.GetUnitMinutes("brake pad"), ReferenceData.GetUnitCost("brake pad"));
            jobSheet.AddItem(new JobItem("brake pad"));
            Assert.AreEqual(JobProcessor.Process(jobSheet), Outcomes.Decline);
            jobSheet = new JobSheet(ReferenceData.GetUnitMinutes("brake disc"), ReferenceData.GetUnitCost("brake disc"));
            jobSheet.AddItem(new JobItem("brake disc"));
            Assert.AreEqual(JobProcessor.Process(jobSheet), Outcomes.Decline);
        }

        [Test]
        public void IfExhaustIsGreaterThan1()
        {
            JobSheet jobSheet = new JobSheet(ReferenceData.GetUnitMinutes("exhaust") * 2, ReferenceData.GetUnitCost("exhaust") * 2);
            jobSheet.AddItem(new JobItem("exhaust"));
            jobSheet.AddItem(new JobItem("exhaust"));
            Assert.AreEqual(JobProcessor.Process(jobSheet), Outcomes.Decline);
        }

        [Test]
        public void IfLabourHoursExceedTheReferenceNumber()
        {
            JobSheet jobSheet = new JobSheet(ReferenceData.GetUnitMinutes("tyre") * 3, ReferenceData.GetUnitCost("tyre") * 2);
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            Assert.AreEqual(JobProcessor.Process(jobSheet), Outcomes.Decline);
        }

        [Test]
        public void IfTotalPriceExceeds15PercentOfTheReferencePrice()
        {
            JobSheet jobSheet = new JobSheet(ReferenceData.GetUnitMinutes("tyre") * 2, ReferenceData.GetUnitCost("tyre") * 3);
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            Assert.AreEqual(JobProcessor.Process(jobSheet), Outcomes.Decline);
        }
    }

    [TestFixture, Category("Job Processor Accepts")]
    public class JobProcessorAccepts
    {
        JobProcessor JobProcessor;
        IReferenceData ReferenceData;

        [SetUp]
        public void Setup()
        {
            ReferenceData = new ReferenceData();
            JobProcessor = new JobProcessor(ReferenceData);
        }

        [Test]
        public void IfTotalPriceIsWithin10PercentOfTheReferencePrice()
        {
            JobSheet jobSheet = new JobSheet(ReferenceData.GetUnitMinutes("tyre") * 2, ReferenceData.GetUnitCost("tyre") * 2);
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            Assert.AreEqual(JobProcessor.Process(jobSheet), Outcomes.Approve);
        }
    }
}