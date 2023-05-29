using bmb.Entities;
using bmb.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Classes
{
    public class OrderBusiness : IOrder
    {
        readonly bmbContext _bmbContext;
        public OrderBusiness(bmbContext bmbContext)
        {
            _bmbContext = bmbContext;
        }

        public async Task<List<Orders>> GetAllOrders()
        {
            return await _bmbContext.orders.ToListAsync();
        }
        public async Task<Orders> GetAllOrdersByOrderId(int orderId)
        {
            return await _bmbContext.orders.Where(x=>x.id == orderId).FirstOrDefaultAsync();
        }
        public async Task<List<Orders>> GetAllOrdersByCustomerId(int customerId)
        {
            return await _bmbContext.orders.Where(x=>x.customerId==customerId).ToListAsync();
        }
        public async Task<Orders> CreateOrder(Orders orders)
        {
            await _bmbContext.orders.AddAsync(orders);
            await _bmbContext.SaveChangesAsync();
            return orders;
        }
        public async Task<bool> Delete(int CustomerCode)
        {
            try { 
            List<Orders> orders = await _bmbContext.orders.Where(x=>x.customerId == CustomerCode).ToListAsync();
             _bmbContext.orders.RemoveRange(orders);
            await _bmbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

    }
}
