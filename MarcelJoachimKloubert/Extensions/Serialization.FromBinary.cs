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
using System.Runtime.Serialization.Formatters.Binary;

namespace MarcelJoachimKloubert.Extensions
{
    // FromBinary()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Deserializes an object from binary data.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="blob">The data.</param>
        /// <returns>The deserialized object.</returns>
        public static TTarget FromBinary<TTarget>(this IEnumerable<byte> blob)
        {
            if (blob == null)
            {
                return default(TTarget);
            }

            return (TTarget)FromBinary(blob);
        }

        /// <summary>
        /// Deserializes an object from binary data.
        /// </summary>
        /// <param name="blob">The data.</param>
        /// <returns>The deserialized object.</returns>
        public static object FromBinary(this IEnumerable<byte> blob)
        {
            using (var temp = new MemoryStream(AsArray(blob, true), false))
            {
                if (temp.Length < 1)
                {
                    return null;
                }

                return FromBinary(temp);
            }
        }

        /// <summary>
        /// Deserializes an object from binary data.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="stream">The stream that contains the data.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> is <see langword="null" />.
        /// </exception>
        public static TTarget FromBinary<TTarget>(this Stream stream)
        {
            return (TTarget)FromBinary(stream);
        }

        /// <summary>
        /// Deserializes an object from binary data.
        /// </summary>
        /// <param name="stream">The stream that contains the data.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> is <see langword="null" />.
        /// </exception>
        public static object FromBinary(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            return new BinaryFormatter().Deserialize(stream);
        }

        #endregion Methods
    }
}