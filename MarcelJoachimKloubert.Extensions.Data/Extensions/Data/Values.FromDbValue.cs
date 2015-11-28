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
using System.Data;

namespace MarcelJoachimKloubert.Extensions.Data
{
    // FromDbValue()
    static partial class MJKDataExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Reads a value from a data record.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="rec">The record from where to read the value from.</param>
        /// <param name="name">The name of the field inside the data record where the value is stored.</param>
        /// <returns>The value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="rec" /> is <see langword="null" />.
        /// </exception>
        public static T FromDbValue<T>(this IDataRecord rec, string name)
        {
            if (rec == null)
            {
                throw new ArgumentNullException("rec");
            }

            return FromDbValue<T>(rec,
                                  rec.GetOrdinal(name));
        }

        /// <summary>
        /// Reads a value from a data record.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="rec">The record from where to read the value from.</param>
        /// <param name="ordinal">The ordinal of the field inside the data record where the value is stored.</param>
        /// <returns>The value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="rec" /> is <see langword="null" />.
        /// </exception>
        public static T FromDbValue<T>(this IDataRecord rec, int ordinal)
        {
            if (rec == null)
            {
                throw new ArgumentNullException("rec");
            }

            return rec.IsDBNull(ordinal) ? default(T)
                                         : (T)rec.GetValue(ordinal);
        }

        #endregion Methods (2)
    }
}