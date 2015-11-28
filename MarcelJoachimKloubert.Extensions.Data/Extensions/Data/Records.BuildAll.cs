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

namespace MarcelJoachimKloubert.Extensions.Data
{
    // BuildAll()
    static partial class MJKDataExtensionMethods
    {
        #region Methods (3)

        /// <summary>
        /// Builds objects from a data reader.
        /// </summary>
        /// <typeparam name="TReader">Type of the reader.</typeparam>
        /// <typeparam name="TObj">Type of the objects to build.</typeparam>
        /// <param name="reader">The record with the data.</param>
        /// <param name="factory">The factory that created the object.</param>
        /// <returns>The created objects.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> and/or <paramref name="factory" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TObj> BuildAll<TReader, TObj>(this TReader reader, Func<TReader, TObj> factory)
            where TReader : global::System.Data.IDataReader
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return BuildAll(reader: reader,
                            factory: (r, f) => f(r),
                            factoryState: factory);
        }

        /// <summary>
        /// Builds objects from a data reader.
        /// </summary>
        /// <typeparam name="TReader">Type of the reader.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="factory" />.</typeparam>
        /// <typeparam name="TObj">Type of the objects to build.</typeparam>
        /// <param name="reader">The record with the data.</param>
        /// <param name="factory">The factory that created the object.</param>
        /// <param name="factoryState">The second argument for <paramref name="factory" />.</param>
        /// <returns>The created objects.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> and/or <paramref name="factory" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TObj> BuildAll<TReader, TState, TObj>(this TReader reader,
                                                                        Func<TReader, TState, TObj> factory, TState factoryState)
            where TReader : global::System.Data.IDataReader
        {
            return BuildAll(reader: reader,
                            factory: factory, factoryStateProvider: (r) => factoryState);
        }

        /// <summary>
        /// Builds objects from a data reader.
        /// </summary>
        /// <typeparam name="TReader">Type of the reader.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="factory" />.</typeparam>
        /// <typeparam name="TObj">Type of the objects to build.</typeparam>
        /// <param name="reader">The record with the data.</param>
        /// <param name="factory">The factory that created the object.</param>
        /// <param name="factoryStateProvider">The function that returns the second argument for <paramref name="factory" />.</param>
        /// <returns>The created objects.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" />, <paramref name="factory" /> and/or <paramref name="factoryStateProvider" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TObj> BuildAll<TReader, TState, TObj>(this TReader reader,
                                                                        Func<TReader, TState, TObj> factory, Func<TReader, TState> factoryStateProvider)
            where TReader : global::System.Data.IDataReader
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            if (factoryStateProvider == null)
            {
                throw new ArgumentNullException("factoryStateProvider");
            }

            while (reader.Read())
            {
                yield return factory(reader,
                                     factoryStateProvider(reader));
            }
        }

        #endregion Methods (3)
    }
}