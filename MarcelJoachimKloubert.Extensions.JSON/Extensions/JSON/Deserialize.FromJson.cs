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

using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.IO;

namespace MarcelJoachimKloubert.Extensions.JSON
{
    // FromJson
    static partial class MJKJsonExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Deserializes a JSON string to an object.
        /// </summary>
        /// <typeparam name="T">Result type.</typeparam>
        /// <param name="reader">The reader that contains the JSON data.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> is <see langword="null" />.
        /// </exception>
        public static T FromJson<T>(this TextReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return FromJson<T>(json: reader.ReadToEnd());
        }

        /// <summary>
        /// Deserializes a JSON string to an object.
        /// </summary>
        /// <typeparam name="T">Result type.</typeparam>
        /// <param name="json">The JSON data.</param>
        /// <returns>The deserialized object.</returns>
        public static T FromJson<T>(this string json)
        {
            var result = default(T);

            if (!string.IsNullOrWhiteSpace(json))
            {
                result = JsonConvert.DeserializeObject<T>(json);
            }

            return result;
        }

        /// <summary>
        /// Deserializes a JSON string to an object.
        /// </summary>
        /// <param name="json">The JSON data.</param>
        /// <returns>The deserialized object.</returns>
        public static dynamic FromJson(this string json)
        {
            return FromJson<ExpandoObject>(json: json);
        }

        /// <summary>
        /// Deserializes a JSON string to an object.
        /// </summary>
        /// <param name="reader">The reader that contains the JSON data.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> is <see langword="null" />.
        /// </exception>
        public static dynamic FromJson(this TextReader reader)
        {
            return FromJson<ExpandoObject>(reader);
        }

        #endregion Methods
    }
}