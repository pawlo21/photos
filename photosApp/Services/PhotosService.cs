using Newtonsoft.Json;
using photosApp.Interfaces;
using photosApp.Models;
using photosApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace photosApp.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IHttpClientFactory _clientFactory;
        public PhotosService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IEnumerable<PhotoAlbumViewModel>> GetPhotoAlbums()
        {
            var photos = await getPhotos();
            var albums = await getAlbums();

            var photoAlbums = mergePhotosWithAlbums(photos, albums);

            return photoAlbums;
        }

        private IEnumerable<PhotoAlbumViewModel> mergePhotosWithAlbums(IEnumerable<Photo> photos, IEnumerable<Album> albums)
        {
            IEnumerable<PhotoAlbumViewModel> photoAlbums =
               from photo in photos
               from album in albums
               where photo.AlbumId == album.Id
               select new PhotoAlbumViewModel()
               {
                   PhotoId = photo.Id,
                   AlbumName = album.Title,
                   PhotoTitle = photo.Title,
                   ThumbnailUrl = photo.ThumbnailUrl,
                   Url = photo.Url
               };
            return photoAlbums;
        }

        private async Task<IEnumerable<Photo>> getPhotos()
        {
            var client = _clientFactory.CreateClient("Source");

            var responseString = await client.GetStringAsync("/photos");
            var photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(responseString);
            return photos;
        }
        private async Task<IEnumerable<Album>> getAlbums()
        {
            var client = _clientFactory.CreateClient("Source");

            var responseString = await client.GetStringAsync("/albums");
            var albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(responseString);
            return albums;
        }
    }
}
