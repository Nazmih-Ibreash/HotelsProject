namespace Hotels.Data.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Stars { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
    }
}
