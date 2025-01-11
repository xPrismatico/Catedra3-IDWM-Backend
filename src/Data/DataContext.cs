using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using api.src.Models;
using Microsoft.AspNetCore.Identity;


namespace api.src.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; } = null!;
        public new DbSet<User> Users { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.Entity<IdentityUserLogin<string>>().HasKey(login => login.UserId);
            builder.Entity<IdentityUserRole<string>>().HasKey(userRole => new { userRole.UserId, userRole.RoleId });
            builder.Entity<IdentityUserClaim<string>>().HasKey(userClaim => userClaim.Id);
            builder.Entity<IdentityRoleClaim<string>>().HasKey(roleClaim => roleClaim.Id);
            builder.Entity<IdentityUserToken<string>>().HasKey(userToken => new { userToken.UserId, userToken.LoginProvider, userToken.Name });
        }

    }
}