using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicSing.Models.ViewModels
{
    public class PlaylistDetails
    {
        public PlaylistDetails()
        {

        }

        public virtual Music Music{ get; set; }

        public IEnumerable<Music> music { get; set; }
    }
}