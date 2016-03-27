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
using System.IO;
using System.Linq;

namespace MarcelJoachimKloubert.Extensions
{
    // DeleteWhere()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Deletes all items of a directory that satify a condition.
        /// </summary>
        /// <param name="dir">The directory.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <param name="throwOnFirstError">Throw first exception or not.</param>
        /// <exception cref="AggregateException">One or more error occured.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dir" /> and/or <paramref name="predicate" /> is <see langword="null" />.
        /// </exception>
        public static void DeleteWhere(this DirectoryInfo dir, Func<FileSystemInfo, bool> predicate, bool throwOnFirstError = true)
        {
            if (dir == null)
            {
                throw new ArgumentNullException(nameof(dir));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var exceptions = new List<Exception>();

            using (var e = dir.EnumerateFileSystemInfos().Where(predicate).GetEnumerator())
            {
                while (e.MoveNext())
                {
                    try
                    {
                        e.Current.Delete();
                    }
                    catch (Exception ex)
                    {
                        if (throwOnFirstError)
                        {
                            throw AsAggregate(ex);
                        }

                        exceptions.Add(ex);
                    }
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        #endregion Methods
    }
}