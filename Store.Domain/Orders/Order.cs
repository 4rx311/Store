using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain.Products;
using Store.Domain.SeedWork;
using Store.Domain.SharedKernel;

namespace Store.Domain.Orders
{
    public sealed class Order : Entity, IAggregateRoot
    {
        //Для БД
        private Order()
        {
            _orderProducts = new List<OrderProduct>();
        }

        private Order(string customerName, string customerEmail, List<Product> products,
            List<OrderProductData> productDatas, string currency)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            OrderId = new OrderId(Guid.NewGuid());
            _orderProducts = new List<OrderProduct>();

            foreach (var productData in productDatas)
            {
                var product = products.Single(p => p.ProductId == productData.ProductId);
                var orderProduct = OrderProduct.Create(product, productData.Quantity, currency);
                _orderProducts.Add(orderProduct);
            }

            Calculate();
            AddDomainEvent(new CreateOrderEvent(OrderId));
        }

        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public OrderId OrderId { get; }
        public MoneyValue Value { get; private set; }

        private readonly List<OrderProduct> _orderProducts;

        public static Order Create(string customerName, string customerEmail,
            List<Product> products, List<OrderProductData> productDatas, string currency)
        {
            return new Order(customerName, customerEmail, products, productDatas, currency);
        }


        private void Calculate()
        {
            var totalPrice = _orderProducts.Sum(p => p.Value.Value);
            var currency = _orderProducts.First().Value.Currency;
            Value = new MoneyValue(totalPrice, currency);
        }
    }
}
