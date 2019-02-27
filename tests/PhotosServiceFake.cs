using photosApp.Interfaces;
using photosApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    class PhotosServiceFake : IPhotosService
    {
        private readonly List<PhotoAlbumViewModel> _photoAlbums;
        public PhotosServiceFake()
        {
            _photoAlbums = new List<PhotoAlbumViewModel>()
            {
                new PhotoAlbumViewModel(){AlbumName = "Album name 1", PhotoId =1, PhotoTitle = "Photo Title 1", Url = "test url 1", ThumbnailUrl = "thumbnail url 1"},
                new PhotoAlbumViewModel(){AlbumName = "Album name 1", PhotoId =2, PhotoTitle = "Photo Title 2", Url = "test url 2", ThumbnailUrl = "thumbnail url 2"},
                new PhotoAlbumViewModel(){AlbumName = "Album name 2", PhotoId =3, PhotoTitle = "Photo Title 3", Url = "test url 3", ThumbnailUrl = "thumbnail url 3"},
                new PhotoAlbumViewModel(){AlbumName = "Album name 2", PhotoId =4, PhotoTitle = "Photo Title 4", Url = "test url 4", ThumbnailUrl = "thumbnail url 4"},
            };
        }


        public async Task<IEnumerable<PhotoAlbumViewModel>> GetPhotoAlbums()
        {
            return _photoAlbums;
        }
    }
}
