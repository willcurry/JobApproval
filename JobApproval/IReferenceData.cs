using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public interface IReferenceData
    {
        int GetPrice(string itemID);
        int GetTime(string itemID);
    }
}
