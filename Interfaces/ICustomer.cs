using bmb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Interfaces
{
    public interface ICustomer
    {
        Task<dynamic> Login(string user, string Password);
        Task<Customer> Registration(Customer customer);
    }
}
