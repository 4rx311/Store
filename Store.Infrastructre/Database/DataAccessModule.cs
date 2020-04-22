using Autofac;
using Store.Domain.Orders;
using Store.Domain.Products;
using Store.Domain.SeedWork;
using Store.Infrastructre.Domain;
using Store.Infrastructre.Domain.Products;

namespace Store.Infrastructre.Database
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();

            builder.RegisterInstance(new OrdersContext()).AsSelf();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
