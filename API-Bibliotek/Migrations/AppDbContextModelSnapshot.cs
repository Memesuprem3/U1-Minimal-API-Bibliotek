﻿// <auto-generated />
using API_Bibliotek.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Bibliotek.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Bibliotek.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Description")
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("Genre")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("Year")
                        .HasMaxLength(75)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Tony Hawk",
                            Description = "Wanna kick it, but cant kick IT, learn to pop shove, kick flip and more rad stuff!",
                            Genre = "Lifestyle",
                            IsAvailable = true,
                            Title = "Skate",
                            Year = 1995
                        },
                        new
                        {
                            Id = 2,
                            Author = "Danny McBride",
                            Description = "What really happaend durring the filming?? I'll tell you, fuck all",
                            Genre = "Facts",
                            IsAvailable = false,
                            Title = "Thunders Tropic",
                            Year = 2009
                        },
                        new
                        {
                            Id = 3,
                            Author = "Dennis Raynolds",
                            Description = "How did he go from Nightman to The Golden God? Read and find out!!",
                            Genre = "biography",
                            IsAvailable = true,
                            Title = "The Golden God",
                            Year = 2016
                        },
                        new
                        {
                            Id = 4,
                            Author = "MacGuffin",
                            Description = "DO NOT READ",
                            Genre = "Religon",
                            IsAvailable = true,
                            Title = "The Elder Scrolls",
                            Year = 1123
                        },
                        new
                        {
                            Id = 5,
                            Author = "Roboute Guilliman",
                            Description = "They shall be pure of heart and strong of body, untainted by doubt and unsullied by self-aggrandisement.",
                            Genre = "Religon",
                            IsAvailable = true,
                            Title = "Codex Astartes",
                            Year = 40403
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
