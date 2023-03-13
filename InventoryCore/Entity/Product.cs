using InventoryCore.Enum;
using InventoryCore.Events;
using System;
using System.Runtime.CompilerServices;

namespace InventoryCore.Entity
{
	public class Product : BaseEntity
	{
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public bool IsWeighted { get; set; }
        public ProductStatus Status { get; set; }

        public Product()
        {

        }
        public Product(string name, string barcode, string description, string categoryName, bool isWeighted, ProductStatus status)
        {
            Name = name;
            Barcode = barcode;
            Description = description;
            CategoryName = categoryName;
            IsWeighted = isWeighted;
            Status = status;
        }

        public void MarkAsSold()
        {
            Status = ProductStatus.Sold;
            AddDomainEvent(new ProductSoldEvent(this));
        }

        public void ChangeStatus(ProductStatus status)
        {
            Status = status;
        }

        public bool IsSold()
        {
            return Status == ProductStatus.Sold;
        }
    }

    
}

