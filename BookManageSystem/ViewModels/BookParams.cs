using System;

namespace BookManageSystem.ViewModels
{
    public class BookParams
    {
        public string Title { get; set; }
        public string IdentificationCode { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}