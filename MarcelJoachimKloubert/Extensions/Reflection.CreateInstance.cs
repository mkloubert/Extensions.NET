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
using System.Reflection;

namespace MarcelJoachimKloubert.Extensions
{
    // CreateInstance()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (4)

        /// <summary>
        /// Creates a new instance from a type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="argList">The arguments for the constructor.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="type" /> is <see langword="null" />.
        /// </exception>
        public static object CreateInstance(this Type type, IEnumerable<object> argList)
        {
            return CreateInstance<object>(type: type,
                                          argList: argList);
        }

        /// <summary>
        /// Creates a new instance from a type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The arguments for the constructor.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="type" /> is <see langword="null" />.
        /// </exception>
        public static object CreateInstance(this Type type, params object[] args)
        {
            return CreateInstance<object>(type: type,
                                          args: args);
        }

        /// <summary>
        /// Creates a new instance from a type.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="argList">The arguments for the constructor.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="type" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// <typeparamref name="T" /> cannot be converted to <paramref name="type" />.
        /// </exception>
        public static T CreateInstance<T>(this Type type, IEnumerable<object> argList)
        {
            var args = argList as object[];
            if (argList != null && args == null)
            {
                args = argList.ToArray();
            }

            return CreateInstance<T>(type: type,
                                     args: args);
        }

        /// <summary>
        /// Creates a new instance from a type.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="args">The arguments for the constructor.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="type" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// <typeparamref name="T" /> cannot be converted to <paramref name="type" />.
        /// </exception>
        public static T CreateInstance<T>(this Type type, params object[] args)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!type.IsAssignableFrom(typeof(T)))
            {
                throw new InvalidCastException();
            }

            return (T)Activator.CreateInstance(type: type,
                                               args: args ?? new object[] { null });
        }

        #endregion Methods (4)
    }
}