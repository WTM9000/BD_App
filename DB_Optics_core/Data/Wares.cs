using DB_Optics_core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core.Data
{
    class Wares : BaseDBobject
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Category category { get; set; }

        public float Discount { get; set; }

        public Wares(int iD, string name, int cost, Category category, float discount): base(iD)
        {
            Name = name;
            Cost = cost;
            this.category = category;
            Discount = discount;
        }

        public override string ToString()
        {
            return $"Товары: {ID}, {Name}, {Cost}, {category.Name}, {Discount}";
        }
    }
}
