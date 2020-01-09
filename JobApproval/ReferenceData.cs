using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public class ReferenceData : IReferenceData
    {
        IList<Item> data;

        public ReferenceData()
        {
            data = new List<Item>();
            PopulateData();
        }

        public Item GetItem(string itemID)
        {
            foreach (Item item in data)
            {
                if (item.ID == itemID)
                    return item;
            }
            throw new KeyNotFoundException();
        }

        private void PopulateData()
        {
            Item tyre = new Item("tyre", 30, 200);
            Item brakeDisc = new Item("brake disc", 90, 100);
            Item brakePad = new Item("brake pad", 60, 50);
            Item oil = new Item("oil", 30, 20);
            Item exhaust = new Item("exhaust", 240, 175);
            data.Add(tyre);
            data.Add(brakeDisc);
            data.Add(brakePad);
            data.Add(oil);
            data.Add(exhaust);
        }
    }
}
