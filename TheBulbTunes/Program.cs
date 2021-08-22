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
            //UserService userService = new UserService();
            FavouriteServices favouriteServices = new FavouriteServices();


            // Fetch all songs before performing action
            List<Favorite> availablefavorites = favouriteServices.FetchAll();
            printer(availablefavorites);


            //favouriteServices.Create(new Guid("42d2b7f5-e1be-4640-b8c7-08d962e9146b"), new Guid("286373f5-4ab8-45b6-57d5-08d963ec8a2e"));
            //favouriteServices.Create(new Guid("ac717d4a-0e53-4608-b8c5-08d962e9146b"), new Guid("286373f5-4ab8-45b6-57d5-08d963ec8a2e"));

            //favouriteServices.Update(new Guid("d3287702-b1d2-4b19-425e-08d965acaecc"),null , "507f2b0c-2f83-438a-b8c4-08d962e9146b");

            //favouriteServices.Delete(new Guid("d3287702-b1d2-4b19-425e-08d965acaecc"));

            ////var filteredUser = userService.fetchWithFilter(newUser1);
            ////var filteredUser2 = userService.fetchWithFilter(newUser2);


            //// Set the id of user to be updated
            //Guid idOfUserToUpdate1 = new Guid("05e4b13c-1fe2-4ef6-aa68-08d96238e7ab"); //Non - existing id
            //Guid idOfUserToUpdate2 = new Guid("62023d27-a4fe-4728-d1fa-08d963ecb097"); //existing id

            //User userWithNewInfo = new User(){ FirstName = "Tinuade"};

            //// Call the update mehod to make deseired update
            ////userService.Update(idOfUserToUpdate1, userWithNewInfo);
            ////userService.Update(idOfUserToUpdate2, userWithNewInfo);

            //Guid idOfUserToDelete1 = new Guid("62023d27-a4fe-4728-d1fa-08d963ecb097"); //existing id
            //userService.Delete(idOfUserToDelete1);




            // Fetch all favorites after performing action
            availablefavorites = favouriteServices.FetchAll();
            printer(availablefavorites);            
        }

        public static void printer(List<Favorite> availablefavorites)
        {
            Console.WriteLine("\n\nCURRENTLY AVAILABLE favorites:\n");
            Console.Write("id\t\t Added By \t\t Song Title \t\t Date Added");
            foreach (Favorite favorite in availablefavorites)
            {
                Console.WriteLine();
                Console.Write($"{favorite.Id}\t{favorite.AddedBy.FirstName} {favorite.AddedBy.LastName}\t{favorite.SelectedSong.Title}\t{favorite.DateAdded}");
            }
        }
                
    }
}