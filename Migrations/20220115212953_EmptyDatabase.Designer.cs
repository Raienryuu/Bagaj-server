﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bAPI;

namespace bAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220115212953_EmptyDatabase")]
    partial class EmptyDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("bAPI.Models.BidModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<float>("BidValue")
                        .HasColumnType("real");

                    b.Property<int>("BidderId")
                        .HasColumnType("integer");

                    b.Property<int>("PackageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BidderId");

                    b.HasIndex("PackageId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("bAPI.Models.PackageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<float>("ApproximateDistance")
                        .HasColumnType("real");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Dimensions")
                        .HasColumnType("text");

                    b.Property<string>("EndCity")
                        .HasColumnType("text");

                    b.Property<string>("EndPostCode")
                        .HasColumnType("text");

                    b.Property<string>("EndStreetAddress")
                        .HasColumnType("text");

                    b.Property<string>("EndVoivodeship")
                        .HasColumnType("text");

                    b.Property<float>("LowestBid")
                        .HasColumnType("real");

                    b.Property<int>("LowestBidId")
                        .HasColumnType("integer");

                    b.Property<int>("OfferState")
                        .HasColumnType("integer");

                    b.Property<bool>("SenderHelp")
                        .HasColumnType("boolean");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("StartCity")
                        .HasColumnType("text");

                    b.Property<string>("StartPostCode")
                        .HasColumnType("text");

                    b.Property<string>("StartStreetAddress")
                        .HasColumnType("text");

                    b.Property<string>("StartVoivodeship")
                        .HasColumnType("text");

                    b.Property<int>("TransporterId")
                        .HasColumnType("integer");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("bAPI.Models.RatingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("PackageId")
                        .HasColumnType("integer");

                    b.Property<float>("RatedBySender")
                        .HasColumnType("real");

                    b.Property<float>("RatedByTransporter")
                        .HasColumnType("real");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<int>("TransporterId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("SenderId");

                    b.HasIndex("TransporterId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("bAPI.Models.SessionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("bAPI.Models.UserDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("Name", "Lastname");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactInfo = "berries11@gmail.com",
                            Lastname = "Berry",
                            Login = "user1",
                            Name = "Tom",
                            Password = "OYQ+xy+ILeo9tXmeT+/vNhDxnlNAl5KWXp25yeIE70/dWqjfSyRo/Xrtkoi8HEOm9WrTDXYhdxONT5CLOmJLcg==",
                            Rating = 0f
                        },
                        new
                        {
                            Id = 2,
                            ContactInfo = "mousepaul@yahoo.com",
                            Lastname = "Jerry",
                            Login = "user2",
                            Name = "Paul",
                            Password = "R7WDCLmMmLg71VR+F1S4CNCc2OCOhuxxs5RHcxOO5gtInrMrVTwyI68SGNk1eZleRQckSe7oKsSgyNi26XQ0VA==",
                            Rating = 0f
                        });
                });

            modelBuilder.Entity("bAPI.Models.BidModel", b =>
                {
                    b.HasOne("bAPI.Models.UserDataModel", "Bidder")
                        .WithMany()
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bAPI.Models.PackageModel", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bidder");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("bAPI.Models.PackageModel", b =>
                {
                    b.HasOne("bAPI.Models.UserDataModel", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("bAPI.Models.RatingModel", b =>
                {
                    b.HasOne("bAPI.Models.PackageModel", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bAPI.Models.UserDataModel", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bAPI.Models.UserDataModel", "Transporter")
                        .WithMany()
                        .HasForeignKey("TransporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Sender");

                    b.Navigation("Transporter");
                });

            modelBuilder.Entity("bAPI.Models.SessionModel", b =>
                {
                    b.HasOne("bAPI.Models.UserDataModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
