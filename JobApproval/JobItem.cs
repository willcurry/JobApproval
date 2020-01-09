using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public class JobItem
    {
        public string ID { get; }

        public JobItem(string id)
        {
            ID = id;
        }
    }
}
