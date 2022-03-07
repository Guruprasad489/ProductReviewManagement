using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class ProductReviewManager
    {
        //UC1 - Method to add the product review into the list
        public static List<ProductReview> AddProductReviewToList(List<ProductReview> products)
        {
            try
            {
                products.Add(new ProductReview() { ProductId = 1, UserId = 1, Review = "Very Good", Rating = 5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 2, UserId = 2, Review = "Good", Rating = 4, IsLike = true });
                products.Add(new ProductReview() { ProductId = 3, UserId = 3, Review = "Average", Rating = 3, IsLike = false });
                products.Add(new ProductReview() { ProductId = 4, UserId = 4, Review = "Good", Rating = 4, IsLike = true });
                products.Add(new ProductReview() { ProductId = 5, UserId = 5, Review = "Very Good", Rating = 5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 6, UserId = 6, Review = "Bad", Rating = 2, IsLike = false });
                products.Add(new ProductReview() { ProductId = 7, UserId = 7, Review = "Very Good", Rating = 5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 8, UserId = 15, Review = "Average", Rating = 3.5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 9, UserId = 9, Review = "Average", Rating = 3.5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 10, UserId = 10, Review = "Good", Rating = 4, IsLike = true });
                products.Add(new ProductReview() { ProductId = 2, UserId = 1, Review = "Very Good", Rating = 5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 3, UserId = 2, Review = "Bad", Rating = 2.5, IsLike = false });
                products.Add(new ProductReview() { ProductId = 5, UserId = 3, Review = "Good", Rating = 4.5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 7, UserId = 4, Review = "Good", Rating = 4, IsLike = true });
                products.Add(new ProductReview() { ProductId = 9, UserId = 5, Review = "Good", Rating = 4, IsLike = true });
                products.Add(new ProductReview() { ProductId = 11, UserId = 6, Review = "Average", Rating = 3.5, IsLike = false });
                products.Add(new ProductReview() { ProductId = 1, UserId = 7, Review = "Bad", Rating = 2.5, IsLike = false });
                products.Add(new ProductReview() { ProductId = 3, UserId = 8, Review = "Good", Rating = 4.5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 2, UserId = 8, Review = "Bad", Rating = 2.5, IsLike = false });
                products.Add(new ProductReview() { ProductId = 4, UserId = 9, Review = "Average", Rating = 3.5, IsLike = false });
                products.Add(new ProductReview() { ProductId = 6, UserId = 10, Review = "Good", Rating = 4.5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 8, UserId = 11, Review = "Average", Rating = 3, IsLike = false });
                products.Add(new ProductReview() { ProductId = 9, UserId = 12, Review = "Good", Rating = 4.5, IsLike = true });
                products.Add(new ProductReview() { ProductId = 5, UserId = 13, Review = "Average", Rating = 3.5, IsLike = false });
                products.Add(new ProductReview() { ProductId = 10, UserId = 14, Review = "Average", Rating = 3, IsLike = false });
                Console.WriteLine("Successfully Added The Products Review To The List");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
        }

        //Method to iterate over list (Display)
        public static void IterateOverList(List<ProductReview> products)
        {
            try
            {
                if (products != null)
                {
                    foreach (ProductReview product in products)
                    {
                        Console.WriteLine(product);
                    }
                }
                else
                    Console.WriteLine("No Products Reviews Added In The List");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //UC2 - Method to retrieve top 3 records from  the list based on highest rating using LINQ
        public static List<ProductReview> RetrieveTopThreeRatingsRecord(List<ProductReview> products)
        {
            if (products != null)
            {
                var productRating = products.OrderByDescending(p => p.Rating).Take(3).ToList();
                Console.WriteLine("\nPrinting Top 3 Products Reviews Records Based On Rating");
                IterateOverList(productRating);
                return productRating;
            }
            else
            {
                Console.WriteLine("Products Reviews not found In The List");
                return default;
            }
        }

        //UC3 - Method to retrieve records from the list rating greater than 3 and product id 1 or 4 or 9 using LINQ
        public static List<ProductReview> RetrieveParticularRecords(List<ProductReview> products)
        {
            if (products != null)
            {
                var resProductList = (from product in products where (product.ProductId == 1 || product.ProductId == 4 || product.ProductId == 9) && product.Rating > 3 select product).ToList();
                Console.WriteLine("\nRecords Based On Rating And ProductId");
                IterateOverList(resProductList);
                return resProductList;
            }
            else
            {
                Console.WriteLine("Products Review not found In The List");
                return default;
            }
        }

        //UC4 - Method to retrieve count of review by product id from the list using LINQ
        public static void RetrieveProductIdCount(List<ProductReview> products)
        {
            if (products != null)
            {
                var resProductCount = products.GroupBy(x => x.ProductId).Select(p => new { productId = p.Key, count = p.Count() });
                Console.WriteLine("\nCount of Product Review Based On Product Id");
                foreach (var product in resProductCount)
                {
                    Console.WriteLine($"Product Id : {product.productId},  Product Count : {product.count}");
                }
            }
            else
            {
                Console.WriteLine("Products Reviews not found In The List");
            }
        }

        //UC5 - Method to retrieve only productId and review from the list for all records using LINQ
        public static void RetrieveProductIdAndReview(List<ProductReview> products)
        {
            if (products != null)
            {
                var productList = products.Select(p => new { productId = p.ProductId, review = p.Review }).ToList();
                foreach (var product in productList)
                {
                    Console.WriteLine($"Product Id : {product.productId},  Product Reviews : {product.review}");
                }
            }
            else
            {
                Console.WriteLine("No Products Review Added In The List");
            }
        }

        //UC6 - Method to skip top 5 records retrieve other records using LINQ
        public static List<ProductReview> SkipTopFiveRecords(List<ProductReview> products)
        {
            if (products != null)
            {
                var resProductList = (from p in products orderby p.Rating descending select p).Skip(5).ToList();
                Console.WriteLine("Printing Records By Skipping Top 5 Records");
                IterateOverList(resProductList);
                return resProductList;
            }
            else
            {
                Console.WriteLine("Products Reviews not found In The List");
                return default;
            }
        }

        //UC7 - Method to retrieve only productId and review from the list for all records using select
        public static void RetrieveProductIdAndReviewBySelect(List<ProductReview> products)
        {
            if (products != null)
            {
                var productList = from p in products select p;
                Console.WriteLine("\nPrinting Product Id and Product Review records by using select");
                foreach (var product in productList)
                    Console.WriteLine($"Product Id: {product.ProductId},  Product Reviews: {product.Review}");
            }
            else
                Console.WriteLine("Products Review not found In The List");
        }

        //UC8 - Method to create data table and add values
        public static DataTable CreateDataTableAndAddValues(List<ProductReview> products)
        {
            if (products != null)
            {
                DataTable dataTable = new DataTable();
                //Adding columns to data table and their type
                dataTable.Columns.Add("ProductId", typeof(int));
                dataTable.Columns.Add("UserId", typeof(int));
                dataTable.Columns.Add("Rating", typeof(double));
                dataTable.Columns.Add("Review", typeof(string));
                dataTable.Columns.Add("IsLike", typeof(bool));

                //Adding values to datatable from the list
                foreach (var data in products)
                {
                    dataTable.Rows.Add(data.ProductId, data.UserId, data.Rating, data.Review, data.IsLike);
                }
                Console.WriteLine("Successfully added values to datatable");
                return dataTable;
            }
            else
            {
                Console.WriteLine("Products Reviews not found In The List");
                return default;
            }
        }

        //UC9 - Method to retreive records where isLike is true
        public static void RetreiveRecordsForIsLikeTrue(List<ProductReview> products)
        {
            if (products != null)
            {
                DataTable dataTable = CreateDataTableAndAddValues(products);
                var resRows = from table in dataTable.AsEnumerable() where table.Field<bool>("IsLike") == true select table;
                Console.WriteLine($"ProductId,  UserId,  Rating,  Review,  IsLike");
                foreach (var row in resRows)
                {
                    Console.WriteLine($"{row["ProductId"]},  {row["UserId"]},  {row["Rating"]},  {row["Review"]},  {row["IsLike"]}");
                }
            }
            else
            {
                Console.WriteLine("Products Review not found In The List");
            }
        }

        //UC10 - Method to Find, retreive average rating for each product id
        public static void FindAvgRatingForEachProductId(List<ProductReview> products)
        {
            if (products != null)
            {
                DataTable dataTable = CreateDataTableAndAddValues(products);
                var resatingAverage = from product in dataTable.AsEnumerable() group product by product.Field<int>("ProductId") into temp select new { productid = temp.Key, average = Math.Round(temp.Average(x => x.Field<double>("Rating")), 3) };
                foreach (var row in resatingAverage)
                {
                    Console.WriteLine("Product Id: {0} \tAverage Ratings: {1}", row.productid, row.average);
                }
            }
            else
            {
                Console.WriteLine("Products Review not found In The List");
            }
        }

        //UC11 - Method to retreive rating contains "Nice" or "Good" in review message from datatable
        public static void GetNiceReviewRecordsFromTable(List<ProductReview> products)
        {
            if (products != null)
            {
                DataTable dataTable = CreateDataTableAndAddValues(products);
                var resRows = from table in dataTable.AsEnumerable() where table.Field<string>("Review").Contains("Nice") || table.Field<string>("Review").Contains("Good") select table;
                Console.WriteLine($"ProductId,  UserId,  Rating,  Review,  IsLike");
                foreach (var row in resRows)
                {
                    Console.WriteLine($"{row["ProductId"]},  {row["UserId"]},  {row["Rating"]},  {row["Review"]},  {row["IsLike"]}");
                }
            }
            else
            {
                Console.WriteLine("No Products Review Added In The List");
            }
        }
    }
}
