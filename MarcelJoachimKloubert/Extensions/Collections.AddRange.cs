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

namespace MarcelJoachimKloubert.Extensions
{
    // AddRange()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Adds a range of items to a collection.
        /// </summary>
        /// <param name="coll">The target collection.</param>
        /// <param name="itemList">The items to add.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="coll" /> and/or <paramref name="itemList" /> is <see langword="null" />.
        /// </exception>
        public static void AddRange<T>(this ICollection<T> coll, params T[] itemList)
        {
            AddRange<T>(coll: coll,
                        items: itemList);
        }

        /// <summary>
        /// Adds a range of items to a collection.
        /// </summary>
        /// <param name="coll">The target collection.</param>
        /// <param name="items">The items to add.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="coll" /> and/or <paramref name="items" /> is <see langword="null" />.
        /// </exception>
        public static void AddRange<T>(this ICollection<T> coll, IEnumerable<T> items)
        {
            if (coll == null)
            {
                throw new ArgumentNullException(nameof(coll));
            }

            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (coll is List<T>)
            {
                // use build in method

                ((List<T>)coll).AddRange(items);
                return;
            }

            using (var e = items.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    coll.Add(e.Current);
                }
            }
        }

        #endregion Methods
    }
}