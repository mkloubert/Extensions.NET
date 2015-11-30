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

namespace MarcelJoachimKloubert.Extensions
{
    // Build()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Builds an object from a common dictionary.
        /// </summary>
        /// <typeparam name="T">Type of the object to return.</typeparam>
        /// <typeparam name="TDict">Type of the dictionary.</typeparam>
        /// <param name="dict">The dictionary.</param>
        /// <param name="factory">The function that build the object to return.</param>
        /// <param name="defValue">The result if <paramref name="dict" /> is <see langword="null" />.</param>
        /// <returns>The return of <paramref name="factory" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" /> is <see langword="null" />.
        /// </exception>
        public static T Build<TDict, T>(this TDict dict,
                                        Func<TDict, T> factory, T defValue = default(T))
            where TDict : global::System.Collections.IDictionary,
                          global::System.Collections.Generic.IDictionary<string, object>
        {
            return Build(dict: dict,
                         factory: factory, defValueProvider: () => defValue);
        }

        /// <summary>
        /// Builds an object from a common dictionary.
        /// </summary>
        /// <typeparam name="T">Type of the object to return.</typeparam>
        /// <typeparam name="TDict">Type of the dictionary.</typeparam>
        /// <param name="dict">The dictionary.</param>
        /// <param name="factory">The function that build the object to return.</param>
        /// <param name="defValueProvider">The function that provides the result if <paramref name="dict" /> is <see langword="null" />.</param>
        /// <returns>The return of <paramref name="factory" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" /> and/or <paramref name="defValueProvider" /> is <see langword="null" />.
        /// </exception>
        public static T Build<TDict, T>(this TDict dict,
                                        Func<TDict, T> factory, Func<T> defValueProvider)
            where TDict : global::System.Collections.IDictionary,
                          global::System.Collections.Generic.IDictionary<string, object>
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (defValueProvider == null)
            {
                throw new ArgumentNullException(nameof(defValueProvider));
            }

            return dict == null ? defValueProvider()
                                : factory(dict);
        }

        #endregion Methods (2)
    }
}