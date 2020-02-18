using System;
using Microsoft.EntityFrameworkCore;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions options) : base(options){}
        public DbSet<Account> accounts {get; set;}
        public DbSet<GroupRule> grouprules {get; set;}
        public DbSet<Department> departments {get; set;}
        public DbSet<PunchCardLog> punchcardlogs {get; set;}
        public DbSet<WorkTimeRule> worktimerules {get; set;}
        public DbSet<PunchLogWarn> punchlogwarns {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
            modelBuilder.Entity<Account>().HasIndex(b=>b.account).IsUnique();
            modelBuilder.Entity<Department>(entity =>{
                entity.Property(b => b.department).HasColumnType("varchar(255)");
                entity.Property(b => b.position).HasColumnType("varchar(255)");
            });
            modelBuilder.Entity<Department>()
                .HasIndex(b => new{b.department, b.position, b.principalID}).IsUnique();
            
            modelBuilder.Entity<WorkTimeRule>().HasIndex(b=> new{b.startTime, b.endTime}).IsUnique();
            modelBuilder.Entity<PunchLogWarn>().HasIndex(b=>b.punchLogID).IsUnique();
        }
    }
}