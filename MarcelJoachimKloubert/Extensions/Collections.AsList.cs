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
    // AsList()
    static partial class MJKCoreExtensionMethods
    {
        #region Method (2)

        /// <summary>
        /// Returns a sequence as <see cref="IList{T}" /> object.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="seq">The sequence to convert / cast.</param>
        /// <param name="emptyIfNull">
        /// Return an empty list if <paramref name="seq" /> is <see langword="null" />;
        /// otherwise <see langword="null" /> is returned.
        /// </param>
        /// <returns>
        /// <paramref name="seq" /> as list or <see langword="null" /> if <paramref name="seq" /> is <see langword="null" />
        /// and <paramref name="emptyIfNull" /> is <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="seq" /> is already an <see cref="IList{T}" /> object it is simply casted.
        /// </remarks>
        public static IList<T> AsList<T>(this IEnumerable<T> seq, bool emptyIfNull = false)
        {
            if (seq is IList<T>)
            {
                return (IList<T>)seq;
            }

            if (seq == null)
            {
                return !emptyIfNull ? null : new List<T>();
            }

            return new List<T>(seq);
        }

        /// <summary>
        /// Returns a sequence as <see cref="IList" /> object.
        /// </summary>
        /// <param name="seq">The sequence to convert / cast.</param>
        /// <param name="emptyIfNull">
        /// Return an empty list if <paramref name="seq" /> is <see langword="null" />;
        /// otherwise <see langword="null" /> is returned.
        /// </param>
        /// <returns>
        /// <paramref name="seq" /> as list or <see langword="null" /> if <paramref name="seq" /> is <see langword="null" />
        /// and <paramref name="emptyIfNull" /> is <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="seq" /> is already an <see cref="IList" /> object it is simply casted.
        /// </remarks>
        public static IList AsList(this IEnumerable seq, bool emptyIfNull = false)
        {
            if (seq is ICollection)
            {
                return (IList)seq;
            }

            if (seq == null)
            {
                return !emptyIfNull ? null : new List<object>();
            }

            return new List<object>(seq.Cast<object>());
        }

        #endregion Method (2)
    }
}