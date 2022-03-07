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
                    Console.WriteLine("\nChoose an option \n0: Exit \n1: Add Product Review To List \n2: Show All Product Reviews");
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
