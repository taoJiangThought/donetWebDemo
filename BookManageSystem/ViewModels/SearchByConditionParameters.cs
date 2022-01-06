using System.Collections.Generic;

namespace BookManageSystem.ViewModels
{
    public class SearchByConditionParameters
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IdentificationCode { get; set; } 
        public string Type { get; set; } 
        public double Price { get; set; }
        public List<Order> Orders { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        
    }
}