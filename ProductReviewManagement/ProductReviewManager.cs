using System;
using System.Collections.Generic;
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

        //UC4 - Method to retrieve count of review by product id from the list
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

        //UC5 - Method to retrieve only productId and review from the list for all records
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
    }
}
