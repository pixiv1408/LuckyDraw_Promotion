using Datactx.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Dbcontext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignCode> CampaignCodes { get; set; }
        public DbSet<CampaignCodeGift> CampaignCodeGifts { get; set; }
        public DbSet<CampGift> CampGifts { get; set; }
        public DbSet<Charset> Charsets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ProgramSize> ProgramSizes { get; set; }
        public DbSet<RepeatSchedule> RepeatSchedules { get; set; }
        public DbSet<Rulesforgift> Rulesforgifts { get; set; }
        public DbSet<ScannedOrSpin> ScannedOrSpins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Winner> Winners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cấu hình thuộc tính của table
            modelBuilder
                .Entity<User>()
                .HasIndex(s => s.userEmail)
                .IsUnique();
            modelBuilder
                .Entity<User>()
                .Property(s => s.userEmail)
                .HasColumnType("varchar(50)");
            modelBuilder
                .Entity<User>()
                .Property(s => s.userPassword)
                .HasColumnType("varchar(50)");
            //
            modelBuilder
                .Entity<Customer>()
                .Property(s => s.cusName)
                .HasColumnType("nvarchar(50)");
            modelBuilder
                .Entity<Customer>()
                .HasIndex(s => s.cusPhone)
                .IsUnique();
            modelBuilder
                .Entity<Customer>()
                .Property(s => s.cusPhone)
                .HasColumnType("nvarchar(20)");
            modelBuilder
                .Entity<Customer>()
                .Property(s => s.cusAddress)
                .HasColumnType("nvarchar(200)");
            modelBuilder
                .Entity<Customer>()
                .Property(s => s.cusDoB)
                .HasColumnType("date");
            //
            modelBuilder
                .Entity<Campaign>()
                .HasIndex(s => s.camName)
                .IsUnique();
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.camName)
                .HasColumnType("nvarchar(100)");
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.Description)
                .HasColumnType("ntext");
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.camPrefix)
                .HasColumnType("varchar(50)");
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.camPostfix)
                .HasColumnType("varchar(50)");
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.camStartDate)
                .HasColumnType("date");
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.camEndDate)
                .HasColumnType("date");
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.camStartTime)
                .HasColumnType("time(0)");
            modelBuilder
                .Entity<Campaign>()
                .Property(s => s.camEndTime)
                .HasColumnType("time(0)");
            //
            modelBuilder
                .Entity<Position>()
                .Property(s => s.posName)
                .HasColumnType("nvarchar(100)");
            //
            modelBuilder
                .Entity<Charset>()
                .HasIndex(s => s.charName).IsUnique();
            modelBuilder
                .Entity<Charset>()
                .Property(s => s.charName)
                .HasColumnType("varchar(50)");
            modelBuilder
                .Entity<Charset>()
                .Property(s => s.charValue)
                .HasColumnType("varchar(250)");
            //
           
            modelBuilder
                .Entity<CampaignCodeGift>()
                .Property(s => s.cgcCode).HasColumnType("varchar(50)");
            modelBuilder
                .Entity<CampaignCodeGift>()
                .Property(s => s.cgcCreatedDate).HasColumnType("datetime");
            //
            modelBuilder
                .Entity<ProgramSize>()
                .HasIndex(s => s.psName).IsUnique();
            modelBuilder
                .Entity<ProgramSize>()
                .Property(s => s.psName)
                .HasColumnType("nvarchar(50)");
            modelBuilder
                .Entity<ProgramSize>()
                .Property(s => s.psDescription)
                .HasColumnType("ntext");
            //
            modelBuilder
                .Entity<RepeatSchedule>().
                HasIndex(s => s.repeatName).IsUnique();
            modelBuilder
                .Entity<RepeatSchedule>()
                .Property(s => s.repeatName)
                .HasColumnType("nvarchar(50)");
            //
            modelBuilder
                .Entity<ScannedOrSpin>()
                .Property(s => s.scannedDate)
                .HasColumnType("datetime");
            modelBuilder
                .Entity<ScannedOrSpin>()
                .Property(s => s.spinDate)
                .HasColumnType("datetime");
            //
            modelBuilder
                .Entity<Winner>()
                .Property(s => s.winDate)
                .HasColumnType("datetime");
            modelBuilder
                .Entity<Winner>()
                .Property(s => s.winAddressReceivedGift)
                .HasColumnType("nvarchar(200)");
            //
            modelBuilder
                .Entity<CampaignCode>()
                .Property(s => s.ccCode)
                .HasColumnType("varchar(50)");
            modelBuilder
                .Entity<CampaignCode>()
                .Property(s => s.ccCreatedDate)
                .HasColumnType("datetime");
            //
            modelBuilder.Entity<CampaignCodeGift>()
                .Property(s => s.cgcCode)
                .HasColumnType("varchar(50)");
            modelBuilder
                .Entity<CampaignCodeGift>()               
                .Property(s => s.cgcCreatedDate)
                .HasColumnType("datetime");
            //...

            //Cấu hình Khóa ngoại
            modelBuilder.Entity<Campaign>().HasOne<Charset>(s => s.Charset).WithMany(g => g.Campaigns).HasForeignKey(s => s.charId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Campaign>().HasOne<ProgramSize>(s => s.ProgramSize).WithMany(g => g.Campaigns).HasForeignKey(s => s.psId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CampaignCode>().HasOne<Campaign>(s => s.Campaign).WithMany(g => g.CampaignCodes).HasForeignKey(s => s.camId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CampaignCodeGift>().HasOne<CampGift>(s => s.CampGift).WithMany(g => g.CampaignCodeGifts).HasForeignKey(s => s.cgId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CampGift>().HasOne<Gift>(s => s.Gift).WithMany(g => g.CampGifts).HasForeignKey(s => s.giftId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CampGift>().HasOne<Campaign>(s => s.Campaign).WithMany(g => g.CampGifts).HasForeignKey(s => s.camId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasOne<Position>(s => s.Position).WithMany(g => g.Customers).HasForeignKey(s => s.posId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasOne<User>(s => s.User).WithMany(g => g.Customers).HasForeignKey(s => s.userId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Rulesforgift>().HasOne<CampGift>(s => s.CampGift).WithMany(g => g.Rulesforgifts).HasForeignKey(s => s.cgId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Rulesforgift>().HasOne<RepeatSchedule>(s => s.RepeatSchedule).WithMany(g => g.Rulesforgifts).HasForeignKey(s => s.repeatId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ScannedOrSpin>().HasOne<CampaignCode>(s => s.CampaignCode).WithMany(g => g.ScannedOrSpins).HasForeignKey(s => s.ccId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ScannedOrSpin>().HasOne<Customer>(s => s.Customer).WithMany(g => g.ScannedOrSpins).HasForeignKey(s => s.cusId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Winner>().HasOne<CampaignCodeGift>(s => s.CampaignCodeGift).WithMany(g => g.Winners).HasForeignKey(s => s.cgcId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Winner>().HasOne<Customer>(s => s.Customer).WithMany(g => g.Winners).HasForeignKey(s => s.cusId).OnDelete(DeleteBehavior.Restrict);

            // Đổ dữ liệu vào database 




        }
    }
}
