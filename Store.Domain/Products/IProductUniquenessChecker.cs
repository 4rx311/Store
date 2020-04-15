namespace Store.Domain.Products
{
    public interface IProductUniquenessChecker
    {
        bool IsUniqueName(string name);
    }
}
