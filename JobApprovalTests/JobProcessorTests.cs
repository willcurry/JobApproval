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
            jobSheet.Tyres = 5;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void IfBrakePadsAndDiscAreNotBothBeingChanged()
        {
            JobSheet jobSheet = new JobSheet(0);
            jobSheet.BrakePad = 1;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
            jobSheet = new JobSheet(0);
            jobSheet.BrakeDisc = 1;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void IfExhaustIsGreaterThan1()
        {
            JobSheet jobSheet = new JobSheet(0);
            jobSheet.Exhaust = 2;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void IfLabourHoursExceedTheReferenceNumber()
        {
            JobSheet jobSheet = new JobSheet(2);
            jobSheet.Tyres = 2;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }
    }
}