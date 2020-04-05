using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    //
    // [Sumary.Platform] - To manage basic actions about the platform in use and its resources.
    class Platform
    {
        // [Class.Os] - Return info about the current operating system like platform identifier and version.
        public static OperatingSystem Os { get; } = Environment.OSVersion;

        // Stores the identifier of the current operating system.
        private static readonly PlatformID pid = Os.Platform;

        bool Windows { get; set; }

        // To return the current operating system name.
        public static string Id
        {
            get
            {
                var plat = pid switch
                {
                    PlatformID.Win32NT => "Windows",
                    PlatformID.Unix => "Unix",
                    PlatformID.MacOSX => "Mac",
                    // Default return a exception.
                    _ => throw Exceptions.UndefinedVersion(),
                };
                return plat;
            }
        }

        // Methods to check operating system parameters
        #region SOs Checkers
        public static bool WinNT
        {
            get
            {
                if (pid == PlatformID.Win32NT)
                    return true;
                else if (pid == PlatformID.Win32S || pid == PlatformID.Win32Windows || pid == PlatformID.WinCE)
                    throw Exceptions.lowerWindowsversion;
                else
                    return false;
            }
        }

        public static bool Unix
        {
            get
            {
                if (pid == PlatformID.Unix)
                    return true;
                else
                    throw Exceptions.undefinedversion(PlatformOSID.Unix);
            }
        }

        public static bool MacOSX()
        {
            if (pid == PlatformID.MacOSX)
                return true;
            else
                throw Exceptions.undefinedversion(PlatformOSID.MacOSX);
        }
        #endregion
    }
}
