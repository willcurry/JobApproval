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
            jobSheetModel.TotalMinutes = 1;
            jobSheetModel.TotalPrice = 2;
            jobSheetModel.RequestedItems = "{\"tyre\":\"2\",\"brake_disc\":\"1\"}";

            List<string> expected = new List<string>();
            expected.Add("tyre");
            expected.Add("tyre");
            expected.Add("brake_disc");

            Assert.AreEqual(expected, jobSheetModel.GetRequestedItems());
        }
    }
}
