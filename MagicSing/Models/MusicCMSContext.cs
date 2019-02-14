using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MagicSing.Models
{
    public class MusicCMSContext : DbContext
    {
        public MusicCMSContext()
        {

        }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Music> Musics { get; set; }
    }
}