using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBulbTunes.EFDataService.Models
{
   public class Favorite
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid SongId { get; set; }

        [Required]
        public Song SelectedSongId { get; set; }

        [Required]
        public Guid AddedById { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        // The following are navigstion properties made possible by the foreign-key relationships
        public virtual User AddedBy { get; set; }
        public virtual Song SelectedSong { get; set; }






    }
}
