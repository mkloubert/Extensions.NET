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
    // Without
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (4)

        /// <summary>
        /// Returns a filtered list without specific items.
        /// </summary>
        /// <param name="seq">The input sequence.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns>The output sequence.</returns>
        /// <remarks>
        /// Result is <see langword="null" /> if <paramref name="seq" /> is also <see langword="null" />.
        /// </remarks>
        public static IEnumerable<object> Without(this IEnumerable seq, object item)
        {
            return seq == null ? null
                               : Without<object>(seq: seq.Cast<object>(),
                                                 item: item);
        }

        /// <summary>
        /// Returns a filtered list without specific items.
        /// </summary>
        /// <param name="seq">The input sequence.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>The output sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="predicate" /> is <see langword="null" />.
        /// </exception>
        /// <remarks>
        /// Result is <see langword="null" /> if <paramref name="seq" /> is also <see langword="null" />.
        /// </remarks>
        public static IEnumerable<object> Without(this IEnumerable seq, Func<object, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return seq == null ? null
                               : Without<object>(seq: seq.Cast<object>(),
                                                 predicate: predicate);
        }

        /// <summary>
        /// Returns a filtered list without specific items.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="seq">The input sequence.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns>The output sequence.</returns>
        /// <remarks>
        /// Result is <see langword="null" /> if <paramref name="seq" /> is also <see langword="null" />.
        /// </remarks>
        public static IEnumerable<T> Without<T>(this IEnumerable<T> seq, T item)
        {
            return Without<T>(seq: seq,
                              predicate: (x) => EqualityComparer<T>.Default.Equals(item, x));
        }

        /// <summary>
        /// Returns a filtered list without specific items.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="seq">The input sequence.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>The output sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="predicate" /> is <see langword="null" />.
        /// </exception>
        /// <remarks>
        /// Result is <see langword="null" /> if <paramref name="seq" /> is also <see langword="null" />.
        /// </remarks>
        public static IEnumerable<T> Without<T>(this IEnumerable<T> seq, Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return seq?.Where(x => !predicate(x));
        }

        #endregion Methods (4)
    }
}