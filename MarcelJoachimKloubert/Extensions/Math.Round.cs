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
    // Extension methods for mathematic operations.
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (4)

        /// <summary>
        /// Rounds a value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns>The output value.</returns>
        public static double Round(this double value, int digits = 0)
        {
            return Math.Round(value, digits);
        }

        /// <summary>
        /// Rounds a value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static double? Round(this double? value, int digits = 0)
        {
            return value.HasValue ? Round(value.Value, digits) : (double?)null;
        }

        /// <summary>
        /// Rounds a value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>The output value.</returns>
        public static decimal Round(this decimal value, int decimals = 0)
        {
            return Math.Round(value, decimals);
        }

        /// <summary>
        /// Rounds a value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static decimal? Round(this decimal? value, int decimals = 0)
        {
            return value.HasValue ? Round(value.Value, decimals) : (decimal?)null;
        }

        #endregion Methods (4)
    }
}