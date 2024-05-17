using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class OrderMaster
    {
        [Key]
        public long OMT_ID { get; set; }
        [Column(TypeName = "nvarchar(75)")]
        public string OMT_OrderNumber { get; set; }
        public int CTM_ID { get; set; }
        public Customer Customer { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string OMT_PMethod { get; set; }
        public decimal OMT_GTotal { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
