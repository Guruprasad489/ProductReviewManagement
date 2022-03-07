using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Program
    {
        public static List<ProductReview> productList;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management program");

            List<ProductReview> products = new List<ProductReview>();
            try
            {
                while (true)
                {
                    Console.WriteLine("\nChoose an option \n0. Exit \n1. Add Product Review To List \n2. Show All Product Reviews \n3. Retrieve Top Three Rating Records" +
                                      "\n4. retrieve records rating greater than 3 and productId 1 or 4 or 9 \n5. Count Of Reviews By ProductId \n6. Retrieve ProductId And Review" +
                                      "\n7. Skip Top Five Records \n8. Retrieve Product Id And Review By Select \n9. Create Data Table And Add Values \n10. Retreive Records where IsLike is True");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            productList = ProductReviewManager.AddProductReviewToList(products);
                            break;
                        case 2:
                            ProductReviewManager.IterateOverList(productList);
                            break;
                        case 3:
                            ProductReviewManager.RetrieveTopThreeRatingsRecord(productList);
                            break;
                        case 4:
                            ProductReviewManager.RetrieveParticularRecords(productList);
                            break;
                        case 5:
                            ProductReviewManager.RetrieveProductIdCount(productList);
                            break;
                        case 6:
                            ProductReviewManager.RetrieveProductIdAndReview(productList);
                            break;
                        case 7:
                            ProductReviewManager.SkipTopFiveRecords(productList);
                            break;
                        case 8:
                            ProductReviewManager.RetrieveProductIdAndReviewBySelect(productList);
                            break;
                        case 9:
                            ProductReviewManager.CreateDataTableAndAddValues(productList);
                            break;
                        case 10:
                            ProductReviewManager.RetreiveRecordsForIsLikeTrue(productList);
                            break;
                        default:
                            Console.WriteLine("Please choose the correct option");
                            continue;
                    }
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
