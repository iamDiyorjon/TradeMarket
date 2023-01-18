using System.Collections.Generic;

namespace Business.Models
{
    public class FilterSearchModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<int> ProductsId { get; set; }
    }
}