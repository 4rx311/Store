namespace Store.Application.Products.RegisterProduct
{
    public sealed class RegisterProductCommand : ICommand<ProductDto>
    {
        public RegisterProductCommand(string name, decimal cost, string currency)
        {
            Name = name;
            Cost = cost;
            Currency = currency;
        }

        public string Name { get; }
        public decimal Cost { get; }
        public string Currency { get; }
    }
}
