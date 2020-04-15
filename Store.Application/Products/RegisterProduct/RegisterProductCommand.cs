namespace Store.Application.Products.RegisterProduct
{
    public sealed class RegisterProductCommand : ICommand<ProductDto>
    {
        public RegisterProductCommand(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; }
        public double Cost { get; }
    }
}
