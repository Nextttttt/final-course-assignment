﻿// <auto-generated />
using System;
using FinalCourseAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalCourseAssignment.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalCourseAssignment.Data.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DiscussionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserCreaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("UserCreaterId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("FinalCourseAssignment.Data.Entities.Discussion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiscussionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatorId");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("FinalCourseAssignment.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FinalCourseAssignment.Data.Comment", b =>
                {
                    b.HasOne("FinalCourseAssignment.Data.Entities.Discussion", "Discussion")
                        .WithMany("Comments")
                        .HasForeignKey("DiscussionId");

                    b.HasOne("FinalCourseAssignment.Data.User", "UserCreater")
                        .WithMany("Comments")
                        .HasForeignKey("UserCreaterId");

                    b.Navigation("Discussion");

                    b.Navigation("UserCreater");
                });

            modelBuilder.Entity("FinalCourseAssignment.Data.Entities.Discussion", b =>
                {
                    b.HasOne("FinalCourseAssignment.Data.User", "UserCreator")
                        .WithMany("Discussions")
                        .HasForeignKey("UserCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCreator");
                });

            modelBuilder.Entity("FinalCourseAssignment.Data.Entities.Discussion", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FinalCourseAssignment.Data.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Discussions");
                });
#pragma warning restore 612, 618
        }
    }
}
