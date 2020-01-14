using NUnit.Framework;
using JobApprovalWeb;
using System.Collections.Generic;

namespace JobApprovalWebTests
{
    public class JobSheetModelTests 
    {

        [Test]
        public void ItConvertsJSonAndReturnsItemsAsList()
        {
            JobSheetModel jobSheetModel = new JobSheetModel();
            jobSheetModel.TotalHours = 1;
            jobSheetModel.TotalPrice = 2;
            jobSheetModel.RequestedItems = "{\"tyre\":\"2\",\"brake_discs\":\"1\"}";

            List<string> expected = new List<string>();
            expected.Add("tyre");
            expected.Add("tyre");
            expected.Add("brake_discs");

            Assert.AreEqual(expected, jobSheetModel.GetRequestedItems());
        }
    }
}
