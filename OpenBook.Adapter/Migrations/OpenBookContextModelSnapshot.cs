﻿//// <auto-generated />
//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using OpenBook.Adapter;

//#nullable disable

//namespace OpenBook.Adapter.Migrations
//{
//    [DbContext(typeof(OpenBookContext))]
//    partial class OpenBookContextModelSnapshot : ModelSnapshot
//    {
//        protected override void BuildModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

//            modelBuilder.Entity("OpenBook.Domain.Entity.Basket", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("UserId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("UserId");

//                    b.ToTable("Baskets");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Book", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Author")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<byte[]>("Cover")
//                        .HasColumnType("BLOB");

//                    b.Property<int?>("CycleId")
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Description")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<bool>("IsPublished")
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<int?>("UserId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("CycleId");

//                    b.HasIndex("UserId");

//                    b.ToTable("Books");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.BookBasket", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("BasketId")
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("BookId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("BasketId");

//                    b.HasIndex("BookId");

//                    b.ToTable("BookBaskets");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.BookGenre", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("BookId")
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("GenreId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("BookId");

//                    b.HasIndex("GenreId");

//                    b.ToTable("BookGenres");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Chapter", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("BookId")
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Content")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<bool>("IsPublic")
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<int?>("Number")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("BookId");

//                    b.ToTable("Chapters");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Cycle", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<byte[]>("Cover")
//                        .HasColumnType("BLOB");

//                    b.Property<string>("Description")
//                        .HasColumnType("TEXT");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<int?>("UserId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("UserId");

//                    b.ToTable("Cycles");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.EmailVerif", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Code")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<DateTime>("CreatAt")
//                        .HasColumnType("TEXT");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<bool>("IsAcivate")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.ToTable("EmailVerifs");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Genre", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.HasKey("Id");

//                    b.ToTable("Genres");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Like", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int>("BookId")
//                        .HasColumnType("INTEGER");

//                    b.Property<DateTime>("Date")
//                        .HasColumnType("TEXT");

//                    b.Property<int>("UserId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("BookId");

//                    b.HasIndex("UserId");

//                    b.ToTable("Likes");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Post", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Content")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<DateTime>("CreatedAt")
//                        .HasColumnType("TEXT");

//                    b.Property<int?>("UserId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("UserId");

//                    b.ToTable("Posts");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Review", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("BookId")
//                        .HasColumnType("INTEGER");

//                    b.Property<DateTime>("CreateDate")
//                        .HasColumnType("TEXT");

//                    b.Property<bool>("IsEdited")
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Text")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<int?>("UserId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("BookId");

//                    b.HasIndex("UserId");

//                    b.ToTable("Reviews");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Role", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.HasKey("Id");

//                    b.ToTable("Roles");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Subscribe", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("AuthId")
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("AuthorId")
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("SubId")
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("SubscriberId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("AuthId");

//                    b.HasIndex("SubId");

//                    b.ToTable("Subscribes");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.User", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<bool>("IsVerified")
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("Password")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<int?>("RoleId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("Id");

//                    b.HasIndex("RoleId");

//                    b.ToTable("Users");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Basket", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.User", "User")
//                        .WithMany()
//                        .HasForeignKey("UserId");

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Book", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.Cycle", "Cycle")
//                        .WithMany()
//                        .HasForeignKey("CycleId");

//                    b.HasOne("OpenBook.Domain.Entity.User", "User")
//                        .WithMany()
//                        .HasForeignKey("UserId");

//                    b.Navigation("Cycle");

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.BookBasket", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.Basket", "Basket")
//                        .WithMany()
//                        .HasForeignKey("BasketId");

//                    b.HasOne("OpenBook.Domain.Entity.Book", "Book")
//                        .WithMany()
//                        .HasForeignKey("BookId");

//                    b.Navigation("Basket");

//                    b.Navigation("Book");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.BookGenre", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.Book", "Book")
//                        .WithMany()
//                        .HasForeignKey("BookId");

//                    b.HasOne("OpenBook.Domain.Entity.Genre", "Genre")
//                        .WithMany()
//                        .HasForeignKey("GenreId");

//                    b.Navigation("Book");

//                    b.Navigation("Genre");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Chapter", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.Book", "Book")
//                        .WithMany()
//                        .HasForeignKey("BookId");

//                    b.Navigation("Book");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Cycle", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.User", "User")
//                        .WithMany()
//                        .HasForeignKey("UserId");

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Like", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.Book", "Book")
//                        .WithMany()
//                        .HasForeignKey("BookId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("OpenBook.Domain.Entity.User", "User")
//                        .WithMany()
//                        .HasForeignKey("UserId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.Navigation("Book");

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Post", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.User", "User")
//                        .WithMany()
//                        .HasForeignKey("UserId");

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Review", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.Book", "Book")
//                        .WithMany()
//                        .HasForeignKey("BookId");

//                    b.HasOne("OpenBook.Domain.Entity.User", "User")
//                        .WithMany()
//                        .HasForeignKey("UserId");

//                    b.Navigation("Book");

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.Subscribe", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.User", "Auth")
//                        .WithMany()
//                        .HasForeignKey("AuthId");

//                    b.HasOne("OpenBook.Domain.Entity.User", "Sub")
//                        .WithMany()
//                        .HasForeignKey("SubId");

//                    b.Navigation("Auth");

//                    b.Navigation("Sub");
//                });

//            modelBuilder.Entity("OpenBook.Domain.Entity.User", b =>
//                {
//                    b.HasOne("OpenBook.Domain.Entity.Role", "Role")
//                        .WithMany()
//                        .HasForeignKey("RoleId");

//                    b.Navigation("Role");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}