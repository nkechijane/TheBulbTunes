using System;
using System.Collections.Generic;
using TheBulbTunes.EFDataService.Models;
using TheBulbTunes.EFDataService.Services;

namespace TheBulbTunes
{
    class Program 
    {
        static void Main(string[] args)
        {
            SongService songService = new SongService();
                        
            // Fetch all songs before update
            List<Song> availableSongs =  songService.FetchAll();
            printer(availableSongs);

            // Create a number of songs
            //songService.Create("All Over", "Tiwa Savage", "Sugarcane", "", "Afro-pop, Romantic", new DateTime(2017, 5, 22));
            //songService.Create("Nobody's Business", "Rihanna", "Unapologetic", "Chris Brown", "R&B", new DateTime(2012, 1, 1));
            //songService.Create("Get Down On It", "Kool & The Gang", "Something Special", "", "Funk", new DateTime(1981, 11, 24));
            //songService.Create("The Monster", "Eminem", "Marshall Matters", "Rihanna", "R&B/Rap", new DateTime(2013, 1, 1));
            //songService.Create("Essence", "Wizkid", "Made In Lagos", "Tems", "R&B", new DateTime(2020, 10, 30));

            // Fetch songs that meet some search criteria
            List<Song> filteredSongs1 = songService.FetchWithFilter("over", "romantic", null, null);
            List<Song> filteredSongs2 = songService.FetchWithFilter("Ess", "R", "Lagos", "Kid");



            // Fetch all songs after delete
            availableSongs = songService.FetchAll();
            printer(filteredSongs2);
            
        }




        public static void printer(List<Song> availableSongs)
        {
            Console.WriteLine("\n\nCURRENTLY AVAILABLE SONGS:\n");
            Console.Write("Title\t\tArtist\t\tAlbum");
            foreach (Song song in availableSongs)
            {
                Console.WriteLine();
                Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}");
            }
        }
    }
}