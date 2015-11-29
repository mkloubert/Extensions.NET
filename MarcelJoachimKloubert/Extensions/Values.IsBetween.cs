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

namespace MarcelJoachimKloubert.Extensions
{
    // IsBetween()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (1)

        /// <summary>
        /// Checks if a value is between two others.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The inclusive minimum value.</param>
        /// <param name="max">The inclusive maximum value.</param>
        /// <returns>Is between or not.</returns>
        public static bool IsBetween<T>(this T value, T min, T max)
            where T : global::System.IComparable<T>, global::System.IComparable
        {
            if (value != null)
            {
                return value.CompareTo(min) >= 0 &&
                       value.CompareTo(max) <= 0;
            }

            if (min != null && max != null)
            {
                return min.CompareTo(value) <= 0 &&
                       max.CompareTo(value) >= 0;
            }

            if (!(min != null ^ max != null))
            {
                return false;
            }

            if (min != null)
            {
                return min.CompareTo(value) <= 0;
            }

            return max.CompareTo(value) >= 0;
        }

        #endregion Methods (1)
    }
}