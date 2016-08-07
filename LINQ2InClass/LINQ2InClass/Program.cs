using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2InClass
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindDataContext nw = new NorthwindDataContext();

            //string[] digits = { "zero", "one", "two", "three",
            //    "four", "five", "six", "seven", "eight", "nine" };

            //var shortDidgits = digits.Where((digit, index) => digit.Length < index);

            //Console.WriteLine("Short Digits");
            //foreach(var d in shortDidgits)
            //{
            //    Console.WriteLine("The word {0} is shorter than it's value", d);
            //}

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three",
                "four", "five", "six", "seven", "eight", "nine" };

            //var textNums = from n in numbers
            //               select digits[n];

            //foreach (var t in textNums)
            //{
            //    Console.WriteLine(t);
            //}

            //string[] words = { "aPPlE", "BluBErrY" };

            //var upperLowerWords = from w in words
            //                      select new
            //                      {
            //                          Upper = w.ToUpper(),
            //                          Lower = w.ToLower()
            //                      };

            //foreach (var w in upperLowerWords)
            //{
            //    Console.WriteLine("Upper: {0}, Lower: {1}", w.Upper, w.Lower);
            //}

            //NorthwindDataContext nw = new NorthwindDataContext();

            //var products = from p in nw.Products
            //               select new
            //               {
            //                   p.ProductName,
            //                   p.CategoryID,
            //                   p.UnitPrice
            //               };

            //foreach (var w in products)
            //{
            //    Console.WriteLine("{0} is in the category {1} and costs {2}",
            //        w.ProductName, w.CategoryID, w.UnitPrice);
            //}

            //var orders = from c in nw.Customers
            //             from o in c.Orders
            //             where o.OrderDate >= new DateTime(1998, 1, 1)
            //             select new { c.CustomerID, o.OrderID, o.OrderDate };

            //foreach (var order in orders)
            //{
            //    Console.WriteLine("Order with an id of {0}, if for the customer with an id of {1} on {2}",
            //        order.OrderID, order.CustomerID, order.OrderDate);
            //}

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var first3 = numbers.Take(3);

            //foreach (var f in first3)
            //{
            //    Console.WriteLine(f);
            //}

            //var allButFirst4 = numbers.Skip(4);

            //foreach (var f in allButFirst4)
            //{
            //    Console.WriteLine(f);
            //}

            //var numbersWhileLessThan6 = numbers.TakeWhile(n => n < 6);

            //foreach (var f in numbersWhileLessThan6)
            //{
            //    Console.WriteLine(f);
            //}

            //var sorted = from d in digits
            //             orderby d.Length, d
            //             select d;

            //foreach (var f in sorted)
            //{
            //    Console.WriteLine(f);
            //}

            //int[] factorsOf300 = { 2, 2, 3, 3, 5, 5 };

            //var unique = factorsOf300.Distinct();

            //foreach (var f in unique)
            //{
            //    Console.WriteLine(f);
            //}

            int[] numsA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numsB = { 1, 3, 5, 7, 8 };

            //var common = numsA.Intersect(numsB);

            //foreach (var f in common)
            //{
            //    Console.WriteLine(f);
            //}

            //var common = numsA.Union(numsB);

            //foreach (var f in common)
            //{
            //    Console.WriteLine(f);
            //}

            //var aOnlyNums = numsA.Except(numsB);

            //foreach (var f in aOnlyNums)
            //{
            //    Console.WriteLine(f);
            //}

            //Product prod = (from p in nw.Products
            //                where p.ProductID == 12
            //                select p).FirstOrDefault();

            //Console.WriteLine(prod.ProductName);

            //string[] words = { "believe", "relief", "reciept", "field" };

            //bool iAfterE = words.Any(w => w.Contains("ie"));

            //Console.WriteLine(
            //    "The list contains a word or words that contain 'ie' is {0}",
            //    iAfterE);

            //double sum = numbers.Sum();

            //Console.WriteLine("The sum of all the numbers in the list is {0}",
            //    sum);

            //int min = numbers.Min();

            //Console.WriteLine("The minimum number is {0}", min);

            //int max = numbers.Max();

            //Console.WriteLine("The maximum number is {0}", max);

            //string[] categories = new string[]{
            //        "Beverages",
            //        "Condiments",
            //        "Vegetables",
            //        "Dairy Products",
            //        "Seafood" };

            //var q = from c in nw.Categories
            //        join p in nw.Products on c.CategoryID equals p.CategoryID into ps
            //        from x in ps.DefaultIfEmpty()
            //        select new
            //        {
            //            CategID = c.CategoryID, ProductName = ps. == null ? "(No Products)" : p.ProductName;
            //        }

            var cats = from c in nw.Categories
                       select c;

            foreach(var cat in cats)
            {
                Console.WriteLine("The category description is {0}", cat.Description);
            }

            Console.WriteLine("---------------------------------------------------------------");

            foreach(var cat in cats)
            {
                //cat.Description = cat.Description + "-new";
                cat.Description = cat.Description.Replace("-new", "");
            }

            var newCats = from c in nw.Categories
                       select c;

            nw.SubmitChanges();

            foreach (var cat in cats)
            {
                Console.WriteLine("The category description is {0}", cat.Description);
            }

            Console.ReadKey();
        }
    }
}
