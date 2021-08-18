using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBulbTunes.EFDataService.Models;

namespace TheBulbTunes.EFDataService
{
    class TheBulbTunesDBContext : DbContext
    {
        string connectionString;

        // Constructor to set up the Connection to the DB
        public TheBulbTunesDBContext()
        {
            connectionString = "Data Source=.; Initial Catalog = TheBulbTunesDB; Integrated Security = True; Pooling = False";
        }

        //DBSet properties, one for each entity/model
        public DbSet<User> Users { get; set;}
        public DbSet<Song> Songs { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        
        //OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);            
        }

                 
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            //set id as primary key for user entity
            builder.HasKey(f => f.Id);

            //A favourite must have one song as Selectedsong
            //Conversely, a song can appear multiple times as a favorite
            builder.HasOne(f => f.SelectedSong)
                .WithMany(s => s.FavoritesList)
                .HasForeignKey(f => f.SelectedSongId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //A Favorite must have one user as AddedBy
            //Conversely, a user can have multiple Favorites
            builder.HasOne(f => f.AddedBy)
                .WithMany(u => u.FavoritesList)
                .HasForeignKey(f => f.AddedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);                
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Set UserId as the primary key for user entity
            builder.HasKey(u => u.UserId);
        }

        public void Configure(EntityTypeBuilder<Song> builder)
        {
            //Set SongId as the primary key for Song entity
            builder.HasKey(s => s.SongId);
        }

    }
}
