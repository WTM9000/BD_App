using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core
{
    public abstract class BaseDBobject
    {
        public int ID { get; set; }

        protected BaseDBobject(int iD)
        {
            ID = iD;
        }
    }
}
