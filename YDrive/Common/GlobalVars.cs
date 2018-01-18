using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace YDrive.Common
{
    class GlobalVars
    {
        StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
        public readonly string currentFolder = "";
        public readonly string downloadsFolder = "";

    }
}
