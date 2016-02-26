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
using System.Linq;
using System.Security.Cryptography;

namespace MarcelJoachimKloubert.Extensions
{
    // Hash()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Hashes binary data.
        /// </summary>
        /// <typeparam name="TAlgo">The algorithm to use.</typeparam>
        /// <param name="data">The data to hash.</param>
        /// <returns>The hash or <see langword="null" /> if <paramref name="data" /> is <see langword="null" />.</returns>
        public static byte[] Hash<TAlgo>(this IEnumerable<byte> data)
            where TAlgo : global::System.Security.Cryptography.HashAlgorithm, new()
        {
            return Hash(data: data,
                        algorithm: typeof(TAlgo));
        }

        /// <summary>
        /// Hashes binary data.
        /// </summary>
        /// <param name="data">The data to hash.</param>
        /// <param name="algorithm">The algorithm to use.</param>
        /// <returns>The hash or <see langword="null" /> if <paramref name="data" /> is <see langword="null" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="algorithm" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// <paramref name="algorithm" /> is no subclass of <see cref="HashAlgorithm" />.
        /// </exception>
        /// <exception cref="MemberAccessException">
        /// <paramref name="algorithm" /> is abstract.
        /// </exception>
        /// <exception cref="MissingMethodException">
        /// <paramref name="algorithm" /> has no public constructor.
        /// </exception>
        public static byte[] Hash(this IEnumerable<byte> data, Type algorithm)
        {
            if (data == null)
            {
                return null;
            }

            using (var temp = new MemoryStream(data as byte[] ?? data.ToArray(),
                                               false))
            {
                return Hash(temp, algorithm);
            }
        }

        /// <summary>
        /// Hashes a stream.
        /// </summary>
        /// <typeparam name="TAlgo">The algorithm to use.</typeparam>
        /// <param name="stream">The stream to hash.</param>
        /// <returns>The hash.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> is <see langword="null" />.
        /// </exception>
        public static byte[] Hash<TAlgo>(this Stream stream)
            where TAlgo : global::System.Security.Cryptography.HashAlgorithm, new()
        {
            return Hash(stream: stream,
                        algorithm: typeof(TAlgo));
        }

        /// <summary>
        /// Hashes a stream.
        /// </summary>
        /// <param name="stream">The stream to hash.</param>
        /// <param name="algorithm">The algorithm to use.</param>
        /// <returns>The hash.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> and/or <paramref name="algorithm" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// <paramref name="algorithm" /> is no subclass of <see cref="HashAlgorithm" />.
        /// </exception>
        /// <exception cref="MemberAccessException">
        /// <paramref name="algorithm" /> is abstract.
        /// </exception>
        /// <exception cref="MissingMethodException">
        /// <paramref name="algorithm" /> has no public constructor.
        /// </exception>
        public static byte[] Hash(this Stream stream, Type algorithm)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (algorithm == null)
            {
                throw new ArgumentNullException("algorithm");
            }

            using (var hasher = (HashAlgorithm)Activator.CreateInstance(algorithm))
            {
                return hasher.ComputeHash(stream);
            }
        }

        #endregion Methods
    }
}