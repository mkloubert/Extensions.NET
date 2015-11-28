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
using System.Data;

namespace MarcelJoachimKloubert.Extensions.Data
{
    // ToDictionary()
    static partial class MJKDataExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Returns all data records of a reader as dictionaries.
        /// </summary>
        /// <param name="reader">The record that contains the records.</param>
        /// <returns>The records as dictionaries.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<Dictionary<string, object>> ToDictionaries(this IDataReader reader)
        {
            return ToDictionaries<Dictionary<string, object>>(reader);
        }

        /// <summary>
        /// Returns all data records of a reader as dictionaries.
        /// </summary>
        /// <typeparam name="TDict">Type of the result dictionary.</typeparam>
        /// <param name="reader">The record that contains the records.</param>
        /// <returns>The records as dictionaries.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TDict> ToDictionaries<TDict>(this IDataReader reader)
            where TDict : global::System.Collections.Generic.IDictionary<string, object>, new()
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            while (reader.Read())
            {
                var result = new TDict();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    result.Add(key: reader.GetName(i) ?? string.Empty,
                               value: reader.IsDBNull(i) ? null : reader.GetValue(i));
                }

                yield return result;
            }
        }

        #endregion Methods (2)
    }
}