namespace app.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public IEnumerable<Comment>? Comments{ get; set; }

    }
}
