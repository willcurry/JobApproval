using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace JobApprovalWeb
{
    public class JobSheetModel
    {
        public int TotalPrice { get; set; }
        public int TotalHours { get; set; }
        public string RequestedItems { get; set; }

        public Dictionary<string, object> GetRequestedItems()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(RequestedItems);
        }
    }
}
