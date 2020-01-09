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
        public void Denies()
        {
            Assert.IsFalse(jobProcessor.Process());
        }
    }
}