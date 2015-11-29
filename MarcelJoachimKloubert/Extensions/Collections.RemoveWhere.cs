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
    // RemoveWhere()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Removes all items from a list that match a predicate.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="list" /> and/or <paramref name="predicate" /> is <see langword="null" />.
        /// </exception>
        public static void RemoveWhere(this IList list, Func<object, bool> predicate)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            using (var e = list.Cast<object>().Where(predicate).ToList().GetEnumerator())
            {
                while (e.MoveNext())
                {
                    var item = e.Current;

                    while (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
            }
        }

        /// <summary>
        /// Removes all items from a collection that match a predicate.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="coll">The collection.</param>
        /// <param name="predicate">The predicate.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="coll" /> and/or <paramref name="predicate" /> is <see langword="null" />.
        /// </exception>
        public static void RemoveWhere<T>(this ICollection<T> coll, Func<T, bool> predicate)
        {
            if (coll == null)
            {
                throw new ArgumentNullException("coll");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            using (var e = coll.Where(predicate).ToList().GetEnumerator())
            {
                while (e.MoveNext())
                {
                    var item = e.Current;

                    while (coll.Contains(item))
                    {
                        coll.Remove(item);
                    }
                }
            }
        }

        #endregion Methods (2)
    }
}