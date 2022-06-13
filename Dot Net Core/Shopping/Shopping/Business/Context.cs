using Microsoft.EntityFrameworkCore;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Business
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
