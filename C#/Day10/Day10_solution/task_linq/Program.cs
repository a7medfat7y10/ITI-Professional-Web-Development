using System.Collections;
using System.Linq;

namespace task_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> Words = new List<String>();

            using (StreamReader file = new StreamReader("dictionary_english.txt"))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Words.Add(ln);
                    counter++;
                }
                file.Close();
            }


            #region Restriction Operators
            ////1
            //var list = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0).Select(p => p.ProductName);

            //foreach (var product in list)
            //    Console.WriteLine(product);

            ////2
            //list = ListGenerators.ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).Select(p => p.ProductName);

            //foreach (var product in list)
            //    Console.WriteLine(product);

            ////3
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var list_2 = Arr.Where((value, index) => value.Length < index);

            //foreach (var element in list_2)
            //    Console.WriteLine(element);

            #endregion

            #region Element Operators
            ////1
            //var firstItem = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            //Console.WriteLine(firstItem?.ProductName);

            ////2
            //firstItem = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(firstItem?.ProductName);

            ////3
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var SecondNumber = Arr.Where(num => num > 5).OrderBy(e=>e).ElementAt(1);
            //Console.WriteLine(SecondNumber);

            #endregion

            #region Set Operators

            ////1
            //var list_3 = ListGenerators.ProductList.Select(p => p.ProductName).Distinct();
            //foreach (var product in list_3)
            //    Console.WriteLine(product);


            ////2
            //var list_4 = ListGenerators.ProductList.Select(p => p.ProductName).Select(propName => propName.ElementAt(0)).Distinct();
            //var list_5 = ListGenerators.CustomerList.Select(c => c.CustomerID).Select(CustName => CustName.ElementAt(0)).Distinct();
            //list_4 = list_4.Concat(list_5);

            //foreach (var item in list_4)
            //    Console.WriteLine(item);

            ////3
            //var list_6 = ListGenerators.ProductList.Select(prod => prod.ProductName.ElementAt(0));
            //var list_7 = ListGenerators.CustomerList.Select(cust => cust.CustomerID.ElementAt(0));

            //list_6 = list_6.Intersect(list_7);

            //foreach (var prod in list_6)
            //    Console.WriteLine(prod);


            ////4
            //var list_8 = ListGenerators.ProductList.Select(p => p.ProductName).Select(propName => propName.ElementAt(0));
            //var list_9 = ListGenerators.CustomerList.Select(c => c.CustomerID).Select(CustName => CustName.ElementAt(0));
            //list_8 = list_8.Except(list_9);

            //foreach (var item in list_8)
            //    Console.WriteLine(item);


            ////
            //var list_10 = ListGenerators.ProductList.Select(p => p.ProductName).Select(name => name.Substring(name.Length - 3));
            //var list_11 = ListGenerators.CustomerList.Select(c => c.CustomerID).Select(name => name.Substring(name.Length - 3));
            //list_10 = list_10.Concat(list_11);

            //foreach (var item in list_10)
            //    Console.WriteLine(item);

            #endregion

            #region Aggregate Operators

            ////1
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var count = Arr.Where(ele => ele % 2 == 1).Count();
            //Console.WriteLine(count);


            ////2
            //var list_12 = ListGenerators.CustomerList.Select(c => new { Customer_Name = c.CustomerID, No_Of_Orders = c.Orders.Length });
            //foreach (var ele in list_12)
            //    Console.WriteLine(ele);



            ////3
            //var list_13 = ListGenerators.ProductList.Select(p => new { Category = p.ProductID, No_Of_Products = p.Category.Count() });
            //foreach (var ele in list_13)
            //    Console.WriteLine(ele);


            ////4
            //int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var Total = Arr2.Sum();
            //Console.WriteLine(Total);


            ////5
            //var list_14 = Words.Select(word => new { Word = word, no_of_chars = word.Length });

            //foreach (var word in list_14)
            //{
            //    Console.WriteLine(word);
            //}


            ////6

            //var list_15 = ListGenerators.ProductList.GroupBy(prod => prod.Category)
            //.Select(prod => new { Category = prod.Key, TotalUnitsInStock = prod.Sum(ele => ele.UnitsInStock) });

            //foreach (var prod in list_13)
            //    Console.WriteLine(prod);


            ////7
            //var Shortest_Length = Words.Min(word => word.Length);
            //Console.WriteLine(Shortest_Length);


            ////8
            //var cheapest_price = ListGenerators.ProductList.GroupBy(p=> p.Category).Select(c => new { Category = c.Key, MinPrice = c.Min(ele => ele.UnitPrice) });
            //foreach (var prod in cheapest_price)
            //    Console.WriteLine(prod);


            ////9
            //var list_16 = from prod in ListGenerators.ProductList
            //              group prod by prod.Category
            //              into prodGroup
            //              let MinPriceInCategory = prodGroup.Min(prod => prod.UnitPrice)
            //              orderby MinPriceInCategory
            //              select new { Category = prodGroup.Key, MinPrice = MinPriceInCategory };

            //foreach (var prod in list_16)
            //    Console.WriteLine(prod);


            ////10
            //var LogngestWord = Words.Max(word => word.Length);
            //Console.WriteLine(LogngestWord);


            ////11
            //var list_17 = ListGenerators.ProductList.GroupBy(prod => prod.Category).Select(cat => new { Category = cat.Key, MostExpensiveProd = cat.Max(prod => prod.UnitPrice) });
            //foreach (var prod in list_17)
            //    Console.WriteLine(prod);


            ////12
            //var most_expensive = ListGenerators.ProductList.GroupBy(p => p.Category).Select(c => new { Category = c.Key, MinPrice = c.Max(ele => ele.UnitPrice) });
            //foreach (var prod in most_expensive)
            //    Console.WriteLine(prod);


            ////13
            //var Average_Length = Words.Average(word => word.Length);
            //Console.WriteLine(Average_Length);


            ////14
            //var list_18 = ListGenerators.ProductList.GroupBy(prod => prod.Category).Select(cat => new { Category = cat.Key, AveragePrice = cat.Average(cat => cat.UnitPrice) });
            //foreach (var prod in list_18)
            //    Console.WriteLine(prod);

            #endregion

            #region Ordering Operators

            ////1
            //var list_19 = ListGenerators.ProductList.Select(prod => prod.ProductName).OrderBy(name => name);
            //foreach (var prod in list_19)
            //    Console.WriteLine(prod);


            ////2
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var list_20 = Arr.OrderBy(x => x).ToList();
            //foreach (var item in list_20)
            //    Console.WriteLine(item);


            ////3
            //var list_21 = ListGenerators.ProductList.Select(prod => new { Product = prod.ProductName, UnitsInStock = prod.UnitsInStock }).OrderByDescending(prod => prod.UnitsInStock);
            //foreach (var item in list_21)
            //    Console.WriteLine(item);


            ////4
            //string[] Arr2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var list_22 = Arr2.Select(word => word).OrderBy(word => word).OrderBy(word => word.Length).ToList();
            //foreach (var ele in list_22)
            //    Console.WriteLine(ele);


            ////5
            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var list_24 = words.OrderBy(word => word.Length).OrderBy(word => word);
            //foreach (var ele in list_24)
            //    Console.WriteLine(ele);


            ////6
            //var list_26 = ListGenerators.ProductList.OrderByDescending(prod => prod.Category).OrderByDescending(prod => prod.UnitPrice);
            //foreach (var ele in list_26)
            //    Console.WriteLine(ele);



            ////7
            //string[] Arr3 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var list_28 = Arr3.OrderByDescending(x => x.Length).OrderByDescending(x => x);

            //foreach (var ele in list_28)
            //    Console.WriteLine(ele);


            ////8
            //string[] Arr4 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var list_30 = Arr4.Select((ele, index) => new { word = ele, x = index }).Where(ele => ele.word[1] == 'i').Select(ele => ele.x);

            //foreach (var ele in list_30)
            //    Console.WriteLine(ele);


            #endregion

            #region Partitioning Operators

            ////1
            //var list_31 = ListGenerators.CustomerList.Where(c => c.Address.Contains("Washington")).Take(3);
            //foreach (var item in list_31)
            //    Console.WriteLine(item);


            ////2
            //var list_32 = ListGenerators.CustomerList.Where(ele => ele.Address.Contains("Washington")).Skip(2);
            //foreach (var order in list_32)
            //        Console.WriteLine(order);


            ////3
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var list_33 = numbers.Select((ele, index) => new { val = ele, index = index }).TakeWhile(ele => ele.val > ele.index).Select(ele => ele.val);

            //foreach (var item in list_33)
            //    Console.WriteLine(item);


            ////4
            //int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var list_34 = numbers2.SkipWhile(ele => ele % 3 != 0);
            //foreach (int ele in list_34)
            //    Console.WriteLine(ele);


            ////5
            //int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var list_35 = numbers3.Select((ele, index) => new { val = ele, index = index }).SkipWhile(ele => ele.val >= ele.index).Select(ele => ele.val);
            //foreach (int ele in list_35)
            //    Console.WriteLine(ele);

            #endregion

            #region Projection Operators


            ////1
            //var list_36 = ListGenerators.ProductList.Select(prod => prod.ProductName);
            //foreach (var prod in list_36)
            //    Console.WriteLine(prod);


            ////2
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //var list_37 = words.Select(word => word.ToUpper()).Concat(words.Select(word => word.ToLower()));
            //foreach (var prod in list_37)
            //    Console.WriteLine(prod);


            ////3

            //var list_38 = ListGenerators.ProductList.Select(prod => new { ProductNme = prod.ProductName, UnitInStock = prod.UnitsInStock, Price = prod.UnitPrice });

            //foreach (var prod in list_38)
            //    Console.WriteLine(prod);


            ////4
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var list_39 = Arr.Select( (ele, index) => ele + ": " + (ele == index) );

            //foreach (var prod in list_39)
            //    Console.WriteLine(prod);


            ////5
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var list_40 = numbersA.SelectMany(a => numbersB, (a, b) => new { a, b }).
            //    Where(arg => arg.a < arg.b)
            //    .Select(arg => arg.a + " is less than " + arg.b);
            //foreach (var prod in list_40)
            //    Console.WriteLine(prod);


            ////6
            //var list_42 = ListGenerators.CustomerList.Select(ele => ele.Orders.Where(order => order.Total < 500));

            //foreach (var item in list_42)
            //    foreach (var order in item)
            //        Console.WriteLine(order);


            ////7
            //var list_43 = ListGenerators.CustomerList.Select(ele => ele.Orders.Where(order => order.OrderDate.Year == 1998));

            //foreach (var item in list_43)
            //    foreach (var order in item)
            //        Console.WriteLine(order);

            #endregion

            #region Quantifiers
            ////1
            //var Contained = Words.Any(word => word.Contains("ei"));
            //Console.WriteLine(Contained);


            ////2
            //var list_44 = ListGenerators.ProductList.GroupBy(p => p.Category).Where(p => p.Any(p => p.UnitsInStock == 0));
            //foreach (var item in list_44)
            //{
            //    Console.WriteLine(item);
            //    foreach (var order in item)
            //        Console.WriteLine(order);
            //}

            ////3
            //var list_45 = ListGenerators.ProductList.Where(p => p.UnitPrice != 0).GroupBy(p => p.Category);
            //foreach (var item in list_45)
            //foreach (var order in item)
            //        Console.WriteLine(order);

            #endregion

            #region Grouping Operators

            ////1
            //int[] Numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            //var list_46 = Numbers.GroupBy(n => n % 5).Select(n => n);
            //int i = 0;
            //foreach (var num in list_46)
            //{
            //    Console.WriteLine($"Numbers with a remainder of {i++} when divided by 5 ");
            //    foreach (var unit in num)
            //        Console.WriteLine(unit);
            //}


            ////2
            //var list_47 = Words.GroupBy(c => c[0]).Select(c => c);
            //char ch = 'A';
            //foreach (var grpp in list_47)
            //{
            //    Console.WriteLine($"Words with a letter of {ch++}: ");
            //    foreach (var w in grpp)
            //        Console.WriteLine(w);
            //}

            ////3
            //string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            //var list_48 = Arr.GroupBy(word => new string(word.Trim().OrderBy(c => c).ToArray()));
            //foreach (var grp in list_48)
            //    foreach (var wrd in grp)
            //        Console.WriteLine(wrd);

            #endregion
        }
    }
}