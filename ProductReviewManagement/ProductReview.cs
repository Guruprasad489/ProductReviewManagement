using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class ProductReview
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool IsLike { get; set; }

        //Method to override tostring
        public override string ToString()
        {
            return $"Product Id: {ProductId},  User Id: {UserId},  Product Rating: {Rating},  Product Review: {Review},  IsLike: {IsLike}";
        }
    }
}
