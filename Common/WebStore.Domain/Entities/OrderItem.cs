using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Order Item
    /// </summary>
    public class OrderItem : BaseEntity
    {
        /// <summary>
        /// Order
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Products in Order
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Product price in Order
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Qty of Products in Order
        /// </summary>
        public int Count { get; set; }
    }
}