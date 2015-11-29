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

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarcelJoachimKloubert.Extensions
{
    // Invert()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (3)

        /// <summary>
        /// Inverts a dictionary (keys become values and values become keys).
        /// </summary>
        /// <param name="dict">The dictionary to convert.</param>
        /// <param name="keyComparer">The custom comparer for the new dictionary to use.</param>
        /// <returns>The inverted dictionary.</returns>
        /// <remarks>
        /// Result is <see langword="null" /> if <paramref name="dict" /> is also <see langword="null" />.
        /// </remarks>
        public static IDictionary Invert(IDictionary dict,
                                         IEqualityComparer<object> keyComparer = null)
        {
            if (dict == null)
            {
                return null;
            }

            return InvertInner<object, object>(items: dict.Cast<DictionaryEntry>()
                                                          .Select(x => new KeyValuePair<object, object>(x.Key, x.Value)),
                                               keyComparer: keyComparer);
        }

        /// <summary>
        /// Inverts a sequence of key/value pairs (keys become values and values become keys).
        /// </summary>
        /// <typeparam name="TKey">Type of the keys.</typeparam>
        /// <typeparam name="TValue">Type of the values.</typeparam>
        /// <param name="items">The items to convert.</param>
        /// <param name="keyComparer">The custom comparer for the new dictionary to use.</param>
        /// <returns>The inverted dictionary.</returns>
        /// <remarks>
        /// Result is <see langword="null" /> if <paramref name="items" /> is also <see langword="null" />.
        /// </remarks>
        public static IDictionary<TValue, TKey> Invert<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> items,
                                                                     IEqualityComparer<TValue> keyComparer = null)
        {
            return InvertInner<TKey, TValue>(items: items,
                                             keyComparer: keyComparer);
        }

        private static Dictionary<TValue, TKey> InvertInner<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> items,
                                                                          IEqualityComparer<TValue> keyComparer)
        {
            if (items == null)
            {
                return null;
            }

            var result = keyComparer == null ? new Dictionary<TValue, TKey>()
                                             : new Dictionary<TValue, TKey>(comparer: keyComparer);

            using (var e = items.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    var i = e.Current;

                    result.Add(i.Value, i.Key);
                }
            }

            return result;
        }

        #endregion Methods (3)
    }
}