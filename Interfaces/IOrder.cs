using bmb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Interfaces
{
    public interface IOrder
    {
        Task<Orders> CreateOrder(Orders orders);
        Task<bool> Delete(int CustomerCode);
        Task<List<Orders>> GetAllOrders();
        Task<List<Orders>> GetAllOrdersByCustomerId(int customerId);
        Task<Orders> GetAllOrdersByOrderId(int orderId);
    }
}
