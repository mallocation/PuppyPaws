using PuppyPaws.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.ClientCommon.Factory
{
    public class ContractFactory : IContractFactory
    {
        public IInstagramPhotoService BuildInstagramPhotoService()
        {
            return new PuppyPaws.InstagramApi.InstagramPhotoService();            
        }
    }
}
