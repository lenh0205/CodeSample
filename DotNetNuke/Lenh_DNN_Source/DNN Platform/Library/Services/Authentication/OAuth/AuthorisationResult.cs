﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Services.Authentication.OAuth
{
    public enum AuthorisationResult
    {
        Denied = 0,
        Authorized = 1,
        RequestingCode = 2,
    }
}
