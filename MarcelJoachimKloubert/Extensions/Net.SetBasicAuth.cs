/**********************************************************************************************************************
 * Extensions.NET (https://github.com/mkloubert/Extensions.NET)                                                       *
 *                                                                                                                    *
 * Copyright (c) 2015, Marcel Joachim Kloubert <marcel.kloubert@gmx.net>                                              *
 * All rights reserved.                                                                                               *
 *                                                                                                                    *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the   *
 * following conditions are met:                                                                                      *
 *                                                                                                                    *
 * 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the          *
 *    following disclaimer.                                                                                           *
 *                                                                                                                    *
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the       *
 *    following disclaimer in the documentation and/or other materials provided with the distribution.                *
 *                                                                                                                    *
 * 3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote    *
 *    products derived from this software without specific prior written permission.                                  *
 *                                                                                                                    *
 *                                                                                                                    *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, *
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE  *
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, *
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR    *
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,  *
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE   *
 * USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.                                           *
 *                                                                                                                    *
 **********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MarcelJoachimKloubert.Extensions
{
    // SetBasicAuth()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Sets up a <see cref="WebRequest" /> for basic authorization.
        /// </summary>
        /// <param name="request">The underlying request.</param>
        /// <param name="userName">The username.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request" /> is <see langword="null" />.</exception>
        /// <exception cref="FormatException"><paramref name="userName" /> contains invalid char(s).</exception>
        public static void SetBasicAuth(this WebRequest request, string userName, string password)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            userName = userName ?? string.Empty;
            if (userName.Contains(":"))
            {
                throw new FormatException();
            }

            var authInfo = string.Format("{0}:{1}",
                                         userName, password);

            request.Headers["Authorization"] = string.Format("Basic {0}",
                                                             Convert.ToBase64String(Encoding.GetEncoding("ASCII")
                                                                                            .GetBytes(authInfo)));
        }

        /// <summary>
        /// Sets up a <see cref="WebRequest" /> for basic authorization.
        /// </summary>
        /// <param name="request">The underlying request.</param>
        /// <param name="user">The username.</param>
        /// <param name="pwd">The password as ASCII binary data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request" /> is <see langword="null" />.</exception>
        /// <exception cref="FormatException"><paramref name="user" /> contains invalid char(s).</exception>
        public static void SetBasicAuth(this WebRequest request, string user, IEnumerable<byte> pwd)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            byte[] pwdArray = null;
            if (pwd != null)
            {
                pwdArray = pwd as byte[];
                if (pwdArray == null)
                {
                    pwdArray = pwd.ToArray();
                }
            }

            SetBasicAuth(request: request,
                         userName: user,
                         password: pwdArray != null ? Encoding.GetEncoding("ASCII")
                                                              .GetString(pwdArray, 0, pwdArray.Length) : null);
        }

        #endregion Methods (2)
    }
}