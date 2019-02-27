using photosApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosApp.Interfaces
{
    public interface IPhotosService
    {
        Task<IEnumerable<PhotoAlbumViewModel>> GetPhotoAlbums();
    }
}
