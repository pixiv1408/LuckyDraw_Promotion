﻿// <auto-generated />
using System;
using Datactx.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datactx.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Datactx.Models.Campaign", b =>
                {
                    b.Property<int>("camId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("camId"), 1L, 1);

                    b.Property<bool>("ApplyAllCampaign")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<bool>("camAutoUpdate")
                        .HasColumnType("bit");

                    b.Property<int>("camCodeCount")
                        .HasColumnType("int");

                    b.Property<int>("camCodeLength")
                        .HasColumnType("int");

                    b.Property<int>("camCodeUsageLimit")
                        .HasColumnType("int");

                    b.Property<DateTime?>("camEndDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("camEndTime")
                        .HasColumnType("time(0)");

                    b.Property<bool>("camJoinOnlyOne")
                        .HasColumnType("bit");

                    b.Property<string>("camName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("camPostfix")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("camPrefix")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("camStartDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("camStartTime")
                        .HasColumnType("time(0)");

                    b.Property<bool>("camUnlimited")
                        .HasColumnType("bit");

                    b.Property<int>("charId")
                        .HasColumnType("int");

                    b.Property<int>("psId")
                        .HasColumnType("int");

                    b.HasKey("camId");

                    b.HasIndex("camName")
                        .IsUnique();

                    b.HasIndex("charId");

                    b.HasIndex("psId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("Datactx.Models.CampaignCode", b =>
                {
                    b.Property<int>("ccId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ccId"), 1L, 1);

                    b.Property<int>("camId")
                        .HasColumnType("int");

                    b.Property<string>("ccCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ccCreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ccId");

                    b.HasIndex("camId");

                    b.ToTable("CampaignCodes");
                });

            modelBuilder.Entity("Datactx.Models.CampaignCodeGift", b =>
                {
                    b.Property<int>("cgcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cgcId"), 1L, 1);

                    b.Property<int>("cgId")
                        .HasColumnType("int");

                    b.Property<bool>("cgcActive")
                        .HasColumnType("bit");

                    b.Property<string>("cgcCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("cgcCreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("cgcId");

                    b.HasIndex("cgId");

                    b.ToTable("CampaignCodeGifts");
                });

            modelBuilder.Entity("Datactx.Models.CampGift", b =>
                {
                    b.Property<int>("cgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cgId"), 1L, 1);

                    b.Property<int>("camId")
                        .HasColumnType("int");

                    b.Property<int>("cgGiftCodeCount")
                        .HasColumnType("int");

                    b.Property<int>("giftId")
                        .HasColumnType("int");

                    b.HasKey("cgId");

                    b.HasIndex("camId");

                    b.HasIndex("giftId");

                    b.ToTable("CampGifts");
                });

            modelBuilder.Entity("Datactx.Models.Charset", b =>
                {
                    b.Property<int>("charId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("charId"), 1L, 1);

                    b.Property<string>("charName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("charValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("charId");

                    b.ToTable("Charsets");
                });

            modelBuilder.Entity("Datactx.Models.Customer", b =>
                {
                    b.Property<int>("cusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cusId"), 1L, 1);

                    b.Property<string>("cusAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("cusDoB")
                        .HasColumnType("date");

                    b.Property<string>("cusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("cusPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("cusStatus")
                        .HasColumnType("bit");

                    b.Property<int>("posId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("cusId");

                    b.HasIndex("cusPhone")
                        .IsUnique();

                    b.HasIndex("posId");

                    b.HasIndex("userId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Datactx.Models.Gift", b =>
                {
                    b.Property<int>("giftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("giftId"), 1L, 1);

                    b.Property<DateTime>("giftCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("giftDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("giftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("giftId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("Datactx.Models.Position", b =>
                {
                    b.Property<int>("posId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("posId"), 1L, 1);

                    b.Property<string>("posName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("posId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Datactx.Models.ProgramSize", b =>
                {
                    b.Property<int>("psId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("psId"), 1L, 1);

                    b.Property<string>("psDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("psName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("psId");

                    b.ToTable("ProgramSizes");
                });

            modelBuilder.Entity("Datactx.Models.RepeatSchedule", b =>
                {
                    b.Property<int>("repeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("repeatId"), 1L, 1);

                    b.Property<string>("repeatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("repeatId");

                    b.ToTable("RepeatSchedules");
                });

            modelBuilder.Entity("Datactx.Models.Rulesforgift", b =>
                {
                    b.Property<int>("ruleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ruleId"), 1L, 1);

                    b.Property<int>("cgId")
                        .HasColumnType("int");

                    b.Property<int>("repeatId")
                        .HasColumnType("int");

                    b.Property<bool>("ruleAllDay")
                        .HasColumnType("bit");

                    b.Property<TimeSpan?>("ruleEndTime")
                        .HasColumnType("time");

                    b.Property<int>("ruleGiftCount")
                        .HasColumnType("int");

                    b.Property<string>("ruleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ruleProbability")
                        .HasColumnType("int");

                    b.Property<string>("ruleScheduleValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("ruleStartTime")
                        .HasColumnType("time");

                    b.HasKey("ruleId");

                    b.HasIndex("cgId");

                    b.HasIndex("repeatId");

                    b.ToTable("Rulesforgifts");
                });

            modelBuilder.Entity("Datactx.Models.ScannedOrSpin", b =>
                {
                    b.Property<int>("sosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sosId"), 1L, 1);

                    b.Property<int>("ccId")
                        .HasColumnType("int");

                    b.Property<int>("cusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("scannedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("spinDate")
                        .HasColumnType("datetime2");

                    b.HasKey("sosId");

                    b.HasIndex("ccId");

                    b.HasIndex("cusId");

                    b.ToTable("ScannedOrSpins");
                });

            modelBuilder.Entity("Datactx.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"), 1L, 1);

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("userId");

                    b.HasIndex("userEmail")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Datactx.Models.Winner", b =>
                {
                    b.Property<int>("winId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("winId"), 1L, 1);

                    b.Property<DateTime>("WinDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("cgcId")
                        .HasColumnType("int");

                    b.Property<int>("cusId")
                        .HasColumnType("int");

                    b.Property<string>("winAddressReceivedGift")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("winSentGift")
                        .HasColumnType("bit");

                    b.HasKey("winId");

                    b.HasIndex("cgcId");

                    b.HasIndex("cusId");

                    b.ToTable("Winners");
                });

            modelBuilder.Entity("Datactx.Models.Campaign", b =>
                {
                    b.HasOne("Datactx.Models.Charset", "Charset")
                        .WithMany("Campaigns")
                        .HasForeignKey("charId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Datactx.Models.ProgramSize", "ProgramSize")
                        .WithMany("Campaigns")
                        .HasForeignKey("psId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Charset");

                    b.Navigation("ProgramSize");
                });

            modelBuilder.Entity("Datactx.Models.CampaignCode", b =>
                {
                    b.HasOne("Datactx.Models.Campaign", "Campaign")
                        .WithMany("CampaignCodes")
                        .HasForeignKey("camId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("Datactx.Models.CampaignCodeGift", b =>
                {
                    b.HasOne("Datactx.Models.CampGift", "CampGift")
                        .WithMany("CampaignCodeGifts")
                        .HasForeignKey("cgId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CampGift");
                });

            modelBuilder.Entity("Datactx.Models.CampGift", b =>
                {
                    b.HasOne("Datactx.Models.Campaign", "Campaign")
                        .WithMany("CampGifts")
                        .HasForeignKey("camId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Datactx.Models.Gift", "Gift")
                        .WithMany("CampGifts")
                        .HasForeignKey("giftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("Datactx.Models.Customer", b =>
                {
                    b.HasOne("Datactx.Models.Position", "Position")
                        .WithMany("Customers")
                        .HasForeignKey("posId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Datactx.Models.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Position");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Datactx.Models.Rulesforgift", b =>
                {
                    b.HasOne("Datactx.Models.CampGift", "CampGift")
                        .WithMany("Rulesforgifts")
                        .HasForeignKey("cgId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Datactx.Models.RepeatSchedule", "RepeatSchedule")
                        .WithMany("Rulesforgifts")
                        .HasForeignKey("repeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CampGift");

                    b.Navigation("RepeatSchedule");
                });

            modelBuilder.Entity("Datactx.Models.ScannedOrSpin", b =>
                {
                    b.HasOne("Datactx.Models.CampaignCode", "CampaignCode")
                        .WithMany("ScannedOrSpins")
                        .HasForeignKey("ccId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Datactx.Models.Customer", "Customer")
                        .WithMany("ScannedOrSpins")
                        .HasForeignKey("cusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CampaignCode");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Datactx.Models.Winner", b =>
                {
                    b.HasOne("Datactx.Models.CampaignCodeGift", "CampaignCodeGift")
                        .WithMany("Winners")
                        .HasForeignKey("cgcId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Datactx.Models.Customer", "Customer")
                        .WithMany("Winners")
                        .HasForeignKey("cusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CampaignCodeGift");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Datactx.Models.Campaign", b =>
                {
                    b.Navigation("CampGifts");

                    b.Navigation("CampaignCodes");
                });

            modelBuilder.Entity("Datactx.Models.CampaignCode", b =>
                {
                    b.Navigation("ScannedOrSpins");
                });

            modelBuilder.Entity("Datactx.Models.CampaignCodeGift", b =>
                {
                    b.Navigation("Winners");
                });

            modelBuilder.Entity("Datactx.Models.CampGift", b =>
                {
                    b.Navigation("CampaignCodeGifts");

                    b.Navigation("Rulesforgifts");
                });

            modelBuilder.Entity("Datactx.Models.Charset", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("Datactx.Models.Customer", b =>
                {
                    b.Navigation("ScannedOrSpins");

                    b.Navigation("Winners");
                });

            modelBuilder.Entity("Datactx.Models.Gift", b =>
                {
                    b.Navigation("CampGifts");
                });

            modelBuilder.Entity("Datactx.Models.Position", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Datactx.Models.ProgramSize", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("Datactx.Models.RepeatSchedule", b =>
                {
                    b.Navigation("Rulesforgifts");
                });

            modelBuilder.Entity("Datactx.Models.User", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}