using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core.Data
{
    public class Special_Offer_list : BaseDBobject
    {
        public float Discount { get; set; }

        public Special_Offer_list(int iD, float discount): base(iD)
        {
            Discount = discount;
        }
    }
}
