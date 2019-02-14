using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MagicSing.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistID { get; set; }
  
        [Required, StringLength(255), Display(Name = "Playlist")]
        public string PlaylistName{ get; set; }
          
        public virtual ICollection<Music> Musics { get; set; }
    }
}