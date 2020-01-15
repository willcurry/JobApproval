using Newtonsoft.Json;
using System.Collections.Generic;
using JobApproval;

namespace JobApprovalWeb
{
    public class JobSheetModel
    {
        public int TotalPrice { get; set; }
        public int TotalMinutes { get; set; }
        public string RequestedItems { get; set; }
        private ReferenceData _referenceData;

        public JobSheetModel()
        {
            _referenceData = new ReferenceData();
        }

        public List<string> GetRequestedItems()
        {
            List<string> items = new List<string>();
            foreach (KeyValuePair<string, int> item in RequestedItemsJsonToDictionary())
            {
                for (int i=0; i < item.Value; i++)
                    if (_referenceData.ItemExists(item.Key))
                        items.Add(item.Key);
            }
            return items;
        }

        private Dictionary<string, int> RequestedItemsJsonToDictionary()
        {
            var items = JsonConvert.DeserializeObject<Dictionary<string, int>>(RequestedItems);
            return items == null ? new Dictionary<string, int>() : items;
        }
    }
}
