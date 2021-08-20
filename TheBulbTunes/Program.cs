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
            UserService userService = new UserService();

            // Fetch all songs before performing action
            List<User> availableUser = userService.FetchAll();
            printer(availableUser);

            User newUser1 = new User(); //{ FirstName = "Babatope", LastName = "Ajayi", EmailAddress = "ajayi122@gmail.com" };
            //User newUser2 = new User() { FirstName = "Olaniyi", LastName = "Ayomide", EmailAddress = "olaniyi@gmail.com" };

             userService.Create(newUser1);


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
            //Guid idOfSongToDelete1 = new Guid("05e4b13c-1fe2-4ef6-aa98-08d96238e7ab"); // Non-existing id
            //Guid idOfSongToDelete2 = new Guid("d528422f-54eb-407c-b8c6-08d962e9146b"); // Existing id

            ////Call the Delete method to perform desired deletion
            //songService.Delete(idOfSongToDelete1);
            //songService.Delete(idOfSongToDelete2);

            // Fetch all users after performing action
            availableUser = userService.FetchAll();
            printer(availableUser);

        }

        public static void printer(List<User> availableUsers)
        {
            Console.WriteLine("\n\nCURRENTLY AVAILABLE SONGS:\n");
            Console.Write("Title\t\tArtist\t\tAlbum");
            foreach (User user in availableUsers)
            {
                Console.WriteLine();
                Console.Write($"{user.UserId}\t{user.FirstName}\t{user.LastName}\t{user.EmailAddress}");
            }
        }
    }
}