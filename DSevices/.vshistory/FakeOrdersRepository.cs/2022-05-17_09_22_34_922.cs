using DData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSevices
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrdersForCustomersAsync(Guid customerId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<List<Product>> GetProductsAsync();
        Task<List<OrderStatus>> GetOrderStatusesAsync();
    }


    public class FakeOrdersRepository : IOrdersRepository
    {
        public Task<Order> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersForCustomersAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
