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
    // TryPop()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Tries to pop an item from a stack.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="stack">The stack.</param>
        /// <param name="value">The variable where to write the value to.</param>
        /// <param name="defaultValue">The value for <paramref name="value" /> if <paramref name="stack" /> is empty.</param>
        /// <returns>Pop operation was successfull or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stack" /> is <see langword="null" />.
        /// </exception>
        public static bool TryPop<T>(this Stack<T> stack, out T value, T defaultValue = default(T))
        {
            return TryPop<T>(stack: stack,
                             value: out value,
                             defaultValueProvider: (s) => defaultValue);
        }

        /// <summary>
        /// Tries to pop an item from a stack.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="stack">The stack.</param>
        /// <param name="value">The variable where to write the value to.</param>
        /// <param name="defaultValueProvider">
        /// The function that provides the value for <paramref name="value" /> if <paramref name="stack" />
        /// is empty.
        /// </param>
        /// <returns>Pop operation was successfull or not.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stack" /> and/or <paramref name="defaultValueProvider" /> is <see langword="null" />.
        /// </exception>
        public static bool TryPop<T>(this Stack<T> stack, out T value, Func<Stack<T>, T> defaultValueProvider)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            if (defaultValueProvider == null)
            {
                throw new ArgumentNullException(nameof(defaultValueProvider));
            }

            if (stack.Count > 0)
            {
                value = stack.Pop();
                return true;
            }

            value = defaultValueProvider(stack);
            return false;
        }

        #endregion Methods (2)
    }
}