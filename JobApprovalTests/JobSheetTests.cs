using NUnit.Framework;
using JobApproval;

namespace JobApprovalTests
{
    [TestFixture]
    public class JobSheetTests
    {
        JobSheet JobSheet; 

        [SetUp]
        public void Setup()
        {
            JobSheet = new JobSheet(0, 0);
        }

        [Test]
        public void JobSheetAddItems()
        {
            JobSheet.AddItem(new JobItem("tyre"));
            Assert.AreEqual(JobSheet.Items.Count, 1);
        }

        [Test]
        public void JobSheetCountsSpecificItems()
        {
            JobSheet.AddItem(new JobItem("tyre"));
            JobSheet.AddItem(new JobItem("tyre"));
            JobSheet.AddItem(new JobItem("tyre"));
            JobSheet.AddItem(new JobItem("exhaust"));
            Assert.AreEqual(JobSheet.CountSpecificItem("tyre"), 3);
        }

    }
}
