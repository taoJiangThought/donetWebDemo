using System;

namespace BookManageSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IdentificationCode { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}