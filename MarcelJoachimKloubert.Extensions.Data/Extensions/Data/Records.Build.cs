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

namespace MarcelJoachimKloubert.Extensions.Data
{
    // Build()
    static partial class MJKDataExtensionMethods
    {
        #region Methods (3)

        /// <summary>
        /// Builds an object from a data record.
        /// </summary>
        /// <typeparam name="TRec">Type of the record.</typeparam>
        /// <typeparam name="TObj">Type of the object to build.</typeparam>
        /// <param name="rec">The record with the data.</param>
        /// <param name="factory">The factory that created the object.</param>
        /// <returns>The created object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="rec" /> and/or <paramref name="factory" /> is <see langword="null" />.
        /// </exception>
        public static TObj Build<TRec, TObj>(this TRec rec, Func<TRec, TObj> factory)
            where TRec : global::System.Data.IDataRecord
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return Build(rec: rec,
                         factory: (r, f) => f(r),
                         factoryState: factory);
        }

        /// <summary>
        /// Builds an object from a data record.
        /// </summary>
        /// <typeparam name="TRec">Type of the record.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="factory" />.</typeparam>
        /// <typeparam name="TObj">Type of the object to build.</typeparam>
        /// <param name="rec">The record with the data.</param>
        /// <param name="factory">The factory that created the object.</param>
        /// <param name="factoryState">The second argument for <paramref name="factory" />.</param>
        /// <returns>The created object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="rec" /> and/or <paramref name="factory" /> is <see langword="null" />.
        /// </exception>
        public static TObj Build<TRec, TState, TObj>(this TRec rec,
                                                     Func<TRec, TState, TObj> factory, TState factoryState)
            where TRec : global::System.Data.IDataRecord
        {
            return Build(rec: rec,
                         factory: factory, factoryStateProvider: (r) => factoryState);
        }

        /// <summary>
        /// Builds an object from a data record.
        /// </summary>
        /// <typeparam name="TRec">Type of the record.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="factory" />.</typeparam>
        /// <typeparam name="TObj">Type of the object to build.</typeparam>
        /// <param name="rec">The record with the data.</param>
        /// <param name="factory">The factory that created the object.</param>
        /// <param name="factoryStateProvider">The function that returns the second argument for <paramref name="factory" />.</param>
        /// <returns>The created object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="rec" />, <paramref name="factory" /> and/or <paramref name="factoryStateProvider" /> is <see langword="null" />.
        /// </exception>
        public static TObj Build<TRec, TState, TObj>(this TRec rec,
                                                     Func<TRec, TState, TObj> factory, Func<TRec, TState> factoryStateProvider)
            where TRec : global::System.Data.IDataRecord
        {
            if (rec == null)
            {
                throw new ArgumentNullException("rec");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            if (factoryStateProvider == null)
            {
                throw new ArgumentNullException("factoryStateProvider");
            }

            return factory(rec,
                           factoryStateProvider(rec));
        }

        #endregion Methods (3)
    }
}