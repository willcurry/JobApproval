using System;
using System.Collections.Generic;

namespace JobApproval
{
    public class ReferenceData : IReferenceData
    {
        IDictionary<string, int> Prices;
        IDictionary<string, int> Time;
        IDictionary<string, int> Limits;

        public ReferenceData()
        {
            Prices = new Dictionary<string, int>();
            Time = new Dictionary<string, int>();
            Limits = new Dictionary<string, int>();
            PopulateData();
        }

        public int GetUnitCost(string itemID)
        {
            int price;
            if (Prices.TryGetValue(itemID, out price)) {
                return price;
            }
            throw new KeyNotFoundException();
        }

        public int GetUnitMinutes(string itemID)
        {
            int minutes;
            if (Time.TryGetValue(itemID, out minutes)) {
                return minutes;
            }
            throw new KeyNotFoundException();
        }

        public int GetLimit(string itemID)
        {
            int limit;
            if (Limits.TryGetValue(itemID, out limit)) {
                return limit;
            }
            return Int32.MaxValue;
        }

        private void PopulateData()
        {
            Time.Add("tyre", 30);
            Prices.Add("tyre", 200);
            Time.Add("brake disc", 90);
            Prices.Add("brake disc", 100);
            Time.Add("brake pad", 60);
            Prices.Add("brake pad", 50);
            Time.Add("oil", 30);
            Prices.Add("oil", 20);
            Time.Add("exhaust", 240);
            Prices.Add("exhaust", 175);

            Limits.Add("tyre", 4);
            Limits.Add("exhaust", 1);
        }
    }
}
