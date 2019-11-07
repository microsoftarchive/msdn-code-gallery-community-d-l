//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The test library contains a set of general unit tests.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Tests
{
    #region Using statements
    using System;
    using System.Text.RegularExpressions;
    using System.IO;
    #endregion

    public static class UnitTestUtility
    {
        /// <summary>
        /// The name of the folder that contains all test results.
        /// </summary>
        public const string TestResultsFolderName = "TestResults";

        /// <summary>
        /// The name of the folder that contains all test messages.
        /// </summary>
        public const string TestMessageFolderName = "TestMessages";

        /// <summary>
        /// The regular expression that helps to determine the root location of the project.
        /// </summary>
        private static string testRootExtractionRegex = @"^(?<solroot>.*)" + TestResultsFolderName + "\\\\";

        /// <summary>
        /// Returns a full path to the folder in which the TestResults folder was created by Visual Studio.
        /// </summary>
        /// <param name="testDir">A result from TestContext.TestDir</param>
        /// <returns>The full path to the folder containing the TestResults folder.</returns>
        public static string GetTestRoot(string testDir)
        {
            Regex extrationEx = new Regex(testRootExtractionRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match pathMatch = extrationEx.Match(testDir);

            if (pathMatch.Success)
            {
                return pathMatch.Groups["solroot"].Value;
            }
            else
            {
                return testDir;
            }
        }

        public static string GetTestMessagesFolder(string testRoot)
        {
            return Path.Combine(testRoot, String.Concat(typeof(UnitTestUtility).Namespace, @"\"), TestMessageFolderName);
        }
    }
}
