using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Globalization;

namespace IdentityMine.Avalon.Controls
{
    #region Public Enums

    public enum OSVersion
    {
        Windows95,
        Windows98,
        Windows98SecondEdition,
        WindowsMe,
        WindowsNT351,
        WindowsNT40,
        Windows2000,
        WindowsXP,
        WindowsServer2003,
        WindowsVista,
        Unknown
    }

    #endregion

    public static class OSChecker
    {
        #region Dependency Properties Version

        private static readonly DependencyPropertyKey VersionPropertyKey
                = DependencyProperty.RegisterAttachedReadOnly("Version", typeof(OSVersion),
                    typeof(OSChecker), new FrameworkPropertyMetadata(GetOSVersion()));

        public static readonly DependencyProperty VersionProperty
            = VersionPropertyKey.DependencyProperty;

        public static OSVersion GetVersion(DependencyObject d)
        {
            return (OSVersion)d.GetValue(VersionProperty);
        }

        #endregion

        #region Public Methods

        public static OSVersion GetOSVersion()
        {
            OperatingSystem osInfo = Environment.OSVersion;
            OSVersion osVer = OSVersion.Unknown;

            switch (osInfo.Platform)
            {
                case PlatformID.Win32Windows:
                    {
                        switch (osInfo.Version.Minor)
                        {
                            case 0:
                                {
                                    osVer = OSVersion.Windows95;
                                    break;
                                }

                            case 10:
                                {
                                    if (osInfo.Version.Revision.ToString() == "2222A")
                                    {
                                        osVer = OSVersion.Windows98SecondEdition;
                                    }
                                    else
                                    {
                                        osVer = OSVersion.Windows98;
                                    }
                                    break;
                                }

                            case 90:
                                {
                                    osVer = OSVersion.WindowsMe;
                                    break;
                                }
                        }
                        break;
                    }

                case PlatformID.Win32NT:
                    {
                        switch (osInfo.Version.Major)
                        {
                            case 3:
                                {
                                    osVer = OSVersion.WindowsNT351;
                                    break;
                                }

                            case 4:
                                {
                                    osVer = OSVersion.WindowsNT40;
                                    break;
                                }

                            case 5:
                                {
                                    if (osInfo.Version.Minor == 0)
                                    {
                                        osVer = OSVersion.Windows2000;
                                    }
                                    else if (osInfo.Version.Minor == 1)
                                    {
                                        osVer = OSVersion.WindowsXP;
                                    }
                                    else if (osInfo.Version.Minor == 2)
                                    {
                                        osVer = OSVersion.WindowsServer2003;
                                    }
                                    break;
                                }

                            case 6:
                                {
                                    osVer = OSVersion.WindowsVista;
                                    break;
                                }
                        }
                        break;
                    }
            }

            return osVer;
        }

        #endregion
    }
}
