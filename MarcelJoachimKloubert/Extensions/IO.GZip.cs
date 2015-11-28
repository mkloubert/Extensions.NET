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
using System.IO.Compression;
using System.Linq;

namespace MarcelJoachimKloubert.Extensions
{
    // GZip()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (4)

        /// <summary>
        /// Compresses data via GZIP.
        /// </summary>
        /// <param name="data">The uncompressed data.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <returns>
        /// The compressed data or <see langword="null" /> if <paramref name="data" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static byte[] GZip(this IEnumerable<byte> data, int? bufferSize = null)
        {
            if (data == null)
            {
                return null;
            }

            using (var dest = new MemoryStream())
            {
                GZip(data, dest, bufferSize);

                return dest.ToArray();
            }
        }

        /// <summary>
        /// Compresses data via GZIP.
        /// </summary>
        /// <param name="data">The uncompressed data.</param>
        /// <param name="dest">The stream where to write the compressed data to.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dest" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static void GZip(this IEnumerable<byte> data, Stream dest, int? bufferSize = null)
        {
            if (data == null)
            {
                return;
            }

            var blob = data as byte[] ??
                       data.ToArray();

            using (var src = new MemoryStream(blob))
            {
                GZip(src, dest, bufferSize);
            }
        }

        /// <summary>
        /// Compresses data via GZIP.
        /// </summary>
        /// <param name="src">The uncompressed data.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <returns>The compressed data.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="src" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static byte[] GZip(this Stream src, int? bufferSize = null)
        {
            using (var dest = new MemoryStream())
            {
                GZip(src, dest, bufferSize);

                return dest.ToArray();
            }
        }

        /// <summary>
        /// Compresses data via GZIP.
        /// </summary>
        /// <param name="src">The uncompressed data.</param>
        /// <param name="dest">The stream where to write the compressed data to.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="src" /> and/or <paramref name="dest" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static void GZip(this Stream src, Stream dest, int? bufferSize = null)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
            }

            if (dest == null)
            {
                throw new ArgumentNullException(nameof(dest));
            }

            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), bufferSize, "Must be 1 at least!");
            }

            using (var gzip = new GZipStream(dest, CompressionMode.Compress, true))
            {
                try
                {
                    if (bufferSize.HasValue)
                    {
                        src.CopyTo(gzip, bufferSize.Value);
                    }
                    else
                    {
                        src.CopyTo(gzip);
                    }
                }
                finally
                {
                    gzip.Flush();
                }
            }
        }

        #endregion Methods (4)
    }
}