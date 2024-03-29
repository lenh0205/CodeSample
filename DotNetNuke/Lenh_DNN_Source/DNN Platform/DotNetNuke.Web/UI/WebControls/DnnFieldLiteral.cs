﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Web.UI.WebControls
{
    public class DnnFieldLiteral : DnnLiteral
    {
        /// <inheritdoc/>
        public override void LocalizeStrings()
        {
            base.LocalizeStrings();
            this.Text = this.Text + Utilities.GetLocalizedString("FieldSuffix.Text");
        }
    }
}
