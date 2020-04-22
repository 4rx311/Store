using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Store.API.Orders;
using Store.API.Products;
using Store.Application.Orders.CreateOrder;
using Store.Application.Products.RegisterProduct;
using Store.Infrastructre;
using ProductDto = Store.Application.Orders.CreateOrder.ProductDto;

namespace Store.API
{
    class Program
    {
        //имитация веб-приложения и его встроенного DI
        private IServiceProvider ServiceProvider { get; set; }


        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.Run();
            Console.ReadKey();
        }

        public async Task Run()
        {
            //в веб-приложении вызов ConfigureServices происходит внутри ASP.Net
            //с аргументом IServiceCollection
            ConfigureServices(new ServiceCollection());

            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                var productController = new ProductController(mediator);
                var productDto1 = await productController.Register(new RegisterProductRequest()
                {
                    Name = "Apple",
                    Cost = 150,
                    Currency = "Rub"
                });
                Console.WriteLine($"{productDto1.Name}, {productDto1.Cost}");

                var productDto2 = await productController.Register(new RegisterProductRequest()
                {
                    Name = "Apple Yellow",
                    Cost = 170,
                    Currency = "Rub"
                });
                Console.WriteLine($"{productDto2.Name}, {productDto2.Cost}");

                var orderController = new OrderContoller(mediator);
                var orderId = await orderController.Create(new CreateOrderRequest(
                    "Rub",
                    new List<ProductDto>() {new ProductDto(productDto2.ID, 5)},
                    "DDD",
                    "ddd@slark.com"
                ));

                Console.WriteLine(orderId.Id);
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider = ApplicationStartup.Initialize(services);
        }
    }
}
