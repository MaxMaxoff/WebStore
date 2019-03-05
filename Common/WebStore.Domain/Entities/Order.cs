using System;
using System.Collections.Generic;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Order Class
    /// </summary>
    public class Order : NamedEntity
    {
        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Order Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Order Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Order Items
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
