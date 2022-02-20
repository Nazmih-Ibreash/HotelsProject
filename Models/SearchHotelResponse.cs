namespace Hotels.Models
{
    public class SearchHotelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        //return other needed fields
        public string City { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

    }
}
