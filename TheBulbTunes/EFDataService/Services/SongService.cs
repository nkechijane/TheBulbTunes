﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBulbTunes.EFDataService.Models;

namespace TheBulbTunes.EFDataService.Services
{
    public class SongService
    {
        private readonly TheBulbTunesDBContext _context = new TheBulbTunesDBContext();
        private List<Song> _songs;

        //Create a Song
        public void Create(string title, string artist, string album, string featuring, string genre, DateTime releaseDate)
        {
            Song newSong = new Song()
            {
                SongId = new Guid(),
                Artist = artist,
                Title = title,
                Album = album,
                Featuring = featuring,
                Genre = genre,
                ReleaseDate = releaseDate
            };
            _context.Songs.Add(newSong);
            _context.SaveChanges();
        }

        //Fetch all songs
        public List<Song> FetchAll()
        {
            return _context.Songs.ToList();
        }

        //Fetch songs with filter(Title, Genre, Album, Aryist, ReleaseDate)
        public List<Song> FetchWithFilter(string titleFilter = null, string genreFilter = null, string albumFilter = null, string artistFilter = null)
        {
            // Retrieve all available songs unfiltered
            _songs = FetchAll();

            //If any filter is specified, apply that filter by calling its search method
            if (titleFilter != null)
                _songs = SearchByTitle(titleFilter, _songs);
            if (genreFilter != null)
                _songs = SearchByGenre(genreFilter, _songs);
            if (albumFilter != null)
                _songs = SearchByAlbum(albumFilter, _songs);
            if (artistFilter != null)
                _songs = SearchByArtist(artistFilter, _songs);

            return _songs;
        }


        private List<Song> SearchByTitle(string searchValue, List<Song> songs)
        {
            return songs.Where(s => s.Title.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<Song> SearchByArtist(string searchValue, List<Song> songs)
        {
            return songs.Where(s => s.Artist.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<Song> SearchByAlbum(string searchValue, List<Song> songs)
        {
            return songs.Where(s => s.Album.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<Song> SearchByGenre(string searchValue, List<Song> songs)
        {
            return songs.Where(s => s.Genre.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        //update Song
        public void Update(Guid id, Song songWithNewInfo)
        {
            //Check if a song with the dupplied id exists
            Song songToUpdate = FetchAll()
                .Where(s => s.SongId == id)
                .FirstOrDefault();
            if (songToUpdate == null)
            {
                Console.WriteLine($"Invalid operation! No match was found for the id you supplied.");
                return;
            }
            // A matching song was found. Peform the requested update.

            if (songWithNewInfo.Title != null) songToUpdate.Title = songWithNewInfo.Title;
            if (songWithNewInfo.Artist != null) songToUpdate.Artist = songWithNewInfo.Artist;
            if (songWithNewInfo.Album != null) songToUpdate.Album = songWithNewInfo.Album;
            if (songWithNewInfo.Genre != null) songToUpdate.Genre = songWithNewInfo.Genre;
            if (songWithNewInfo.Featuring != null) songToUpdate.Featuring = songWithNewInfo.Featuring;
            if (songWithNewInfo.ReleaseDate != null) songToUpdate.ReleaseDate = songWithNewInfo.ReleaseDate;
            _context.SaveChanges();
        }

        // Delete Song
        public void Delete(Guid id)
        {
            //Check if a song with the supplied id exists
            Song songToDelete = FetchAll()
                .Where(s => s.SongId == id)
                .FirstOrDefault();

            if (songToDelete == null)
            {
                Console.WriteLine($"Invalid operation! No match found for the id you supplied.");;
                return;
            }

            // A matching song eas found. Perform the requested deletion
            _context.Songs.Remove(songToDelete);
            _context.SaveChanges();
        }
    }
}
