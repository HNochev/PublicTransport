﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublicTransport.Infrastructure.Data;

#nullable disable

namespace PublicTransport.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220428091648_AddPreviousCardToWebsiteUser")]
    partial class AddPreviousCardToWebsiteUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DaysActive")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsernameInWebsite")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Download", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("FilePDF")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Downloads");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Line", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.LineStop", b =>
                {
                    b.Property<Guid>("LineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Orderer")
                        .HasColumnType("int");

                    b.HasKey("LineId", "StopId");

                    b.HasIndex("StopId");

                    b.ToTable("LineStops");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.NewsComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("UserId");

                    b.ToTable("NewsComments");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminMessage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DateOfPicture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAuthor")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PhotoFile")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("PhotoStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserMessage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PhotoStatusId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.PhotoComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("PhotoComments");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.PhotoStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassColor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PhotoStatuses");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.StartingHour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartHour")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.ToTable("StartingHours");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Stop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MinutesFromPreviousStop")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArriveInTown")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FactoryNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("InUseSince")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InUseTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("InventoryNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("ScrappedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VehicleConditionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YearBuilt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleConditionId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.VehicleCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassColor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConditionDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleConditions");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.WebsiteUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ActiveCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CardActiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CardActiveTo")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("CardIsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("CardIsRequested")
                        .HasColumnType("bit");

                    b.Property<string>("CardOwnerFirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CardOwnerLastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CardRequestedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PreviousActiveCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PreviousCardActiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PreviousCardActiveTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("PreviousCardOwnerFirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PreviousCardOwnerLastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("RequestedCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ActiveCardId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PreviousActiveCardId");

                    b.HasIndex("RequestedCardId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Contact", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Download", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Line", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.LineStop", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Line", "Line")
                        .WithMany("LineStops")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Stop", "Stop")
                        .WithMany("LineStops")
                        .HasForeignKey("StopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");

                    b.Navigation("Stop");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.News", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.NewsComment", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.News", "News")
                        .WithMany("NewsComments")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", "User")
                        .WithMany("NewsComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Photo", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.PhotoStatus", "PhotoStatus")
                        .WithMany("Photos")
                        .HasForeignKey("PhotoStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Photos")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhotoStatus");

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.PhotoComment", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Photo", "Photo")
                        .WithMany("PhotoComments")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.WebsiteUser", "User")
                        .WithMany("PhotoComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.StartingHour", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Line", "Line")
                        .WithMany("StartingHours")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.VehicleCondition", "VehicleCondition")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleConditionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("VehicleCondition");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.WebsiteUser", b =>
                {
                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Card", "ActiveCard")
                        .WithMany()
                        .HasForeignKey("ActiveCardId");

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Card", "PreviousActiveCard")
                        .WithMany()
                        .HasForeignKey("PreviousActiveCardId");

                    b.HasOne("PublicTransport.Infrastructure.Data.Models.Card", "RequestedCard")
                        .WithMany()
                        .HasForeignKey("RequestedCardId");

                    b.Navigation("ActiveCard");

                    b.Navigation("PreviousActiveCard");

                    b.Navigation("RequestedCard");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Line", b =>
                {
                    b.Navigation("LineStops");

                    b.Navigation("StartingHours");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.News", b =>
                {
                    b.Navigation("NewsComments");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Photo", b =>
                {
                    b.Navigation("PhotoComments");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.PhotoStatus", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Stop", b =>
                {
                    b.Navigation("LineStops");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.VehicleCondition", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("PublicTransport.Infrastructure.Data.Models.WebsiteUser", b =>
                {
                    b.Navigation("NewsComments");

                    b.Navigation("PhotoComments");

                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}