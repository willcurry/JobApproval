using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public interface IReferenceData
    {
        int GetUnitCost(string itemID);
        int GetUnitMinutes(string itemID);
    }
}
