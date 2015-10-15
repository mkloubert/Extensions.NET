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
    // Abs()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (14)

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="sbyte.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="sbyte.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static sbyte Abs(this sbyte value, Func<sbyte, sbyte> onOverflow = null)
        {
            try
            {
                return Math.Abs(value);
            }
            catch (OverflowException ofex)
            {
                if (onOverflow == null)
                {
                    throw ofex;
                }

                return onOverflow(value);
            }
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="sbyte.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="sbyte.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static sbyte? Abs(this sbyte? value, Func<sbyte, sbyte?> onOverflow = null)
        {
            return value.HasValue ? Abs(value.Value, onOverflow)
                                  : (sbyte?)null;
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="short.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="short.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static short Abs(this short value, Func<short, short> onOverflow = null)
        {
            try
            {
                return Math.Abs(value);
            }
            catch (OverflowException ofex)
            {
                if (onOverflow == null)
                {
                    throw ofex;
                }

                return onOverflow(value);
            }
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="short.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="short.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static short? Abs(this short? value, Func<short, short?> onOverflow = null)
        {
            return value.HasValue ? Abs(value.Value, onOverflow)
                                  : (short?)null;
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="int.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="int.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static int Abs(this int value, Func<int, int> onOverflow = null)
        {
            try
            {
                return Math.Abs(value);
            }
            catch (OverflowException ofex)
            {
                if (onOverflow == null)
                {
                    throw ofex;
                }

                return onOverflow(value);
            }
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="int.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="int.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static int? Abs(this int? value, Func<int, int?> onOverflow = null)
        {
            return value.HasValue ? Abs(value.Value, onOverflow)
                                  : (int?)null;
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="long.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="long.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static long Abs(this long value, Func<long, long> onOverflow = null)
        {
            try
            {
                return Math.Abs(value);
            }
            catch (OverflowException ofex)
            {
                if (onOverflow == null)
                {
                    throw ofex;
                }

                return onOverflow(value);
            }
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="onOverflow">
        /// If defined, this is invoked if <paramref name="value" /> is <see cref="long.MinValue" /> and the
        /// return of this function is the result value of that method;
        /// otherwise an <see cref="OverflowException" /> is thrown.
        /// </param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        /// <exception cref="OverflowException">
        /// <paramref name="value" /> is <see cref="long.MinValue" /> and
        /// <paramref name="onOverflow" /> is <see langword="null" />.
        /// </exception>
        public static long? Abs(this long? value, Func<long, long?> onOverflow = null)
        {
            return value.HasValue ? Abs(value.Value, onOverflow)
                                  : (long?)null;
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static float Abs(this float value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static float? Abs(this float? value)
        {
            return value.HasValue ? Abs(value.Value) : (float?)null;
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static double Abs(this double value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static double? Abs(this double? value)
        {
            return value.HasValue ? Abs(value.Value) : (double?)null;
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value.</returns>
        public static decimal Abs(this decimal value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value for a value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The output value or <see langword="null" /> if <paramref name="value" />
        /// is <see langword="null" />.</returns>
        public static decimal? Abs(this decimal? value)
        {
            return value.HasValue ? Abs(value.Value) : (decimal?)null;
        }

        #endregion Methods (14)
    }
}