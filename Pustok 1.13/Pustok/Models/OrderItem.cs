using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercent { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
