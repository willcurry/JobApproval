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
            JobSheet jobSheet = new JobSheet(5, false, false);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }

        [Test]
        public void DeniesJobSheetIfBrakePadsAndDiscAreNotBothBeingChanged()
        {
            JobSheet jobSheet = new JobSheet(5, true, false);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
            jobSheet = new JobSheet(5, false, true);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }
    }
}