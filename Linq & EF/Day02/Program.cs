using System.Collections;
using L2O___D09;

namespace Day02;

class Program
{
    static void Print<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("========================================================================");
    }
    static void Print<T>(T item)
    {
        Console.WriteLine(item);
        Console.WriteLine("========================================================================");
    }

    public class CustomCompare : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }
    public class AnagramComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return SortChars(x.Trim()) == SortChars(y.Trim());
        }

        public int GetHashCode(string obj)
        {
            return SortChars(obj.Trim()).GetHashCode();
        }

        private string SortChars(string word)
        {
            char[] chars = word.ToLower().ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
    static void Main(string[] args)
    {

        #region Restriction Operators
        // // 1 Find all products that are out of stock.
        // var productsOutOfStock = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0);
        // Print(productsOutOfStock);

        // // 2. Find all products that are in stock and cost more than 3.00 per unit.
        // var productsOutOfStockUnit = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0 && p.UnitPrice > 3);
        // Print(productsOutOfStockUnit);

        // // 3. Returns digits whose name is shorter than their value.
        // string[] Arr = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        // var digitsShorterThanValue =  Arr.Select((name, index) => new {Name = name, Idx = index}).Where(e => e.Name.Length < e.Idx).Select(e => e.Name);
        // Print(digitsShorterThanValue);
        #endregion
    
        #region Element Operators
        // // 1. Get first Product out of Stock 
        // var firstProductOutOfStock = ListGenerators.ProductList.First(e => e.UnitsInStock == 0).ProductName; // Error if Not Fount Product
        // Print(firstProductOutOfStock);

        // // 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
        // var firstProductMoreThan1000 = ListGenerators.ProductList.FirstOrDefault(e => e.UnitPrice > 1000)?.ProductName;
        // Print(firstProductOutOfStock);

        // // 3.  Retrieve the second number greater than 5 
        // int[] Arr = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        // var secondNumberGreaterThan5  = Arr.Where(e => e > 5).ElementAtOrDefault(1);
        // Print(secondNumberGreaterThan5);
        #endregion
    
        #region Set Operators
        // // 1. Find the unique Category names from Product List
        // var findUnique = ListGenerators.ProductList.DistinctBy(e => e.Category).Select(e => e.Category);
        // Print(findUnique);

        // // 2. Produce a Sequence containing the unique first letter from both product and customer names.
        // var firstLettersCustomer = ListGenerators.CustomerList.Select(e => e.CompanyName[0]);
        // var firstLettersProduct = ListGenerators.ProductList.Select(e => e.ProductName[0]);
        // var sequenceUnique = firstLettersCustomer.Union(firstLettersProduct);
        // Print(sequenceUnique);

        // // 3. Create one sequence that contains the common first letter from both product and customer names.
        // var sequenceCommon = firstLettersCustomer.Intersect(firstLettersProduct);
        // Print(sequenceCommon);
        
        // // 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
        // var sequenceContainsProductNotCustomer = firstLettersProduct.Except(firstLettersCustomer);
        // Print(sequenceContainsProductNotCustomer);

        // // 5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
        // var lastThreeLettersCustomer = ListGenerators.CustomerList.Select(e => e.CompanyName[^3..]);
        // var lastThreeLettersProduct = ListGenerators.ProductList.Select(e => e.ProductName.Substring(e.ProductName.Length - 3));
        // var sequenceIncludeUnique = lastThreeLettersCustomer.Concat(lastThreeLettersProduct);
        // Print(sequenceIncludeUnique);
        #endregion
    
        #region Aggregate Operators
        // // 1. Uses Count to get the number of odd numbers in the array
        // int[] Arr = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
        // var countNumber = Arr.Count(e => e % 2 != 0);
        // Print(countNumber);


        // // 2. Return a list of customers and how many orders each has.
        // var listOfCustomersNoOfOrder = ListGenerators.CustomerList.Select(e => new {Name = e.CompanyName, NoOfOrders = e.Orders.Count()});
        // Print(listOfCustomersNoOfOrder);


        // // 3. Return a list of categories and how many products each has
        // var categoriesNoOfProducts = ListGenerators.ProductList.Select(e => new {CategoryName = e.Category, NoOfProduct = e.Category.Count()}).Distinct();
        // Print(categoriesNoOfProducts);

        // // 4. Get the total of the numbers in an array.
        // var sumNumber = Arr.Sum();
        // Print(sumNumber);

        // // 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        // string path = Path.Combine(
        //     AppContext.BaseDirectory,
        //     "Tasks",
        //     "Assignment Files",
        //     "dictionary_english.txt"
        // );

        // string[] words = File.ReadAllLines(path); 
        // var totalChars = words.Sum(e => e.Length);
        // Print(totalChars);

        // // 6. Get the total units in stock for each product category.
        // var totalUnitsInStockForEachCategory = ListGenerators.ProductList.GroupBy(e => e.Category).Select(e => new {CategoryName = e.Key, NoOfStockEachProduct = e.Sum(e => e.UnitsInStock)} );
        // Print(totalUnitsInStockForEachCategory);

        // // 7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        // var lengthOfShortestWord = words.Min(e => e.Length);
        // Print(lengthOfShortestWord);

        // // 8. Get the cheapest price among each category's products
        // var cheapestPriceForEachCategory = ListGenerators.ProductList.GroupBy(e => e.Category).Select(e => new {CategoryName = e.Key, CheapestPrice = e.Min(e => e.UnitPrice)} );
        // Print(cheapestPriceForEachCategory);

        // // 9. Get the products with the cheapest price in each category (Use Let)
        // var productsWithCheapestPriceForEachCategory =  from Product in ListGenerators.ProductList
        //                                                 group Product by Product.Category into g
        //                                                 let minPrice = g.Min(p => p.UnitPrice)
        //                                                 select new
        //                                                 {
        //                                                     Category = g.Key,
        //                                                     CheapestProducts = g.Where(p => p.UnitPrice == minPrice)
        //                                                 };
        // foreach (var category in productsWithCheapestPriceForEachCategory)
        // {
        //     Console.WriteLine($"Category: {category.Category}");

        //     foreach (var product in category.CheapestProducts)
        //     {
        //         Console.WriteLine($"  {product.ProductName} - {product.UnitPrice}");
        //     }
        // }

        // Console.WriteLine("========================================================================");

        // // 10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        // var lengthOfLongestWord = words.Max(e => e.Length);
        // Print(lengthOfLongestWord);

        // // 11. Get the most expensive price among each category's products.  
        // // 12. Get the products with the most expensive price in each category.
        // var productsWithExpensivePriceForEachCategory =
        //     ListGenerators.ProductList
        //         .GroupBy(p => p.Category)
        //         .Select(g => new
        //         {
        //             Category = g.Key,
        //             ExpensiveProduct = g.Where(p => p.UnitPrice == g.Max(x => x.UnitPrice))
        //         });

        // foreach (var category in productsWithExpensivePriceForEachCategory)
        // {
        //     Console.WriteLine($"Category: {category.Category}");

        //     foreach (var product in category.ExpensiveProduct)
        //     {
        //         Console.WriteLine($"  {product.ProductName} - {product.UnitPrice}");
        //     }
        // }

        // // 13. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        // var averageLengthOfLongestWord = words.Average(e => e.Length);
        // Print(averageLengthOfLongestWord);

        // // 14. Get the average price of each category's products.
        // var productsWithAvgPriceForEachCategory =
        //     ListGenerators.ProductList
        //         .GroupBy(p => p.Category)
        //         .Select(g => new
        //         {
        //             Category = g.Key,
        //             AveragePrice = g.Average(p => p.UnitPrice)
        //         });
        // Print(productsWithAvgPriceForEachCategory);
        #endregion
    
        #region Ordering Operators
        // // 1. Sort a list of products by name
        // var sortByName = ListGenerators.ProductList.OrderBy(e => e.ProductName).Select(e => e.ProductName);
        // Print(sortByName);

        // // 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
        // string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        // var sortCaseInsensitive = Arr.OrderBy(e => e, new CustomCompare()).Select(e => e);
        // Print(sortCaseInsensitive);

        // // 3. Sort a list of products by units in stock from highest to lowest.
        // var sortByUnitsInStock = ListGenerators.ProductList.OrderBy(e => e.UnitsInStock).Select(e => new {Product = e.ProductName, NoOfStock = e.UnitsInStock});
        // Print(sortByUnitsInStock);

        // // 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
        // string[] Arr1 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        // var sortDigits = Arr1.OrderBy(e => e.Length).ThenBy(e => e).Select(e => e);;
        // Print(sortDigits);

        // // 5. Sort first by word length and then by a case-insensitive sort of the words in an array.
        // var sortByLengthCaseInsensitive = Arr.OrderBy(e => e.Length).ThenBy(e => e, new CustomCompare()).Select(e => e);
        // Print(sortByLengthCaseInsensitive);

        // // 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
        // var sortByCategoryThenPrice = ListGenerators.ProductList.OrderByDescending(e => e.Category).ThenByDescending(e => e.UnitPrice).Select(e => new {CategoryName = e.Category, Price = e.UnitPrice});
        // Print(sortByUnitsInStock);

        // // 7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.
        // var sortLengthThenCaseInsensitive = Arr.OrderBy(e => e.Length).ThenByDescending(e => e, new CustomCompare()).Select(e => e);
        // Print(sortCaseInsensitive);

        // // 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
        // var ListDigitsI = Arr1.Where(e => e[1] == 'i').Reverse();
        // Print(ListDigitsI);
        #endregion

        #region Partitioning Operators
        // // 1. Get the first 3 orders from customers in Washington
        // var first3Orders = ListGenerators.CustomerList.Where(c => c.City == "Mannheim").SelectMany(c => c.Orders).Take(3).Select(e => e);        
        // Print(first3Orders);

        // // 2. Get all but the first 2 orders from customers in Washington.
        // var allButIgnore2Orders = ListGenerators.CustomerList.Where(c => c.City == "Mannheim").SelectMany(c => c.Orders).Skip(2);        
        // Print(allButIgnore2Orders);

        // // 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
        // int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
        // int idx = 0;
        // var elementsUntilIndexMoreThanValue = numbers.TakeWhile(e => e >= idx++);
        // Print(elementsUntilIndexMoreThanValue);

        // // 4. Get the elements of the array starting from the first element divisible by 3.
        // var elementsDivisibleBy = numbers.SkipWhile(e => e % 3 != 0);
        // Print(elementsDivisibleBy);

        // // 5. Get the elements of the array starting from the first element less than its position.
        // idx = 0;
        // var elementsMoreThanIndex = numbers.SkipWhile(e => e >= idx++);
        // Print(elementsMoreThanIndex);

        #endregion
    
        #region Projection Operators
        // // 1. Return a sequence of just the names of a list of products.
        // var productNames = ListGenerators.ProductList.Select(p => p.ProductName);
        // Print(productNames);

        // // 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
        // string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

        // var sequenceLowerAndUpper = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower()});
        // Print(sequenceLowerAndUpper);

        // // 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
        // var sequenceSomeProperties = ListGenerators.ProductList.Select(e => new {Product = e.ProductName, Price = e.UnitPrice});
        // Print(sequenceSomeProperties);

        // // 4. Determine if the value of ints in an array match their position in the array.
        // int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        // var matchIndex = Arr.Select((value, index) => new { value, index, IsMatch = value == index});
        // Print(matchIndex);

        // // 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
        // int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        // int[] numbersB = { 1, 3, 5, 7, 8 };

        // var pairsOfNumbers = numbersA.SelectMany(a => numbersB,(a, b) => new { a, b }).Where(x => x.a < x.b);

        // foreach (var item in pairsOfNumbers)
        // {
        //     Console.WriteLine($"{item.a} is less than {item.b}");
        // }

        // // 6. Select all orders where the order total is less than 500.00.
        // var ordersTotalLessThan500 = ListGenerators.CustomerList.SelectMany(e => e.Orders).Where(e => e.Total < 500); 
        // Print(ordersTotalLessThan500);

        // // 7. Select all orders where the order was made in 1998 or later.
        // var ordersT1998OrLater = ListGenerators.CustomerList.SelectMany(e => e.Orders).Where(e => e.OrderDate.Year >= 1998); 
        // Print(ordersT1998OrLater);
        #endregion

        #region Quantifiers
        // //1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
        // string path = Path.Combine(
        //     AppContext.BaseDirectory,
        //     "Tasks",
        //     "Assignment Files",
        //     "dictionary_english.txt"
        // );

        // string[] words = File.ReadAllLines(path); 

        // var wordsContainEI = words.Any(e => e.Contains("ei"));
        // Print(wordsContainEI);

        // // 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
        // var groupedProducts = ListGenerators.ProductList.GroupBy(p => p.Category).Where(g => g.Any(p => p.UnitsInStock == 0)).Select(g => new {Category = g.Key, Products = g});
        // foreach (var category in groupedProducts)
        // {
        //     Console.WriteLine($"Category: {category.Category}");

        //     foreach (var product in category.Products)
        //     {
        //         Console.WriteLine($"  {product.ProductName} - Stock: {product.UnitsInStock}");
        //     }
        // }

        // Console.WriteLine("========================================================================");

        // // 3. Return a grouped a list of products only for categories that have all of their products in stock.
        // var groupedProductsAll = ListGenerators.ProductList.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock > 0)).Select(g => new {Category = g.Key, Products = g});
        // foreach (var category in groupedProductsAll)
        // {
        //     Console.WriteLine($"Category: {category.Category}");

        //     foreach (var product in category.Products)
        //     {
        //         Console.WriteLine($"  {product.ProductName} - Stock: {product.UnitsInStock}");
        //     }
        // }
        #endregion

        #region Grouping Operators
        // // 1. Use group by to partition a list of numbers by their remainder when divided by 5
        // int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        // var groupedNumbersMod5 = numbers.GroupBy(n => n % 5);

        // foreach (var group in groupedNumbersMod5)
        // {
        //     Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");

        //     foreach (var number in group)
        //     {
        //         Console.WriteLine(number);
        //     }
        // }

        // Console.WriteLine("========================================================================");

        // // 2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input
        // string path = Path.Combine(
        //     AppContext.BaseDirectory,
        //     "Tasks",
        //     "Assignment Files",
        //     "dictionary_english.txt"
        // );

        // string[] words = File.ReadAllLines(path);

        // var groupByFirstLetter = words.GroupBy(w => w[0]);

        // foreach (var group in groupByFirstLetter)
        // {
        //     Console.WriteLine($"Words that start with '{group.Key}':");

        //     foreach (var word in group)
        //     {
        //         Console.WriteLine(word);
        //     }

        //     Console.WriteLine();
        // }

        // Console.WriteLine("========================================================================");

        // // Consider this Array as an Input 
        // string[] Arr = ["from   ", " salt", " earn ", "  last   ", " near ", " form  "];
        // var groupByCustomCompere = Arr.GroupBy(word => word.Trim(), new AnagramComparer());

        // foreach (var group in groupByCustomCompere)
        // {
        //     Console.WriteLine("...");

        //     foreach (var word in group)
        //     {
        //         Console.WriteLine(word.Trim());
        //     }
        // }
        #endregion

    }
}

