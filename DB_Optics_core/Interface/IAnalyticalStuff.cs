using DB_Optics_core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Optics_core.Interface
{
    public interface IAnalyticalStuff
    {
        float AverSalary();

        Category[] SaleRating();

        Special_Offer_list[] AvalibleOffers(int startDate, int EndDate);
    }
}
