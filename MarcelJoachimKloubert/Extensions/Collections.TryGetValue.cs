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

namespace MarcelJoachimKloubert.Extensions
{
    // TryGetValue()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (6)

        /// <summary>
        /// Tries to return a value from a general dictionary.
        /// </summary>
        /// <param name="dict">The ditionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The variable where to write the found value to.</param>
        /// <param name="defValue">The default value if <paramref name="key" /> does not exist.</param>
        /// <returns>Value was found or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dict" /> is <see langword="null" />.
        /// </exception>
        public static bool TryGetValue(this IDictionary dict,
                                       object key, out object value, object defValue = null)
        {
            return TryGetValue<object>(dict: dict,
                                       key: key, value: out value, defValue: defValue);
        }

        /// <summary>
        /// Tries to return a value from a general dictionary.
        /// </summary>
        /// <param name="dict">The ditionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The variable where to write the found value to.</param>
        /// <param name="defValueProvider">The function that provides the default value if <paramref name="key" /> does not exist.</param>
        /// <returns>Value was found or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dict" /> and/or <paramref name="defValueProvider" /> is <see langword="null" />.
        /// </exception>
        public static bool TryGetValue(this IDictionary dict,
                                       object key, out object value, Func<IDictionary, object> defValueProvider)
        {
            return TryGetValue<object>(dict: dict,
                                       key: key, value: out value, defValueProvider: defValueProvider);
        }

        /// <summary>
        /// Tries to return a value from a general dictionary strong typed.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="dict">The ditionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The variable where to write the found value to.</param>
        /// <param name="defValue">The default value if <paramref name="key" /> does not exist.</param>
        /// <returns>Value was found or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dict" /> is <see langword="null" />.
        /// </exception>
        public static bool TryGetValue<TResult>(this IDictionary dict,
                                                object key, out TResult value, TResult defValue = default(TResult))
        {
            return TryGetValue<TResult>(dict: dict,
                                        key: key, value: out value, defValueProvider: (d) => defValue);
        }

        /// <summary>
        /// Tries to return a value from a general dictionary strong typed.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="dict">The ditionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The variable where to write the found value to.</param>
        /// <param name="defValueProvider">The function that provides the default value if <paramref name="key" /> does not exist.</param>
        /// <returns>Value was found or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dict" /> and/or <paramref name="defValueProvider" /> is <see langword="null" />.
        /// </exception>
        public static bool TryGetValue<TResult>(this IDictionary dict,
                                                object key, out TResult value, Func<IDictionary, TResult> defValueProvider)
        {
            if (dict == null)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            if (defValueProvider == null)
            {
                throw new ArgumentNullException(nameof(defValueProvider));
            }

            if (dict.Contains(key))
            {
                value = (TResult)dict[key];
                return true;
            }

            value = defValueProvider(dict);
            return false;
        }

        /// <summary>
        /// Tries to return a value from a common dictionary strong typed.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="dict">The ditionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The variable where to write the found value to.</param>
        /// <param name="defValue">The default value if <paramref name="key" /> does not exist.</param>
        /// <returns>Value was found or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dict" /> is <see langword="null" />.
        /// </exception>
        public static bool TryGetValue<TResult>(this IDictionary<string, object> dict,
                                                string key, out TResult value, TResult defValue = default(TResult))
        {
            return TryGetValue<TResult>(dict: dict,
                                        key: key, value: out value, defValueProvider: (d) => defValue);
        }

        /// <summary>
        /// Tries to return a value from a common dictionary strong typed.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="dict">The ditionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The variable where to write the found value to.</param>
        /// <param name="defValueProvider">The function that provides the default value if <paramref name="key" /> does not exist.</param>
        /// <returns>Value was found or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dict" /> and/or <paramref name="defValueProvider" /> is <see langword="null" />.
        /// </exception>
        public static bool TryGetValue<TResult>(this IDictionary<string, object> dict,
                                                string key, out TResult value, Func<IDictionary<string, object>, TResult> defValueProvider)
        {
            if (dict == null)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            if (defValueProvider == null)
            {
                throw new ArgumentNullException(nameof(defValueProvider));
            }

            object temp;
            if (dict.TryGetValue(key, out temp))
            {
                value = (TResult)temp;
                return true;
            }

            value = defValueProvider(dict);
            return false;
        }

        #endregion Methods (6)
    }
}