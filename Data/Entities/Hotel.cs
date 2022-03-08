using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Data.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int Stars { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
    }
}
