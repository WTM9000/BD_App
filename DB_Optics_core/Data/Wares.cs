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

        public float Discount { get; set; }

        public Wares(int iD, string name, int cost, string category, float discount): base(iD)
        {
            Name = name;
            Cost = cost;
            Category = category;
            Discount = discount;
        }

        public override string ToString()
        {
            return $"Товары: {ID}, {Name}, {Cost}, {Category}, {Discount}";
        }
    }
}
