using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBulbTunes.EFDataService.Models;

namespace TheBulbTunes.EFDataService.Services
{
   public class UserService
    {
        private readonly TheBulbTunesDBContext _context = new TheBulbTunesDBContext();
        private List<User> _users;

        //Create a user
        public string Create(User newUser)
        {
            newUser.UserId = new Guid();
            _context.Users.Add(newUser);
            var response = _context.SaveChanges();

            if(response > 0)
            {
                return "successful insert "+ response + " data";
            }
            else
            {
                return "Unsuccessful insertion";
            }
        }

        //Fetch all Users
        public List<User> FetchAll()
        {
            return _context.Users.ToList();
        }

        public List<User> fetchWithFilter(User userData)
        {
            // Retrieve all available users unfiltered
            _users = FetchAll();

            // if any filter is specified, apply that filter by calling
            if (userData.FirstName != null)
                _users = SearchByFirstName(userData.FirstName, _users);
            if (userData.LastName != null)
                _users = SearchByLastName(userData.LastName, _users);
            if (userData.EmailAddress != null)
                _users = SearchByEmail(userData.EmailAddress, _users);

            return _users;
        }

        private List<User> SearchByFirstName(string searchValue, List<User> users)
        {
            return users.Where(s => s.FirstName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<User> SearchByLastName(string searchValue, List<User> users)
        {
            return users.Where(s => s.LastName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<User> SearchByEmail(string searchValue, List<User> users)
        {
            return users.Where(s => s.EmailAddress.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        //Update User
        public void Update(Guid id, User userWithNewInfo)
        {
            //Check if a song with the supplied texts exist
            User userToUpdate = FetchAll()
                .Where(u => u.UserId == id)
                .FirstOrDefault();
            if (userToUpdate == null)
            {
                Console.WriteLine($"Invalid operation! No match was found for the id you supplied.");
                return;
            }

            // A matching user was found. Perform the requested update
            if (userWithNewInfo.FirstName != null) userToUpdate.FirstName = userWithNewInfo.FirstName;
            if (userWithNewInfo.LastName != null) userToUpdate.LastName = userWithNewInfo.LastName;
            if (userWithNewInfo.EmailAddress != null) userToUpdate.EmailAddress = userWithNewInfo.EmailAddress;
            _context.SaveChanges();
        }





    }
}
