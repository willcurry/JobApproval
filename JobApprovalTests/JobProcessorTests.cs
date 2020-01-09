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
            JobSheet jobSheet = new JobSheet(5, false, false, 0);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void DeniesJobSheetIfBrakePadsAndDiscAreNotBothBeingChanged()
        {
            JobSheet jobSheet = new JobSheet(0, true, false, 0);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
            jobSheet = new JobSheet(0, false, true, 0);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void DeniesJobSheetIfExhaustIsGreaterThan1()
        {
            JobSheet jobSheet = new JobSheet(0, false, false, 2);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }
    }
}