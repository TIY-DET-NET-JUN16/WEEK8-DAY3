using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample1();
            //Sample2();
            //Sample3();
            //Sample4();
            //Sample5();
            //Sample6();
            //Sample7();
            //Sample8();
            //Sample9();
            //Sample10();
            //Sample11();
            //Sample12();
            //Sample13();
            //Sample14();
            //Sample15();
            //Sample16();
            //Sample17();
            //Sample18();
            //Sample19();
            Sample20();

            Console.ReadKey();
        }

        /// <summary>
        /// Runs a simple linq query uses lambda expression
        /// </summary>
        static void Sample1()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, index) => digit.Length < index);

            Console.WriteLine("Short digits:");
            foreach (var d in shortDigits)
            {
                Console.WriteLine("The word {0} is shorter than its value.", d);
            }
        }

        /// <summary>
        /// Use LINQ to select from a different array
        /// </summary>
        static void Sample2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums =
                from n in numbers
                select strings[n];

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Using anonymous types
        /// </summary>
        static void Sample3()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //The anonymous type is created with the new
            var upperLowerWords =
                from w in words
                select new { Upper = w.ToUpper(), Lower = w.ToLower() };

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }
        }

        /// <summary>
        /// Anonymous types again
        /// </summary>
        static void Sample4()
        {
            NorthwindDataContext nw = new NorthwindDataContext();

            var productInfos =
                from p in nw.Products
                select new { p.ProductName, p.CategoryID, Price = p.UnitPrice };

            Console.WriteLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                Console.WriteLine("{0} is in the category {1} and costs {2} per unit.",
                    productInfo.ProductName, productInfo.CategoryID, productInfo.Price);
            }
        }

        /// <summary>
        /// Querying the results list
        /// </summary>
        static void Sample5()
        {
            NorthwindDataContext nw = new NorthwindDataContext();

            var orders =
                from c in nw.Customers
                from o in c.Orders
                where o.OrderDate >= new DateTime(1998, 1, 1)
                select new { c.CustomerID, o.OrderID, o.OrderDate };

            foreach (var order in orders)
            {
                Console.WriteLine("{0} is in the Customer ID, {1} is the order ID and {2:d} is the order date.",
                    order.CustomerID, order.OrderID, order.OrderDate);
            }
        }

        /// <summary>
        /// Using Take, take the first 3 entries
        /// </summary>
        static void Sample6()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");

            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Using skip, skip the first 4 numbers
        /// </summary>
        static void Sample7()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");

            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Using TakeWhile, return elements starting from
        /// the beginning of the array until a number is hit
        /// that is not less than 6
        /// </summary>
        static void Sample8()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:");

            foreach (var n in firstNumbersLessThan6)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Uses a compound orderby to sort a list of digits, 
        /// first by length of their name, and then alphabetically 
        /// by the name itself
        /// </summary>
        static void Sample9()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits =
                from d in digits
                orderby d.Length, d
                select d;

            Console.WriteLine("Sorted digits:");
            foreach (var d in sortedDigits)
            {
                Console.WriteLine(d);
            }
        }

        /// <summary>
        /// Uses Distinct to remove duplicate elements in a sequence
        /// </summary>
        static void Sample10()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            var uniqueFactors = factorsOf300.Distinct();

            Console.WriteLine("Prime factors of 300:");
            foreach (var f in uniqueFactors)
            {
                Console.WriteLine(f);
            }
        }

        /// <summary>
        /// Uses Union to create one sequence that contains the unique values from both arrays
        /// </summary>
        static void Sample11()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            foreach (var n in uniqueNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Uses Intersect to create one sequence that contains the common values shared by both arrays
        /// </summary>
        static void Sample12()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("Common numbers shared by both arrays:");
            foreach (var n in commonNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Uses Except to return everything in the first sequence that does
        /// not exist in the second sequence
        /// </summary>
        static void Sample13()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);

            Console.WriteLine("Numbers in first array but not second array:");
            foreach (var n in aOnlyNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Uses First to return the first matching element as a Product
        /// </summary>
        static void Sample14()
        {
            NorthwindDataContext nw = new LINQ2.NorthwindDataContext();

            Product product12 = (
                from p in nw.Products
                where p.ProductID == 12
                select p)
                .First();

            Console.WriteLine(product12.ProductName);
        }

        /// <summary>
        /// Uses Any to determine if any of the words in the array contain the substring 'ei'
        /// </summary>
        static void Sample15()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

            bool iAfterE = words.Any(w => w.Contains("ei"));

            Console.WriteLine("There is a word that contains in the list that contains 'ei': {0}", iAfterE);
        }

        /// <summary>
        /// Uses Sum to calculate the sum of all the elements
        /// </summary>
        static void Sample16()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double numSum = numbers.Sum();

            Console.WriteLine("The sum of the numbers is {0}.", numSum);
        }

        /// <summary>
        /// Uses Min to get the lowest number in an array
        /// </summary>
        static void Sample17()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int minNum = numbers.Min();

            Console.WriteLine("The minimum number is {0}.", minNum);
        }

        /// <summary>
        /// Uses Max to get the highest number in an array
        /// </summary>
        static void Sample18()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int maxNum = numbers.Max();

            Console.WriteLine("The maximum number is {0}.", maxNum);
        }

        /// <summary>
        /// Simulates a left outer join
        /// </summary>
        static void Sample19()
        {
            string[] categories = new string[]{
                    "Beverages",
                    "Condiments",
                    "Vegetables",
                    "Dairy Products",
                    "Seafood" };

            NorthwindDataContext nw = new NorthwindDataContext();

            var q =
                from c in nw.Categories
                join p in nw.Products on c equals p.Category into ps
                from p in ps.DefaultIfEmpty()
                select new { Category = c, ProductName = p == null ? "(No products)" : p.ProductName };

            foreach (var v in q)
            {
                Console.WriteLine(v.ProductName + ": " + v.Category.Description);
            }
        }

        /// <summary>
        /// Updating the database
        /// </summary>
        static void Sample20()
        {
            NorthwindDataContext nw = new LINQ2.NorthwindDataContext();

            var cats = from c in nw.Categories
                      select c;

            foreach(var cat in cats)
            {
                Console.WriteLine("Category Description : {0}", cat.Description);
            }

            Console.WriteLine("------------------------------------------------------");

            foreach (var cat in cats)
            {
                cat.Description = cat.Description + "-new";
                //cat.Description = cat.Description.Replace("-new", "");
            }

            var newCats = from c in nw.Categories
                       select c;

            nw.SubmitChanges();

            foreach (var cat in newCats)
            {
                Console.WriteLine("Category Description : {0}", cat.Description);
            }
        }
    }
}
