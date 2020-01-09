using NUnit.Framework;
using JobApproval;

namespace JobApprovalTests
{
    [TestFixture, Category("Denies")]
    public class JobProcessorDenies
    {
        JobProcessor jobProcessor;
        IReferenceData referenceData;

        [SetUp]
        public void Setup()
        {
            referenceData = new ReferenceData();
            jobProcessor = new JobProcessor(referenceData);
        }

        [Test]
        public void IfTyresAreGreaterThan4()
        {
            JobSheet jobSheet = new JobSheet(0);
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void IfBrakePadsAndDiscAreNotBothBeingChanged()
        {
            JobSheet jobSheet = new JobSheet(0);
            jobSheet.AddItem(new JobItem("brake pad"));
            Assert.IsFalse(jobProcessor.Process(jobSheet));
            jobSheet = new JobSheet(0);
            jobSheet.AddItem(new JobItem("brake disc"));
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void IfExhaustIsGreaterThan1()
        {
            JobSheet jobSheet = new JobSheet(0);
            jobSheet.AddItem(new JobItem("exhaust"));
            jobSheet.AddItem(new JobItem("exhaust"));
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void IfLabourHoursExceedTheReferenceNumber()
        {
            JobSheet jobSheet = new JobSheet(2);
            jobSheet.AddItem(new JobItem("tyre"));
            jobSheet.AddItem(new JobItem("tyre"));
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }
    }
}