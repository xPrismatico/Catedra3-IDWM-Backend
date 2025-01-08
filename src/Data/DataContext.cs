using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace api.src.Data
{
    public class DataContext (DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        
    }
}