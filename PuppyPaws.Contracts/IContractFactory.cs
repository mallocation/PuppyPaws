using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.Contracts
{
    /// <summary>
    /// A factory interface for constructing all contract implementations.
    /// </summary>
    public interface IContractFactory
    {
        IInstagramPhotoService BuildInstagramPhotoService();

        // *** Add other contract builder methods below. ***
        // For example, the app may also consume a Flickr service for retrieving photos.

        // IFlickrPhotoService BuildFlickrPhotoService();
    }
}
