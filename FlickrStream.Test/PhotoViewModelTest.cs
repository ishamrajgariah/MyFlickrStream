using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flickr.Models.Models;
using FlickrStream.Infrastructure.Interfaces;
using FlickrStream.Logger.Interfaces;
using FlickrStream.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlickrStream.Test
{
    [TestClass]
    public class PhotoViewModelTest
    {
        private Mock<ILogger> logger;
        private Mock<IPhotoStreamBridge> photoStreamAdapter;
        private Mock<IDispatcher> dispatcher;

        [TestInitialize]
        public void Initialize()
        {
            logger = new Mock<ILogger>();
            photoStreamAdapter = new Mock<IPhotoStreamBridge>();
            dispatcher = new Mock<IDispatcher>();
        }

        [TestMethod]
        public void LoadPhotos_AllTagsEmpty_ReturnsValidResponse()
        {
            //Arrange
            photoStreamAdapter.Setup(p => p.GetPhotoStream()).ReturnsAsync(new List<Item>()
                {new Item()});
            dispatcher.Setup(d => d.Dispatch(It.IsAny<Action>()));
            PhotoViewModel viewModel = new PhotoViewModel(photoStreamAdapter.Object, dispatcher.Object, logger.Object);
            viewModel.Tags = string.Empty;
            viewModel.IsTagModeAllEnabled = true;
            viewModel.SelectedLanguage = viewModel.LanguageList.FirstOrDefault();
            viewModel.UserIDsToSearch = string.Empty;

            //Act
            viewModel.SearchCommand.Execute(null);

            //Assert
           dispatcher.Verify(d => d.Dispatch(It.IsAny<Action>()));
        }

        [TestMethod]
        public void ClearSearch_MakesTagsEmpty_PhotoListEmpty()
        {
            //Arrange
            photoStreamAdapter.Setup(p => p.GetPhotoStream()).ReturnsAsync(new List<Item>()
                {new Item()});

            PhotoViewModel viewModel = new PhotoViewModel(photoStreamAdapter.Object, dispatcher.Object, logger.Object);
            viewModel.Tags = "Test";
            viewModel.IsTagModeAllEnabled = true;
            viewModel.SelectedLanguage = viewModel.LanguageList.FirstOrDefault();
            viewModel.UserIDsToSearch = string.Empty;
            viewModel.Photos = new ObservableCollection<Item>(new List<Item>(){new Item()});

            //Act
            viewModel.ClearCommand.Execute(null);

            //Assert
            Assert.AreEqual(0, viewModel.Photos.Count);
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Tags));
        }
    }
}
