using System.Collections.Generic;
using System.Linq;

namespace JobApproval
{
    public class JobSheet
    {
        public int TotalHours;
        public IList<JobItem> Items;

        public JobSheet(int totalHours)
        {
            TotalHours = totalHours;
            Items = new List<JobItem>();
        }

        public void AddItem(JobItem item)
        {
            Items.Add(item);
        }

        public bool RequiresBrakeDiscChange()
        {
            return CountItems("brake disc") >= 1;
        }

        public bool RequiresBrakePadChange()
        {
            return CountItems("brake pad") >= 1;
        }

        public int CountItems(string itemID)
        {
            return FindItems(itemID).Count();
        }

        private IEnumerable<JobItem> FindItems(string itemID)
        {
           return Items.Where(item => item.ID == itemID);
        }
    }
}
