﻿//	Last modified by: Patrick Burroughs
//	Windows Prog 547
//	Last Updated : 10/30/23

namespace CSharpest.Classes
{
    public class WelcomePageModel
    {
        public List<Item> Items { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }

        public WelcomePageModel(List<Item> items, int Quantity, Guid cartId) {
            Items = items;
            CartId = cartId;
        }

    }
}
