using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroToLINQPrep.Models
{
    public static class ViewModel
    {
        public static IEnumerable<string> CustNoOrder
        {
            get
            {
                NorthwindDataContext nw = new NorthwindDataContext();

                var noOrder = (from c in nw.Customers
                               select c.CustomerID).Except(from o in nw.Orders
                                                           select o.CustomerID);
                return noOrder;
            }
        }
    }
}