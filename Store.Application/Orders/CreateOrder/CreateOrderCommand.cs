﻿using System.Collections.Generic;

namespace Store.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : ICommand<OrderDto>
    {
        public CreateOrderCommand(string currency, List<ProductDto> productsDto, string customerName, string customerEmail)
        {
            Currency = currency;
            ProductsDto = productsDto;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
        }

        public string CustomerName { get; }

        public string CustomerEmail { get; }

        public string Currency { get; }
        public List<ProductDto> ProductsDto { get; }
    }
}
