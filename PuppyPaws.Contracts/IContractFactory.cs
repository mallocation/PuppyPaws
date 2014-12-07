using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.Contracts
{
    public interface IContractFactory
    {
        IInstagramPhotoService BuildInstagramPhotoService();
    }
}
