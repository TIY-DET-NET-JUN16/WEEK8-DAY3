using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroToLINQPrep.Models
{
    public partial class Order
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Order Date")]
        public DateTime FormattedOrderDate
        {
            get
            {
                return Convert.ToDateTime(this.OrderDate);
            }
            set
            {
                this.OrderDate = value;
            }
        }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Ship Date")]
        public DateTime FormattedShipDate
        {
            get
            {
                return Convert.ToDateTime(this.ShippedDate);
            }
            set
            {
                this.ShippedDate = value;
            }
        }

        [Display(Name = "Order Number")]
        public int FormattedOrderID
        {
            get
            {
                return this.OrderID;
            }
            set
            {
                this.OrderID = value;
            }
        }
    }
}