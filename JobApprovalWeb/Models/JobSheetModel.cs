using Newtonsoft.Json;
using System.Collections.Generic;
using JobApproval;
using System.ComponentModel.DataAnnotations;

namespace JobApprovalWeb
{
    public class JobSheetModel
    {
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public int TotalMinutes { get; set; }
        [Required]
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
