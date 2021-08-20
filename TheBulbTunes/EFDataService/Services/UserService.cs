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
        private List<Song> _songs;

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

        public List<User> FetchAll()
        {
            return _context.Users.ToList();
        }



    }
}
