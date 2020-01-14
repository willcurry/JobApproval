using System;
using System.Collections.Generic;

namespace JobApproval
{
    public class ReferenceData : IReferenceData
    {
        IDictionary<string, int> Prices;
        IDictionary<string, int> Time;
        IDictionary<string, KeyValuePair<int, int>> Limits;

        public ReferenceData()
        {
            Prices = new Dictionary<string, int>();
            Time = new Dictionary<string, int>();
            Limits = new Dictionary<string, KeyValuePair<int, int>>();
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

        public KeyValuePair<int, int> GetLimit(string itemID)
        {
            KeyValuePair<int, int> limit;
            if (Limits.TryGetValue(itemID, out limit)) {
                return limit;
            }
            return new KeyValuePair<int, int>(0, Int32.MaxValue);
        }

        public bool ItemExists(string itemID)
        {
            return Time.ContainsKey(itemID) && Prices.ContainsKey(itemID);
        }

        private void PopulateData()
        {
            Time.Add("tyre", 30);
            Prices.Add("tyre", 200);
            Time.Add("brake_disc", 90);
            Prices.Add("brake_disc", 100);
            Time.Add("brake_pad", 60);
            Prices.Add("brake_pad", 50);
            Time.Add("oil", 30);
            Prices.Add("oil", 20);
            Time.Add("exhaust", 240);
            Prices.Add("exhaust", 175);

            Limits.Add("tyre", new KeyValuePair<int, int>(2, 4));
            Limits.Add("exhaust", new KeyValuePair<int, int>(1, 1));
        }
    }
}
