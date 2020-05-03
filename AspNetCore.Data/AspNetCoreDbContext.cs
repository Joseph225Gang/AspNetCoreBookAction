using AspNetCore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data
{
    public class AspNetCoreDbContext : DbContext
    {
        public AspNetCoreDbContext(DbContextOptions<AspNetCoreDbContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
