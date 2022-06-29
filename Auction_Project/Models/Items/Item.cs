﻿using Auction_Project.Models.Base;

namespace Auction_Project.Models.Items
{
    public class Item : Entity
    {

        public bool IsSold { get; set; } = false;

        public bool Available { get; set; } = false;

        public string? Desc { get; set; }

        public decimal? Price { get; set; }

        public string? ImagesAddress { get; set; }

    }
}
