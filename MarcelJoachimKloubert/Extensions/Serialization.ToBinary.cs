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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MarcelJoachimKloubert.Extensions
{
    // ToBinary
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Serializes an object to binary data.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="dbNullAsNull">Handle <see cref="DBNull" /> object as <see langword="null" /> reference or not.</param>
        /// <returns>
        /// The serialized data or <see langword="null" /> id <paramref name="obj" /> is also <see langword="null" />.
        /// </returns>
        public static byte[] ToBinary(this object obj, bool dbNullAsNull = true)
        {
            if (DBNull.Value.Equals(obj) &&
                   dbNullAsNull)
            {
                obj = null;
            }

            if (obj == null)
            {
                return null;
            }

            using (var temp = new MemoryStream())
            {
                ToBinary(obj, temp, dbNullAsNull);

                return temp.ToArray();
            }
        }

        /// <summary>
        /// Serializes an object to binary data.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="stream">The stream where to write the data to.</param>
        /// <param name="dbNullAsNull">Handle <see cref="DBNull" /> object as <see langword="null" /> reference or not.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> is <see langword="null" />.
        /// </exception>
        public static void ToBinary(this object obj, Stream stream, bool dbNullAsNull = true)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (DBNull.Value.Equals(obj) &&
                dbNullAsNull)
            {
                obj = null;
            }

            if (obj == null)
            {
                return;
            }

            new BinaryFormatter().Serialize(stream, obj);
        }

        #endregion Methods
    }
}