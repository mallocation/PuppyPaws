using PuppyPaws.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.ClientCommon.PhoneTests.Factory
{
    public class MockContractFactory : IContractFactory
    {
        public MockInstagramPhotoService MockInstagramPhotoService { get; set; }

        public IInstagramPhotoService BuildInstagramPhotoService()
        {
            if (MockInstagramPhotoService == null)
            {
                MockInstagramPhotoService = new MockInstagramPhotoService();
            }

            return MockInstagramPhotoService;
        }

    }
}
