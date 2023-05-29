using bmb.Entities;
using bmb.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bmb.Classes
{
    public class CustomerBusiness : ICustomer
    {
        private readonly JWT _jWT;

        readonly bmbContext db;


        public CustomerBusiness(bmbContext _db, IOptions<JWT> jwt)
        {
            db = _db;
            _jWT = jwt.Value;
        }

        public async Task<dynamic> Login(string user, string Password)
        {
            var userValid = await db.customers.Where(x => x.name == user).FirstOrDefaultAsync();
            if (userValid == null)
                return "اسم مستخدم غير صحيح ";

            if (!verifyPassword(Password, userValid.password))
                return "اسم مستخدم غير صحيح ";

            var jwtSecurityToken = await CreateToken(userValid);
            return new Auth
            {
                mail = userValid.mail,
                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                customerId= userValid.id,
                name = userValid.name
            };
           

        }

        public async Task<Customer> Registration(Customer customer)
        {
            if ((!await db.customers.AnyAsync(x => x.mail == customer.mail || x.name == customer.name)))
            {
             
                customer.password = hashPassword(customer.password);
              
                await db.customers.AddAsync(customer);
                await db.SaveChangesAsync();
                return customer;
            }
            else return null;
        }

        public async Task<JwtSecurityToken> CreateToken(Customer user)
        {
            var SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWT.key));
            var SigninngCredintials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var Claims = new[]
            {
                new Claim(ClaimTypes.Name , user.name),
                new Claim(ClaimTypes.SerialNumber , user.id.ToString())
             



            };
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jWT.Issure,
                audience: _jWT.Audince,
                signingCredentials: SigninngCredintials,
                claims: Claims,
                expires: DateTime.Now.AddMonths(60)





                );
            return jwtSecurityToken;
        }

        public static string hashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool verifyPassword(string password, string storedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;

        }

    }
}
