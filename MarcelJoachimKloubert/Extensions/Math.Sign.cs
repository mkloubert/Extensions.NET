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
    // Sign()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (14)

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign.</returns>
        public static NumberSign Sign(this sbyte value)
        {
            if (value == 0)
            {
                return NumberSign.Zero;
            }

            return value > 0 ? NumberSign.Positive : NumberSign.Negative;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign or <see langword="null" /> if <paramref name="value" /> is <see langword="null" />.</returns>
        public static NumberSign? Sign(this sbyte? value)
        {
            return value.HasValue ? Sign(value.Value) : (NumberSign?)null;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign.</returns>
        public static NumberSign Sign(this short value)
        {
            if (value == 0)
            {
                return NumberSign.Zero;
            }

            return value > 0 ? NumberSign.Positive : NumberSign.Negative;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign or <see langword="null" /> if <paramref name="value" /> is <see langword="null" />.</returns>
        public static NumberSign? Sign(this short? value)
        {
            return value.HasValue ? Sign(value.Value) : (NumberSign?)null;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign.</returns>
        public static NumberSign Sign(this int value)
        {
            if (value == 0)
            {
                return NumberSign.Zero;
            }

            return value > 0 ? NumberSign.Positive : NumberSign.Negative;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign or <see langword="null" /> if <paramref name="value" /> is <see langword="null" />.</returns>
        public static NumberSign? Sign(this int? value)
        {
            return value.HasValue ? Sign(value.Value) : (NumberSign?)null;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign.</returns>
        public static NumberSign Sign(this long value)
        {
            if (value == 0)
            {
                return NumberSign.Zero;
            }

            return value > 0 ? NumberSign.Positive : NumberSign.Negative;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign or <see langword="null" /> if <paramref name="value" /> is <see langword="null" />.</returns>
        public static NumberSign? Sign(this long? value)
        {
            return value.HasValue ? Sign(value.Value) : (NumberSign?)null;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign.</returns>
        public static NumberSign Sign(this float value)
        {
            if (value == 0f)
            {
                return NumberSign.Zero;
            }

            if (float.IsNegativeInfinity(value))
            {
                return NumberSign.NegativeInfinity;
            }

            if (float.IsPositiveInfinity(value))
            {
                return NumberSign.PositiveInfinity;
            }

            return value > 0f ? NumberSign.Positive : NumberSign.Negative;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign or <see langword="null" /> if <paramref name="value" /> is <see langword="null" />.</returns>
        public static NumberSign? Sign(this float? value)
        {
            return value.HasValue ? Sign(value.Value) : (NumberSign?)null;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign.</returns>
        public static NumberSign Sign(this double value)
        {
            if (value == 0d)
            {
                return NumberSign.Zero;
            }

            if (double.IsNegativeInfinity(value))
            {
                return NumberSign.NegativeInfinity;
            }

            if (double.IsPositiveInfinity(value))
            {
                return NumberSign.PositiveInfinity;
            }

            return value > 0d ? NumberSign.Positive : NumberSign.Negative;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign or <see langword="null" /> if <paramref name="value" /> is <see langword="null" />.</returns>
        public static NumberSign? Sign(this double? value)
        {
            return value.HasValue ? Sign(value.Value) : (NumberSign?)null;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign.</returns>
        public static NumberSign Sign(this decimal value)
        {
            if (value == decimal.Zero)
            {
                return NumberSign.Zero;
            }

            return value > 0m ? NumberSign.Positive : NumberSign.Negative;
        }

        /// <summary>
        /// Returns the sign of a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>The sign or <see langword="null" /> if <paramref name="value" /> is <see langword="null" />.</returns>
        public static NumberSign? Sign(this decimal? value)
        {
            return value.HasValue ? Sign(value.Value) : (NumberSign?)null;
        }

        #endregion Methods (14)
    }
}