using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class Exceptions
    {
        public static readonly Exception lowerWindowsversion = new Exception("This version of Windows is incompatible. use Windows NT 3.1 or higher.");

        public static Exception UndefinedVersion()
        {
            return new Exception("Incompatible platform. Only available in Windows NT 3.1 or highers, Unix and MacOSX.");
        }

        public static Exception undefinedversion(PlatformOSID args)
        {

            return new Exception($"Incompatible platform. Only available in {args}.");
        }
    }
}
