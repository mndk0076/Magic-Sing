using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MagicSing.Models
{
    public class Music
    {
        [Key]
        public int MusicID { get; set; }

        public int PlaylistID { get; set; }

        public string Title { get; set; }

        [Required, StringLength(255), Display(Name = "Artist")]
        public string Artist { get; set; }

        [Required, StringLength(255), Display(Name = "Album")]
        public string Album { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Year")]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        [Required, StringLength(255), Display(Name = "URL")]
        public string URL { get; set; }

        public virtual Playlist Playlists { get; set; }
    }
}