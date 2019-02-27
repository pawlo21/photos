﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosApp.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public int AlbumId { get; set; }

    }
}
