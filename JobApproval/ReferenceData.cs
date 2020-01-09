using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public class ReferenceData : IReferenceData
    {
        IDictionary<string, int> Prices;
        IDictionary<string, int> Time;

        public ReferenceData()
        {
            Prices = new Dictionary<string, int>();
            Time = new Dictionary<string, int>();
            PopulateData();
        }

        public int GetPrice(string itemID)
        {
            int price;
            if (Prices.TryGetValue(itemID, out price)) {
                return price;
            }
            throw new KeyNotFoundException();
        }

        public int GetTime(string itemID)
        {
            int minutes;
            if (Time.TryGetValue(itemID, out minutes)) {
                return minutes;
            }
            throw new KeyNotFoundException();
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
        }
    }
}
