using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeekShooping.IdentityServer.Model.Context
{
    public class SQLContext : IdentityDbContext<IdentityUser>
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
