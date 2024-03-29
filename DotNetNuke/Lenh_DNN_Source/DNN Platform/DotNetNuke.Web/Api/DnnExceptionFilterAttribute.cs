﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Web.Api
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;

    using DotNetNuke.Services.Exceptions;
    using DotNetNuke.Services.Localization;

    /// <summary>Automatically handles WebAPI exceptions.</summary>
    public class DnnExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Gets or sets the message key for exception localization.
        /// ie: "controller_action.Error".
        /// </summary>
        public string MessageKey { get; set; }

        /// <summary>Gets or sets the resource file used to localize the exception messages.</summary>
        public string LocalResourceFile { get; set; }

        /// <inheritdoc/>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var exception = actionExecutedContext.Exception;
                var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;

                var resourceFile = string.IsNullOrEmpty(this.LocalResourceFile)
                    ? Localization.ExceptionsResourceFile
                    : this.LocalResourceFile;

                var key = string.IsNullOrEmpty(this.MessageKey) ? controllerName + "_" + actionName + ".Error" : this.MessageKey;

                HttpStatusCode statusCode;
                if (exception is NotImplementedException)
                {
                    statusCode = HttpStatusCode.NotImplemented;
                }
                else if (exception is TimeoutException)
                {
                    statusCode = HttpStatusCode.RequestTimeout;
                }
                else if (exception is WebApiException)
                {
                    statusCode = HttpStatusCode.BadRequest;
                }
                else if (exception is UnauthorizedAccessException)
                {
                    statusCode = HttpStatusCode.Unauthorized;
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                }

                var response = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    ReasonPhrase = Localization.GetString(key, resourceFile),
                };

                actionExecutedContext.Response = response;
                Exceptions.LogException(exception);
            }
        }
    }
}
