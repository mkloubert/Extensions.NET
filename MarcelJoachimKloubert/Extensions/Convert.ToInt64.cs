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
using System.Globalization;

namespace MarcelJoachimKloubert.Extensions
{
    // ToInt64()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (1)

        /// <summary>
        /// Converts a string to a <see cref="long" />.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <param name="styles">The options.</param>
        /// <param name="provider">The custom provider to use.</param>
        /// <returns>
        /// The converted value or <see langword="null" /> if <paramref name="str" /> is
        /// <see langword="null" /> or contains whitespaces only.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="str" /> has an invalid format.
        /// </exception>
        /// <exception cref="OverflowException">
        /// <paramref name="str" /> represents a value that is too big.
        /// </exception>
        public static long? ToInt64(this string str,
                                    NumberStyles styles = NumberStyles.Integer, IFormatProvider provider = null)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            return provider == null ? long.Parse(str, styles)
                                    : long.Parse(str, styles, provider);
        }

        #endregion Methods (1)
    }
}