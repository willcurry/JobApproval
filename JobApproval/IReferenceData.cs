using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public interface IReferenceData
    {
        Item GetItem(string itemID);
    }
}
