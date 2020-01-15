using System.Collections.Generic;

namespace JobApproval
{
    public interface IReferenceData
    {
        int GetUnitCost(string itemID);
        int GetUnitMinutes(string itemID);
        KeyValuePair<int, int> GetLimit(string itemID);
    }
}
