using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBulbTunes.EFDataService.Models;

namespace TheBulbTunes.EFDataService.Services
{
    public class FavouriteServices
    {
        private readonly TheBulbTunesDBContext _context = new TheBulbTunesDBContext();
        private List<Favorite> _favorites;

        //Create a favorite
        public void Create(Guid songId, Guid userId)
        {
            // Retrieve the objects associated with the songId and userid supplied as parameters
            Song song = _context.Songs.Find(songId);
            User user = _context.Users.Find(userId);

            Favorite newFavorite = new Favorite()
            {
                Id = new Guid(),
                DateAdded = DateTime.Now,
                SelectedSong = song,
                AddedBy = user
                // The properties below need not be assigned directly because their associated navigation objects have been assigned above.
                // SelectedSongId = songId,
                // AddedById = userId,
            };
            _context.Favorites.Add(newFavorite);
            _context.SaveChanges();
        }

        // Fetch All favorites.
        public List<Favorite> FetchAll()
        {
            return _context.Favorites
                .Include(f => f.AddedBy)
                .Include(f => f.SelectedSong)
                .ToList();
        }

        // Fetch favourites filter by: song, user and/or artist.
        public List<Favorite> FetchWithFilter(string titleFilter = null, string userFilter = null, string artistFilter = null)
        {
            // Retrieves all available favorites unfiltered
            _favorites = FetchAll();

            // Apply the filter by calling its search method
            if (titleFilter != null)
                _favorites = SearchByTitle(titleFilter, _favorites);
            if (userFilter != null)
                _favorites = SearchByUser(userFilter, _favorites);
            if (artistFilter != null)
                _favorites = SearchByArtist(artistFilter, _favorites);

            return _favorites;
        }

        // private helper methods to simplify searching with various parameters
        private List<Favorite> SearchByTitle(string searchValue, List<Favorite> favorites)
        {
            return favorites.Where(f => f.SelectedSong.Title.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<Favorite> SearchByArtist(string searchValue, List<Favorite> favorites)
        {
            return favorites.Where(f => f.SelectedSong.Artist.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<Favorite> SearchByUser(string searchValue, List<Favorite> favorites)
        {
            return favorites
                .Where(f =>
                f.AddedBy.FirstName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                f.AddedBy.LastName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        //Update favorite
        public void Update(Guid favoriteToUpdateId, string newFavUserId = null, string newFavSongId = null)
        {
            // Check if the supplied id matches
            Favorite favoriteToUpdate = FetchAll().Where(f => f.Id == favoriteToUpdateId).FirstOrDefault();

            if (favoriteToUpdate == null)
            {
                Console.WriteLine("Invalid operation! No match was found for the id you supplied.");
                return;
            }

            if (newFavSongId != null)
            {
                favoriteToUpdate.SelectedSongId = new Guid(newFavSongId);
            }

            if (newFavUserId != null)
            {
                favoriteToUpdate.AddedById = new Guid(newFavUserId);
            }
            _context.Update(favoriteToUpdate);
            _context.SaveChanges();
        }

        //Delete a favorite
        public void Delete(Guid id)
        {
            //Check if a favourite with the supplied id exists
            Favorite favouriteToDelete = FetchAll()
                .Where(f => f.Id == id)
                .FirstOrDefault();

            // The above linees can be shortened by just calling the Find() method as below.
            // favouriteToDelete  = _context.Favorites.Find(id);

            if (favouriteToDelete == null)
            {
                Console.WriteLine($"Invalid operation! No match was found for the id you supplied.");
                return;
            }
            
            // A matching was found. perform the requested deletion
             _context.Favorites.Remove(favouriteToDelete);
            _context.SaveChanges();
        }

    }
}
