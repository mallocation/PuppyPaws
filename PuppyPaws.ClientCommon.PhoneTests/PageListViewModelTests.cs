using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PuppyPaws.Contracts;
using PuppyPaws.ClientCommon.PhoneTests.Factory;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using System.Threading;
using GalaSoft.MvvmLight.Threading;
using Windows.UI.Core;
using PuppyPaws.DataContracts;

namespace PuppyPaws.ClientCommon.PhoneTests
{
    [TestClass]
    public class PageListViewModelTests
    {
        private PageListViewModel viewModel;
        private MockContractFactory factory;
        private InstagramContext instagramContext;

        [TestInitialize]
        public void TestInitialize()
        {
            factory = new MockContractFactory();
            viewModel = new PageListViewModel();
            instagramContext = new InstagramContext();
            
            viewModel.Factory = factory;
            viewModel.InstagramContext = instagramContext;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            viewModel = null;
            factory = null;
        }

        [TestMethod]
        public void PageListViewModel_RefreshCommand_ShouldLoadImagesWithTag()
        {
            // Arrange
            string theTag = "puppies";
            int count = 3;
            bool didFetchImages = false;

            var expectedImages = new DataContracts.Media[]
            {
                new DataContracts.Media { StandardResolution = new Uri("http://image.com/image1.png")},
                new DataContracts.Media { StandardResolution = new Uri("http://image.com/image2.png")}
            };

            viewModel.Tag = theTag;
            viewModel.ImageCount = count;

            MockInstagramPhotoService mockPhotoService = new MockInstagramPhotoService();

            mockPhotoService.MockFindRecentMediaByTag = (_tag, _count, _context) =>
            {
                didFetchImages = true;

                Assert.AreEqual(theTag, _tag);
                Assert.AreEqual(count, _count);
                Assert.AreEqual(instagramContext, _context);

                return expectedImages;
            };

            factory.MockInstagramPhotoService = mockPhotoService;

            // Act
            viewModel.RefreshCmd.Execute(null);

            // Assert
            Assert.IsTrue(didFetchImages);
            Assert.IsNotNull(viewModel.ImageList);

            Assert.AreEqual(2, viewModel.ImageList.Count);

            Assert.AreEqual(expectedImages[0], viewModel.ImageList[0]);
            Assert.AreEqual(expectedImages[1], viewModel.ImageList[1]);
        }
    }
}
