using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Data.Entities
{
    public class ProductCategory :BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
