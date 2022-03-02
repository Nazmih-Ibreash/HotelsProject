namespace Hotels.Models
{
    public class AddHotelEntity
    {
        public string Name { get; set; }
        public int Stars { get; set; }
        //return other needed fields
        public string City { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
    }
}
