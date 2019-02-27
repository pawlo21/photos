using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosApp.ViewModels
{
    public class PhotoAlbumViewModel
    {
        public int PhotoId { get; set; }
        public string PhotoTitle { get; set; }
        public string AlbumName { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
