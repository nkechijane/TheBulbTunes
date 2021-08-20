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
            User newUser2 = new User(); // { FirstName = "Olaniyi", LastName = "Ayomide", EmailAddress = "olaniyi@gmail.com" };

            // Fetch users that meet some search criteria
            newUser1.FirstName = "Babatope";
            newUser2.LastName = "Ayomide";


            var filteredUser = userService.fetchWithFilter(newUser1);
            var filteredUser2 = userService.fetchWithFilter(newUser2);

            // Fetch all users after performing action
            availableUser = userService.FetchAll();
            printer(filteredUser);
            printer(filteredUser2);

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