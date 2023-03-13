using InventoryCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCore.Events
{
    public class ProductSoldEvent : BaseDomainEvent
    {

        public ProductSoldEvent(Product product)
        {
            Product= product;
        }

        public Product Product { get; }


    }
}
