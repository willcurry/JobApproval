using Newtonsoft.Json;
using System.Collections.Generic;

namespace JobApprovalWeb
{
    public class JobSheetModel
    {
        public int TotalPrice { get; set; }
        public int TotalHours { get; set; }
        public string RequestedItems { get; set; }

        public List<string> GetRequestedItems()
        {
            List<string> items = new List<string>();
            foreach (KeyValuePair<string, int> item in RequestedItemsJsonToDictionary())
            {
                for (int i=0; i < item.Value; i++)
                {
                    items.Add(item.Key);
                }
            }
            return items;
        }

        private Dictionary<string, int> RequestedItemsJsonToDictionary()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(RequestedItems);
        }
    }
}
