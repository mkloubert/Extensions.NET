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
        /// Uncompresses data via GZIP.
        /// </summary>
        /// <param name="data">The compressed data.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <returns>
        /// The uncompressed data or <see langword="null" /> if <paramref name="data" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static byte[] GUnzip(this IEnumerable<byte> data, int? bufferSize = null)
        {
            if (data == null)
            {
                return null;
            }

            using (var dest = new MemoryStream())
            {
                GUnzip(data, dest, bufferSize);

                return dest.ToArray();
            }
        }

        /// <summary>
        /// Uncompresses data via GZIP.
        /// </summary>
        /// <param name="data">The compressed data.</param>
        /// <param name="dest">The stream where to write the uncompressed data to.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dest" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static void GUnzip(this IEnumerable<byte> data, Stream dest, int? bufferSize = null)
        {
            if (data == null)
            {
                return;
            }

            var blob = data as byte[] ??
                       data.ToArray();

            using (var src = new MemoryStream(blob))
            {
                GUnzip(src, dest, bufferSize);
            }
        }

        /// <summary>
        /// Uncompresses data via GZIP.
        /// </summary>
        /// <param name="src">The compressed data.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <returns>The uncompressed data.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="src" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static byte[] GUnzip(this Stream src, int? bufferSize = null)
        {
            using (var dest = new MemoryStream())
            {
                GUnzip(src, dest, bufferSize);

                return dest.ToArray();
            }
        }

        /// <summary>
        /// Uncompresses data via GZIP.
        /// </summary>
        /// <param name="src">The compressed data.</param>
        /// <param name="dest">The stream where to write the uncompressed data to.</param>
        /// <param name="bufferSize">The buffer size to use.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="src" /> and/or <paramref name="dest" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="bufferSize" /> is less than 1.
        /// </exception>
        public static void GUnzip(this Stream src, Stream dest, int? bufferSize = null)
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

            try
            {
                using (var gzip = new GZipStream(src, CompressionMode.Decompress, true))
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
            }
            finally
            {
                dest.Flush();
            }
        }

        #endregion Methods (4)
    }
}