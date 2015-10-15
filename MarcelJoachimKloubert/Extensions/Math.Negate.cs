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
    // Negate()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (14)

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static sbyte Negate(this sbyte value)
        {
            return (sbyte)-value;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static sbyte? Negate(this sbyte? value)
        {
            return value.HasValue ? Negate(value.Value) : (sbyte?)null;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static short Negate(this short value)
        {
            return (short)-value;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static short? Negate(this short? value)
        {
            return value.HasValue ? Negate(value.Value) : (short?)null;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static int Negate(this int value)
        {
            return (int)-value;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static int? Negate(this int? value)
        {
            return value.HasValue ? Negate(value.Value) : (int?)null;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static long Negate(this long value)
        {
            return (long)-value;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static long? Negate(this long? value)
        {
            return value.HasValue ? Negate(value.Value) : (long?)null;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static float Negate(this float value)
        {
            return value * -1f;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static float? Negate(this float? value)
        {
            return value.HasValue ? Negate(value.Value) : (float?)null;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static double Negate(this double value)
        {
            return value * -1d;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static double? Negate(this double? value)
        {
            return value.HasValue ? Negate(value.Value) : (double?)null;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static decimal Negate(this decimal value)
        {
            return value * -1m;
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static decimal? Negate(this decimal? value)
        {
            return value.HasValue ? Negate(value.Value) : (decimal?)null;
        }

        #endregion Methods (14)
    }
}