using DB_Optics_core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core.Data
{
    class Category : BaseDBobject
    {
        public string Name { get; set; }

        public Category(int iD, string name) : base(iD)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Категории: {ID}, {Name}";
        }
    }
}
