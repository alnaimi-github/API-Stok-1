using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
           //seed data for stock and comment
              modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                     Id = 1,
                     Symbol = "AAPL",
                     CompanyName = "Apple Inc",
                     Purchase = 120.00m,
                     LastDividend = 0.82m,
                     Industry = "Technology",
                     MarketCap = 2_000_000_000
                },
                new Stock
                {
                     Id = 2,
                     Symbol = "MSFT",
                     CompanyName = "Microsoft Corporation",
                     Purchase = 200.00m,
                     LastDividend = 1.56m,
                     Industry = "Technology",
                     MarketCap = 1_000_000_000
                }
              );
                modelBuilder.Entity<Comment>().HasData(
                    new Comment
                    {
                         Id = 1,
                         Title = "Great Company",
                         Content = "I love this company",
                         CreatedOn = DateTime.Now,
                         StockId = 1
                    },
                    new Comment
                    {
                         Id = 2,
                         Title = "Great Company",
                         Content = "I love this company",
                         CreatedOn = DateTime.Now,
                         StockId = 2
                    }
                );
                List<IdentityRole> roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Id = "1",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = "2",
                        Name = "User",
                        NormalizedName = "USER"
                    }
                };
                    modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }

}