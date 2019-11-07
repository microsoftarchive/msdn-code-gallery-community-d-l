// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;

namespace AdventureWorks.UILogic.Models
{
    public class UserChangedEventArgs : EventArgs
    {
        public UserChangedEventArgs() { }

        public UserChangedEventArgs(UserInfo newUserInfo, UserInfo oldUserInfo)
        {
            NewUserInfo = newUserInfo;
            OldUserInfo = oldUserInfo;
        }

        public UserInfo NewUserInfo { get; set; }
        public UserInfo OldUserInfo { get; set; }
    }
}
