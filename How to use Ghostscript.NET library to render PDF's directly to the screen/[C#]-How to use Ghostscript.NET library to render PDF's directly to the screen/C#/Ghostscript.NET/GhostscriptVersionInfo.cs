//
// GhostscriptVersionInfo.cs
// This file is part of Ghostscript.NET library
//
// Author: Josip Habjan (habjan@gmail.com, http://www.linkedin.com/in/habjan) 
// Copyright (c) 2013 Josip Habjan. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Ghostscript.NET
{
    public class GhostscriptVersionInfo
    {

        #region Private local variables

        private Version _version;
        private string _dllPath;
        private string _libPath;
        private GhostscriptLicense _licenseType;

        #endregion

        #region Constructor

        public GhostscriptVersionInfo(Version version, string dllPath, string libPath, GhostscriptLicense licenseType)
        {
            _version = version;
            _dllPath = dllPath;
            _libPath = libPath;
            _licenseType = licenseType;
        }

        #endregion

        #region Version

        public Version Version
        {
            get { return _version; }
        }

        #endregion

        #region DllPath

        public string DllPath
        {
            get { return _dllPath; }
        }

        #endregion

        #region LibPath

        public string LibPath
        {
            get { return _libPath; }
        }

        #endregion

        #region LicenseType

        public GhostscriptLicense LicenseType
        {
            get { return _licenseType; }
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return string.Format("Licence: {0}, Version: {1}, Dll: {2}, Lib: {3}", _licenseType, _version, _dllPath, _libPath);
        }

        #endregion

        #region GetInstalledVersions

        /// <summary>
        /// Gets installed Ghostscript versions list.
        /// </summary>
        /// <returns>A GhostscriptVersionInfo list of the installed Ghostscript versions.</returns>
        public static List<GhostscriptVersionInfo> GetInstalledVersions(GhostscriptLicense licenseType)
        {
            List<GhostscriptLicense> licenses = new List<GhostscriptLicense>();

            if ((licenseType & GhostscriptLicense.AFPL) == GhostscriptLicense.AFPL)
            {
                licenses.Add(GhostscriptLicense.AFPL);
            }

            if ((licenseType & GhostscriptLicense.GPL) == GhostscriptLicense.GPL)
            {
                licenses.Add(GhostscriptLicense.GPL);
            }

            List<GhostscriptVersionInfo> versions = new List<GhostscriptVersionInfo>();

            foreach (GhostscriptLicense license in licenses)
            {
                RegistryKey rkGs = null;

                if (license == GhostscriptLicense.AFPL)
                {
                    rkGs = Registry.LocalMachine.OpenSubKey("SOFTWARE\\AFPL Ghostscript\\");
                }
                else if (license == GhostscriptLicense.GPL)
                {
                    rkGs = Registry.LocalMachine.OpenSubKey("SOFTWARE\\GPL Ghostscript\\");
                }

                if (rkGs != null)
                {
                    string[] subkeys = rkGs.GetSubKeyNames();

                    for (int index = 0; index < subkeys.Length; index++)
                    {
                        string versionKey = subkeys[index];

                        try
                        {
                            RegistryKey rkVer = rkGs.OpenSubKey(versionKey);
                            string gsdll = rkVer.GetValue("GS_DLL", string.Empty) as string;
                            string gslib = rkVer.GetValue("GS_LIB", string.Empty) as string;

                            bool compatibile = false;

                            if (System.Environment.Is64BitProcess && gsdll.Contains("gsdll64.dll"))
                            {
                                compatibile = true;
                            }
                            else if (!System.Environment.Is64BitProcess && gsdll.Contains("gsdll32.dll"))
                            {
                                compatibile = true;
                            }

                            if (compatibile)
                            {
                                versions.Add(new GhostscriptVersionInfo(new Version(versionKey), gsdll, gslib, license));
                            }
                        }
                        catch { }
                    }
                }
            }

            return versions;
        }

        #endregion

        #region GetLastInstalledVersion

        /// <summary>
        /// Gets lastest installed Ghostscript version.
        /// </summary>
        /// <param name="licenseType">L</param>
        /// <param name="licensePriority">If there are a same verio</param>
        /// <returns>GhostscriptVersionInfo object of the last installed Ghostscript version based on priority license.</returns>
        public static GhostscriptVersionInfo GetLastInstalledVersion(GhostscriptLicense licenseType, GhostscriptLicense licensePriority)
        {
            List<GhostscriptVersionInfo> gsVerList = GetInstalledVersions(licenseType);

            int versionsCount = gsVerList.Count;

            if (versionsCount == 1)
            {
                return gsVerList[0];
            }
            else if (versionsCount > 1)
            {
                GhostscriptVersionInfo lastGsVer = gsVerList[0];

                for (int index = 1; index < versionsCount; index++)
                {
                    GhostscriptVersionInfo gs = gsVerList[index];
                    if (gs.Version > lastGsVer.Version)
                    {
                        if (gs.LicenseType == licensePriority)
                        {
                            lastGsVer = gsVerList[index];
                        }
                    }
                }

                return lastGsVer;
            }

            return null;
        }

        #endregion

        #region IsGhostscriptInstalled

        /// <summary>
        /// Gets if Ghostscript is installed on the execution machine.
        /// </summary>
        public static bool IsGhostscriptInstalled
        {
            get
            {
                return GetInstalledVersions(GhostscriptLicense.GPL | GhostscriptLicense.AFPL).Count > 0;
            }
        }

        #endregion

    }
}
