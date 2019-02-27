using photosApp.Controllers;
using photosApp.Interfaces;
using System;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using photosApp.ViewModels;
using System.Collections.Generic;

namespace tests
{
    public class PhotosControllerTest
    {
        IPhotosService _service;
        PhotosController _controller;

        public PhotosControllerTest()
        {
            _service = new PhotosServiceFake();
            _controller = new PhotosController(_service);
        }
        [Fact]
        public void GetOkResultt()
        {
            var result = _controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllItemsCount()
        {
            var result = _controller.Get().Result as OkObjectResult;

            var items = Assert.IsType<List<PhotoAlbumViewModel>>(result.Value);
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void GetProperSecondElement()
        {
            var result = _controller.Get().Result as OkObjectResult;
            var items = result.Value as List<PhotoAlbumViewModel>;
            var secondItem = items[1];
            Assert.Equal("Album name 1", secondItem.AlbumName);
            Assert.Equal(2, secondItem.PhotoId);
            Assert.Equal("Photo Title 2", secondItem.PhotoTitle);
            Assert.Equal("test url 2", secondItem.Url);
            Assert.Equal("thumbnail url 2", secondItem.ThumbnailUrl);
        }

        [Fact]
        public void GetProperFourthElement()
        {
            var result = _controller.Get().Result as OkObjectResult;
            var items = result.Value as List<PhotoAlbumViewModel>;
            var fourthItem = items[3];
            Assert.Equal("Album name 2", fourthItem.AlbumName);
            Assert.Equal(4, fourthItem.PhotoId);
            Assert.Equal("Photo Title 4", fourthItem.PhotoTitle);
            Assert.Equal("test url 4", fourthItem.Url);
            Assert.Equal("thumbnail url 4", fourthItem.ThumbnailUrl);
        }
    }
}
