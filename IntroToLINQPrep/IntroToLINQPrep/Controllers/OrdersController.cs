using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IntroToLINQPrep.Models;

namespace IntroToLINQPrep.Controllers
{
    public class OrdersController : Controller
    {
        NorthwindDataContext nw = new NorthwindDataContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = from o in nw.Orders
                         where o.EmployeeID == 5
                         select o;

            return View(orders as IEnumerable<Order>);
        }

        public ActionResult CustomersWithoutOrders()
        {
            var noOrders = ViewModel.CustNoOrder;

            return View(noOrders);
        }
    }
}