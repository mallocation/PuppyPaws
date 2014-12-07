using PuppyPaws.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.ClientCommon.PhoneTests
{
    public class MockInstagramPhotoService : IInstagramPhotoService
    {
        public Func<string, int, DataContracts.InstagramContext, DataContracts.Media[]> MockFindRecentMediaByTag { get; set; }

        public Task<DataContracts.Media[]> FindRecentMediaByTag(string tag, int count, DataContracts.InstagramContext context)
        {
            if (MockFindRecentMediaByTag != null)
            {
                return Task.FromResult<DataContracts.Media[]>(this.MockFindRecentMediaByTag(tag, count, context));
            }

            return Task.FromResult<DataContracts.Media[]>(null);
        }
    }
}
