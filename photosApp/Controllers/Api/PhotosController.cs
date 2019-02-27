using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using photosApp.Interfaces;

namespace photosApp.Controllers
{
    public class PhotosController : BaseApiController
    {
        private readonly IPhotosService _photosService;
        public PhotosController(IPhotosService photosService)
        {
            _photosService = photosService;
        }
        // GET: api/photos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albumPhotos = await _photosService.GetPhotoAlbums();
            return Ok(albumPhotos);
        }
  
    }
}
