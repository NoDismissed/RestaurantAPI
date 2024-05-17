using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class Customer
    {
        [Key]
        public int CTM_ID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string CTM_Name { get; set; }
    }
}
