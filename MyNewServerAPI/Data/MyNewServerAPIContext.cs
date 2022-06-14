using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNewServerAPI.Models;

namespace MyNewServerAPI.Data
{
    public class MyNewServerAPIContext : DbContext
    {
        public MyNewServerAPIContext (DbContextOptions<MyNewServerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MyNewServerAPI.Models.User>? User { get; set; }
    }
}
