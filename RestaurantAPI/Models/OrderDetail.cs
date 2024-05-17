using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public long ODT_ID { get; set; }
        public long OMT_ID { get; set; }
        public int FDI_ID { get; set; }
        public FoodItem FoodItem { get; set; }
        public decimal ODT_FoodItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}
