using PuppyPaws.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.Contracts
{
    public interface IInstagramPhotoService
    {
        Task<Media[]> FindRecentMediaByTag(string tag, int count, InstagramContext context);
        
    }
}
