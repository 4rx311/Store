namespace Store.Application.Products.RegisterProduct
{
    public class RegisterProductRequest
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Currency { get; set; }
    }
}
