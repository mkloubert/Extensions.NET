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
using System.Linq;

namespace MarcelJoachimKloubert.Extensions
{
    // DistinctBy()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Returns unique items of a sequence by using a value selector
        /// for the values to compare.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <typeparam name="TValue">Type of the values to compare.</typeparam>
        /// <param name="seq">The sequence.</param>
        /// <param name="valueSelector">The function that selects the value from an item.</param>
        /// <param name="defaultValue">
        /// The default value if an item of <paramref name="seq" />
        /// is <see langword="null" />. This is only used if <paramref name="ofType" />
        /// is <see langword="true" />.
        /// </param>
        /// <param name="valueComparer">The custom comparer for the selected values.</param>
        /// <param name="ofType">
        /// Use <paramref name="defaultValue" /> if an item of <paramref name="seq" />
        /// is <see langword="null" /> or not.
        /// </param>
        /// <returns>The new sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="seq" /> and/or <paramref name="valueSelector" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<T> DistinctBy<T, TValue>(
            this IEnumerable<T> seq,
            Func<T, TValue> valueSelector,
            IEqualityComparer<TValue> valueComparer = null,
            bool ofType = false,
            TValue defaultValue = default(TValue))
        {
            return DistinctBy(
                seq: seq,
                valueSelector: valueSelector,
                valueComparer: valueComparer,
                ofType: ofType,
                defaultValueProvider: () => defaultValue);
        }

        /// <summary>
        /// Returns unique items of a sequence by using a value selector
        /// for the values to compare.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <typeparam name="TValue">Type of the values to compare.</typeparam>
        /// <param name="seq">The sequence.</param>
        /// <param name="valueSelector">The function that selects the value from an item.</param>
        /// <param name="defaultValueProvider">
        /// The function that provides the default value if an item of <paramref name="seq" />
        /// is <see langword="null" />. This is only used if <paramref name="ofType" />
        /// is <see langword="true" />.
        /// </param>
        /// <param name="valueComparer">The custom comparer for the selected values.</param>
        /// <param name="ofType">
        /// Use <paramref name="defaultValueProvider" /> if an item of <paramref name="seq" />
        /// is <see langword="null" /> or not.
        /// </param>
        /// <returns>The new sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="seq" />, <paramref name="valueSelector" /> and/or <paramref name="defaultValueProvider" />
        /// is <see langword="null" />.
        /// </exception>
        public static IEnumerable<T> DistinctBy<T, TValue>(
            this IEnumerable<T> seq,
            Func<T, TValue> valueSelector,
            Func<TValue> defaultValueProvider,
            IEqualityComparer<TValue> valueComparer = null,
            bool ofType = false)
        {
            if (seq == null)
            {
                throw new ArgumentException("seq");
            }

            if (valueSelector == null)
            {
                throw new ArgumentException("valueSelector");
            }

            if (defaultValueProvider == null)
            {
                throw new ArgumentException("defaultValueProvider");
            }

            valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;

            var valueSelectorToUse = valueSelector;
            if (ofType)
            {
                valueSelectorToUse = (x) => x != null ? valueSelector(x)
                                                      : defaultValueProvider();
            }

            var itemComparer = new DelegateComparer<T>(
                equalsPredicate: (x, y) => valueComparer.Equals(valueSelectorToUse(x),
                                                                valueSelectorToUse(y)),
                getHashCodeFunc: (obj) => valueComparer.GetHashCode(valueSelectorToUse(obj)));

            return seq.Distinct(comparer: itemComparer);
        }

        #endregion Methods
    }
}