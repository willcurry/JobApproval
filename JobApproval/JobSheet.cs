using System.Collections.Generic;
using System.Linq;

namespace JobApproval
{
    public class JobSheet
    {
        public int TotalMinutes;
        public int TotalPrice;
        public IList<JobItem> Items;

        public JobSheet(int totalMinutes, int totalPrice)
        {
            TotalMinutes = totalMinutes;
            TotalPrice = totalPrice;
            Items = new List<JobItem>();
        }

        public void AddItem(JobItem item)
        {
            Items.Add(item);
        }

        public int CountSpecificItem(string itemID)
        {
            return FindItems(itemID).Count();
        }

        private IEnumerable<JobItem> FindItems(string itemID)
        {
           return Items.Where(item => item.ID == itemID);
        }
    }
}
