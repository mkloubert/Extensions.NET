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
using System.IO;
using System.Text;

namespace MarcelJoachimKloubert.Extensions
{
    // GetString()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Returns a byte array as string.
        /// </summary>
        /// <param name="blob">The byte array.</param>
        /// <param name="enc">The custom encoding to use (default: <see cref="Encoding.UTF8" />).</param>
        /// <returns><paramref name="blob" /> as string.</returns>
        /// <remarks>
        /// Returns <see langword="null" /> if <paramref name="blob" /> is also <see langword="null" />.
        /// </remarks>
        public static string GetString(this IEnumerable<byte> blob, Encoding enc = null)
        {
            if (blob == null)
            {
                return null;
            }

            return GetEncodingSafe(enc).GetString(AsArray(blob));
        }

        /// <summary>
        /// Returns a the content of a stream as string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="enc">The custom encoding to use (default: <see cref="Encoding.UTF8" />).</param>
        /// <param name="bufferSize">The custom buffer size to use.</param>
        /// <returns>Content of <paramref name="stream" /> as string.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is invalid.
        /// </exception>
        public static string GetString(this Stream stream, Encoding enc = null, int? bufferSize = null)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException("bufferSize", bufferSize, "Must be 1 at least!");
            }

            using (var temp = new MemoryStream())
            {
                if (bufferSize.HasValue)
                {
                    stream.CopyTo(temp, bufferSize.Value);
                }
                else
                {
                    stream.CopyTo(temp);
                }

                return GetString(temp.ToArray(), enc);
            }
        }

        #endregion Methods
    }
}