using Autofac;
using Store.Application.Products.DomainServices;
using Store.Domain.Products;

namespace Store.Infrastructre.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductUniquenessChecker>()
                .As<IProductUniquenessChecker>()
                .InstancePerLifetimeScope();
        }
    }
}
