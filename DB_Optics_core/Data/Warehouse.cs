using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core
{
    class Warehouse : BaseDBobject
    {
        public string Address { get; set; }

        public int Space { get; set; }

        public Warehouse(int iD, string address, int space) : base(iD)
        {
            Address = address;
            Space = space;
        }

        public override string ToString()
        {
            return $"Склады: {ID}, {Address}, {Space}";
        }
    }
}
