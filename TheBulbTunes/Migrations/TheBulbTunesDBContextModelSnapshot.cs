﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheBulbTunes.EFDataService;

namespace TheBulbTunes.Migrations
{
    [DbContext(typeof(TheBulbTunesDBContext))]
    partial class TheBulbTunesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheBulbTunes.EFDataService.Models.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SelectedSongId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("SelectedSongId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("TheBulbTunes.EFDataService.Models.Song", b =>
                {
                    b.Property<Guid>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Featuring")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SongId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("TheBulbTunes.EFDataService.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheBulbTunes.EFDataService.Models.Favorite", b =>
                {
                    b.HasOne("TheBulbTunes.EFDataService.Models.User", "AddedBy")
                        .WithMany("FavoritesList")
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheBulbTunes.EFDataService.Models.Song", "SelectedSong")
                        .WithMany("FavoritesList")
                        .HasForeignKey("SelectedSongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedBy");

                    b.Navigation("SelectedSong");
                });

            modelBuilder.Entity("TheBulbTunes.EFDataService.Models.Song", b =>
                {
                    b.Navigation("FavoritesList");
                });

            modelBuilder.Entity("TheBulbTunes.EFDataService.Models.User", b =>
                {
                    b.Navigation("FavoritesList");
                });
#pragma warning restore 612, 618
        }
    }
}
