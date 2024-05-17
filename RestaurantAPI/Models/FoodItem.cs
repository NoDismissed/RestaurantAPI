using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class FoodItem
    {
        [Key]
        public int FDI_ID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FDI_Name { get; set; }
        public string FDI_Price { get; set; }
    }
}
