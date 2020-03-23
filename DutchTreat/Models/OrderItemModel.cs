namespace DutchTreat.Models
{
	public class OrderItemModel
	{
        public int Id { get; set; }
        [Requierd]
        public int Quantity { get; set; }
        [Requierd]
        public decimal UnitPrice { get; set; }
        [Requierd]
        public int ProductId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSize { get; set; }
        public string ProductTitle { get; set; }
        public string ProductArtist { get; set; }
        public string ProductArtId { get; set; }
    }
}