using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebConferenceApp.Models
{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTags>()
                .HasKey(t => new { t.AccountId, t.TagsId });

            modelBuilder.Entity<AccountTags>()
                .HasOne(at => at.Account)
                .WithMany(a => a.AccountTags)
                .HasForeignKey(at => at.AccountId);

            modelBuilder.Entity<AccountTags>()
                .HasOne(at => at.Tags)
                .WithMany(a => a.AccountTags)
                .HasForeignKey(at => at.TagsId);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Subsrube> Subscrubes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<TypeAccount> TypeAccounts { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<AccountTags> AccountTags { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Billing.Contract> Contracts { get; set; }
        public DbSet<Billing.Payment> Payments { get; set; }
        public DbSet<Billing.PaymentType> PaymentTypes { get; set; }
    }
}
