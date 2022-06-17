using DB_Optics_core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core.Data
{
    public class Wares : BaseDBobject
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public string Category { get; set; }

        public int CategoryID { get; set; }

        public float Discount { get; set; }

        public int DiscountID { get; set; }

        public Wares(int iD, string name, int cost, string category, float discount): base(iD)
        {
            ID = iD;
            Name = name;
            Cost = cost;
            Category = category;
            Discount = discount;
        }

        public Wares(int iD, string name, int cost, int categoryId, int discountId) : base(iD)
        {
            Name = name;
            Cost = cost;
            CategoryID = categoryId;
            DiscountID = discountId;
        }

        public override string ToString()
        {
            return $"Товары: {ID}. {Name}, {Cost}, {Category}, {Discount}";
        }
    }
}
