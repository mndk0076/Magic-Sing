using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicSing.Models.ViewModels
{
    public class PlaylistItem
    {
        public PlaylistItem()
        {

        }

        public virtual Playlist Playlist{ get; set; }

        public IEnumerable<Playlist> playlists { get; set; }
    }
}