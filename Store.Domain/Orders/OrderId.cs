using System;
using Store.Domain.SeedWork;

namespace Store.Domain.Orders
{
    public sealed class OrderId : TypedIdValue
    {
        public OrderId(Guid value) : base(value)
        {
        }
    }
}
