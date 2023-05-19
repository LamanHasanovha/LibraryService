namespace PaymentAPI.Models
{
    public class OrderInfoModel
    {
        public OrderInfoModel() { }

        public OrderInfoModel(string name, decimal price, int productType)
        {
            Name = name;
            Price = price;
            ProductType = productType;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductType { get; set; } // 1-book 2-movie
    }
}
