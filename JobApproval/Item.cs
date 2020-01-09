using System;
using System.Collections.Generic;
using System.Text;

namespace JobApproval
{
    public class Item
    {
        public int Time { get; }
        public int Price { get; }
        public string ID { get; }

        public Item(string id, int time, int price)
        {
            ID = id;
            Time = time;
            Price = price;
        }
    }
}
