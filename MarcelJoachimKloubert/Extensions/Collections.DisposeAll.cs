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
    // DisposeAll()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Disposes all <see cref="IDisposable" /> items of a sequence.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="seq">The sequence.</param>
        /// <param name="returnAll">Return also the disposed objects or not.</param>
        /// <param name="returnNull">Return also the <see langword="null" /> references or not.</param>
        /// <returns>
        /// The new sequence or <see langword="null" /> if <paramref name="seq" /> is <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// A delayed sequence is returned what means that objects will only disposed when you walk through <paramref name="seq" />.
        /// </remarks>
        public static IEnumerable<T> DisposeAll<T>(this IEnumerable<T> seq, bool returnAll = false, bool returnNull = false)
        {
            if (seq == null)
            {
                return null;
            }

            return DisposeAllInner<T>(seq,
                                      returnAll: returnAll, returnNull: returnNull);
        }

        private static IEnumerable<T> DisposeAllInner<T>(this IEnumerable<T> seq, bool returnAll, bool returnNull)
        {
            using (var e = seq.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    var current = e.Current;

                    bool doReturnItem;

                    if (null != current)
                    {
                        doReturnItem = true;

                        if (current is IDisposable)
                        {
                            doReturnItem = returnAll;

                            ((IDisposable)current).Dispose();
                        }
                    }
                    else
                    {
                        doReturnItem = returnNull;
                    }

                    if (doReturnItem)
                    {
                        yield return current;
                    }
                }
            }
        }

        #endregion Methods (2)
    }
}