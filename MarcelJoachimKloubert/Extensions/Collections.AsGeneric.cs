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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarcelJoachimKloubert.Extensions
{
    // AsGeneric()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (7)

        /// <summary>
        /// Casts a general collection to a generic collection.
        /// </summary>
        /// <param name="coll">The input collection.</param>
        /// <returns>
        /// The casted collection or <see langword="null" /> if <paramref name="coll" /> is also <see langword="null" />.
        /// </returns>
        public static ICollection<object> AsGeneric(this ICollection coll)
        {
            return AsGeneric<object>(coll: coll,
                                     ofType: false);
        }

        /// <summary>
        /// Casts a general collection to a generic collection.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="coll">The input collection.</param>
        /// <param name="ofType">
        /// Filter compatible items (<see langword="true" />) or take all (<see langword="false" />).
        /// </param>
        /// <returns>
        /// The casted collection or <see langword="null" /> if <paramref name="coll" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="InvalidCastException">At least one item could not be casted.</exception>
        public static ICollection<T> AsGeneric<T>(this ICollection coll, bool ofType = true)
        {
            if (coll == null)
            {
                return null;
            }

            var result = coll as IList<T>;

            if (result == null)
            {
                var itemsToAdd = ofType ? coll.OfType<T>()
                                        : coll.Cast<T>();

                result = new List<T>();
                using (var e = itemsToAdd.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        result.Add(e.Current);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Casts a general list to a generic list.
        /// </summary>
        /// <param name="list">The input list.</param>
        /// <returns>
        /// The casted list or <see langword="null" /> if <paramref name="list" /> is also <see langword="null" />.
        /// </returns>
        public static IList<object> AsGeneric(this IList list)
        {
            return AsGeneric<object>(list: list,
                                     ofType: false);
        }

        /// <summary>
        /// Casts a general list to a generic list.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="list">The input list.</param>
        /// <param name="ofType">
        /// Filter compatible items (<see langword="true" />) or take all (<see langword="false" />).
        /// </param>
        /// <returns>
        /// The casted list or <see langword="null" /> if <paramref name="list" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="InvalidCastException">At least one item could not be casted.</exception>
        public static IList<T> AsGeneric<T>(this IList list, bool ofType = true)
        {
            return (IList<T>)AsGeneric<T>(coll: list,
                                          ofType: ofType);
        }

        /// <summary>
        /// Casts a general dictionary to a generic dictionary.
        /// </summary>
        /// <param name="dict">The input dictionary.</param>
        /// <returns>
        /// The casted list or <see langword="null" /> if <paramref name="dict" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="InvalidCastException">At least one item could not be casted.</exception>
        public static IDictionary<object, object> AsGeneric(this IDictionary dict)
        {
            return AsGeneric<object>(dict: dict,
                                     ofType: false);
        }

        /// <summary>
        /// Casts a general dictionary to a generic dictionary.
        /// </summary>
        /// <typeparam name="TValue">The target type of the values.</typeparam>
        /// <param name="dict">The input dictionary.</param>
        /// <param name="ofType">
        /// Filter compatible items (<see langword="true" />) or take all (<see langword="false" />).
        /// </param>
        /// <returns>
        /// The casted list or <see langword="null" /> if <paramref name="dict" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="InvalidCastException">At least one key/item could not be casted.</exception>
        public static IDictionary<object, TValue> AsGeneric<TValue>(this IDictionary dict, bool ofType = true)
        {
            return AsGeneric<object, TValue>(dict: dict,
                                             ofType: ofType);
        }

        /// <summary>
        /// Casts a general dictionary to a generic dictionary.
        /// </summary>
        /// <typeparam name="TKey">The target type of the keys.</typeparam>
        /// <typeparam name="TValue">The target type of the values.</typeparam>
        /// <param name="dict">The input dictionary.</param>
        /// <param name="ofType">
        /// Filter compatible items (<see langword="true" />) or take all (<see langword="false" />).
        /// </param>
        /// <returns>
        /// The casted list or <see langword="null" /> if <paramref name="dict" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="InvalidCastException">At least one key/item could not be casted.</exception>
        public static IDictionary<TKey, TValue> AsGeneric<TKey, TValue>(this IDictionary dict, bool ofType = true)
        {
            if (dict == null)
            {
                return null;
            }

            var result = dict as IDictionary<TKey, TValue>;

            if (result == null)
            {
                result = new Dictionary<TKey, TValue>();

                var entries = dict.Cast<DictionaryEntry>();

                IEnumerable<DictionaryEntry> entriesToAdd;
                if (ofType)
                {
                    entriesToAdd = entries.Where(x => x.Key is TKey &&
                                                      x.Value is TValue);
                }
                else
                {
                    entriesToAdd = entries;
                }

                using (var e = entriesToAdd.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        var entry = e.Current;

                        result.Add((TKey)entry.Key,
                                   (TValue)entry.Value);
                    }
                }
            }

            return result;
        }

        #endregion Methods (4)
    }
}