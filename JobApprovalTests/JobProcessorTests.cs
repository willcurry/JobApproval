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
            JobSheet jobSheet = new JobSheet(5);
            Assert.IsFalse(jobProcessor.Process(jobSheet));
        }
    }
}