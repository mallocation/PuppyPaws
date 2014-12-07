using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PuppyPaws.DataContracts;

namespace PuppyPaws.InstagramApi.PhoneTests
{
    [TestClass]
    public class InstagramPhotoServiceTests
    {
        private const string ClientId = "043af0fe8cc14dfb8303eee4910c3cae";

        private InstagramContext context;
        private InstagramPhotoService service;

        [TestInitialize]
        public void TestInitialize()
        {
            context = new InstagramContext { ClientId = ClientId };
            service = new InstagramPhotoService();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            context = null;
            service = null;
        }

        [TestMethod]
        public void InstagramPhotoService_FindRecentMediaByTag_ShouldFindDataAndMatchCount()
        {
            // Arrange
            string tag = "nofilter";
            int count = 5;

            // Act
            var result = service.FindRecentMediaByTag(tag, count, context).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(count, result.Length);

            foreach (var item in result)
            {
                Assert.IsNotNull(item.LowResolution);
                Assert.IsNotNull(item.StandardResolution);
                Assert.IsNotNull(item.Thumbnail);                
            }
        }
    }
}
