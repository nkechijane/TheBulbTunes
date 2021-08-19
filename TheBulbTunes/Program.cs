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
            //List<Song> filteredSongs1 = songService.FetchWithFilter("over", "romantic", null, null);
            //List<Song> filteredSongs2 = songService.FetchWithFilter("Ess", "R", "Lagos", "Kid");

            // Set the id of song to be updated
            //Guid idOfSongToUpdate1 = new Guid("05e4b13c-1fe2-4ef6-aa68-08d96238e7ab"); //Non - existing id
            //Guid idOfSongToUpdate2 = new Guid("05e4b13c-1fe2-4ef6-aa68-08d96238e7ac"); //existing id

            // Create a song object containing new info for the update
            //Song songWithNewInfo = new Song()
            //{
            //    Genre = "Rap/Hip-hop",
            //    ReleaseDate = new DateTime(2013, 3, 31)
            //};

            // Call the update mehod to make deseired update
            //songService.Update(idOfSongToUpdate1, songWithNewInfo);        
            //songService.Update(idOfSongToUpdate2, songWithNewInfo);

            //Set the id of song to be deleted
            Guid idOfSongToDelete1 = new Guid("05e4b13c-1fe2-4ef6-aa98-08d96238e7ab"); // Non-existing id
            Guid idOfSongToDelete2 = new Guid("d528422f-54eb-407c-b8c6-08d962e9146b"); // Existing id

            //Call the Delete method to perform desired deletion
            songService.Delete(idOfSongToDelete1);
            songService.Delete(idOfSongToDelete2);

            // Fetch all songs after delete
            availableSongs = songService.FetchAll();
            printer(availableSongs);
            
        }

        public static void printer(List<Song> availableSongs)
        {
            Console.WriteLine("\n\nCURRENTLY AVAILABLE SONGS:\n");
            Console.Write("Title\t\tArtist\t\tAlbum");
            foreach (Song song in availableSongs)
            {
                Console.WriteLine();
                Console.Write($"{song.Title}\t{song.Artist}\t{song.Album}\t{song.Genre}\t{song.ReleaseDate}");
            }
        }
    }
}