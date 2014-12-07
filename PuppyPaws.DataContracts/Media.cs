using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.DataContracts
{
    public class Media
    {
        public Uri Thumbnail { get; set; }

        public Uri LowResolution { get; set; }

        public Uri StandardResolution { get; set; }
    }
}
