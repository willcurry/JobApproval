using NUnit.Framework;
using JobApproval;

namespace JobApprovalTests
{
    public class JobProcessorTests
    {
        JobProcessor jobProcessor;

        [SetUp]
        public void Setup()
        {
            jobProcessor = new JobProcessor();
        }

        [Test]
        public void DeniesJobSheetIfTyresAreGreaterThan4()
        {
            JobSheet jobSheet = new JobSheet();
            jobSheet.Tyres = 5;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void DeniesJobSheetIfBrakePadsAndDiscAreNotBothBeingChanged()
        {
            JobSheet jobSheet = new JobSheet();
            jobSheet.BrakePad = 1;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
            jobSheet = new JobSheet();
            jobSheet.BrakeDisc = 1;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void DeniesJobSheetIfExhaustIsGreaterThan1()
        {
            JobSheet jobSheet = new JobSheet();
            jobSheet.Exhaust = 2;
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }
    }
}