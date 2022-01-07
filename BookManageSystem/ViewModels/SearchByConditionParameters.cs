using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManageSystem.ViewModels
{
    public class SearchByConditionParameters
    {
        // public int Id { get; set; }
        public string Title { get; set; }
        // public string IdentificationCode { get; set; } 
        // public string Type { get; set; } 
        // public double Price { get; set; }
        // public List<Order> Orders { get; set; }
        [Range(0,1 )]
        [Required]
        public int OrderByTitle { get; set; }
        [Range(1, 100)]
        [Required]
        public int Page { get; set; }
        [Range(1, 100)]
        [Required]
        public int PageSize { get; set; }
        
    }
}