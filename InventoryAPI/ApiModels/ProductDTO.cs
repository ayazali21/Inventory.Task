using InventoryCore.Entity;
using InventoryCore.Enum;

namespace InventoryAPI.ApiModels
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public bool IsWeighted { get; set; }
        public ProductStatus Status { get; set; }

        public static ProductDTO FromProduct(Product item)
        {
            return new ProductDTO()
            {
                Status= item.Status,
                Name= item.Name,    
                Barcode= item.Barcode,
                Description= item.Description,
                CategoryName= item.CategoryName,
                IsWeighted = item.IsWeighted
            };
        }
    }
}
