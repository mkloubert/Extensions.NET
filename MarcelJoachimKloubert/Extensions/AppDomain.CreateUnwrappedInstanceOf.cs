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
    // CreateUnwrappedInstanceOf()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (3)

        /// <summary>
        /// Creates a new instance of an object in a specific app domain for use in the current one.
        /// </summary>
        /// <typeparam name="TResult">The target type to return.</typeparam>
        /// <param name="domain">The application domain where the instance should be created.</param>
        /// <returns>The created (proxy) instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="domain" /> is <see langword="null" />.
        /// </exception>
        public static TResult CreateUnwrappedInstanceOf<TResult>(this AppDomain domain)
        {
            return CreateUnwrappedInstanceOf<TResult, TResult>(domain: domain);
        }

        /// <summary>
        /// Creates a new instance of an object in a specific app domain for use in the current one.
        /// </summary>
        /// <typeparam name="T">The type to create.</typeparam>
        /// <typeparam name="TResult">The target type to return.</typeparam>
        /// <param name="domain">The application domain where the instance should be created.</param>
        /// <returns>The created (proxy) instance of.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="domain" /> is <see langword="null" />.
        /// </exception>
        public static TResult CreateUnwrappedInstanceOf<T, TResult>(this AppDomain domain)
            where TResult : T
        {
            return (TResult)CreateUnwrappedInstanceOf(domain, typeof(T));
        }

        /// <summary>
        /// Creates a new instance of an object in a specific app domain for use in the current one.
        /// </summary>
        /// <param name="domain">The application domain where the instance should be created.</param>
        /// <param name="type">The type that should be created.</param>
        /// <returns>The created (proxy) instance of <paramref name="type" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="domain" /> and/or <paramref name="type" /> are <see langword="null" />.
        /// </exception>
        public static object CreateUnwrappedInstanceOf(this AppDomain domain, Type type)
        {
            if (domain == null)
            {
                throw new ArgumentNullException("domain");
            }

            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            return domain.CreateInstanceAndUnwrap(type.Assembly.FullName,
                                                  type.FullName);
        }

        #endregion Methods (3)
    }
}