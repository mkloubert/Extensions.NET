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
using System.Linq;

namespace MarcelJoachimKloubert.Extensions
{
    // Min()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (44)

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static sbyte Min(this sbyte value, IEnumerable<sbyte> others)
        {
            return new sbyte[] { value }.Concat(others)
                                        .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static sbyte Min(this sbyte value, params sbyte[] other)
        {
            return Min(value, (IEnumerable<sbyte>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static sbyte? Min(this sbyte? value, IEnumerable<sbyte?> others)
        {
            return new sbyte?[] { value }.Concat(others)
                                         .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static sbyte? Min(this sbyte? value, params sbyte?[] other)
        {
            return Min(value, (IEnumerable<sbyte?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static byte Min(this byte value, IEnumerable<byte> others)
        {
            return new byte[] { value }.Concat(others)
                                       .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static byte Min(this byte value, params byte[] other)
        {
            return Min(value, (IEnumerable<byte>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static byte? Min(this byte? value, IEnumerable<byte?> others)
        {
            return new byte?[] { value }.Concat(others)
                                        .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static byte? Min(this byte? value, params byte?[] other)
        {
            return Min(value, (IEnumerable<byte?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static short Min(this short value, IEnumerable<short> others)
        {
            return new short[] { value }.Concat(others)
                                        .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static short Min(this short value, params short[] other)
        {
            return Min(value, (IEnumerable<short>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static short? Min(this short? value, IEnumerable<short?> others)
        {
            return new short?[] { value }.Concat(others)
                                         .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static short? Min(this short? value, params short?[] other)
        {
            return Min(value, (IEnumerable<short?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static ushort Min(this ushort value, IEnumerable<ushort> others)
        {
            return new ushort[] { value }.Concat(others)
                                         .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static ushort Min(this ushort value, params ushort[] other)
        {
            return Min(value, (IEnumerable<ushort>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static ushort? Min(this ushort? value, IEnumerable<ushort?> others)
        {
            return new ushort?[] { value }.Concat(others)
                                          .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static ushort? Min(this ushort? value, params ushort?[] other)
        {
            return Min(value, (IEnumerable<ushort?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static int Min(this int value, IEnumerable<int> others)
        {
            return new int[] { value }.Concat(others)
                                      .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static int Min(this int value, params int[] other)
        {
            return Min(value, (IEnumerable<int>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static int? Min(this int? value, IEnumerable<int?> others)
        {
            return new int?[] { value }.Concat(others)
                                       .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static int? Min(this int? value, params int?[] other)
        {
            return Min(value, (IEnumerable<int?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static uint Min(this uint value, IEnumerable<uint> others)
        {
            return new uint[] { value }.Concat(others)
                                       .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static uint Min(this uint value, params uint[] other)
        {
            return Min(value, (IEnumerable<uint>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static uint? Min(this uint? value, IEnumerable<uint?> others)
        {
            return new uint?[] { value }.Concat(others)
                                        .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static uint? Min(this uint? value, params uint?[] other)
        {
            return Min(value, (IEnumerable<uint?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static long Min(this long value, IEnumerable<long> others)
        {
            return new long[] { value }.Concat(others)
                                       .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static long Min(this long value, params long[] other)
        {
            return Min(value, (IEnumerable<long>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static long? Min(this long? value, IEnumerable<long?> others)
        {
            return new long?[] { value }.Concat(others)
                                        .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static long? Min(this long? value, params long?[] other)
        {
            return Min(value, (IEnumerable<long?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static ulong Min(this ulong value, IEnumerable<ulong> others)
        {
            return new ulong[] { value }.Concat(others)
                                        .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static ulong Min(this ulong value, params ulong[] other)
        {
            return Min(value, (IEnumerable<ulong>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static ulong? Min(this ulong? value, IEnumerable<ulong?> others)
        {
            return new ulong?[] { value }.Concat(others)
                                         .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static ulong? Min(this ulong? value, params ulong?[] other)
        {
            return Min(value, (IEnumerable<ulong?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static float Min(this float value, IEnumerable<float> others)
        {
            return new float[] { value }.Concat(others)
                                        .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static float Min(this float value, params float[] other)
        {
            return Min(value, (IEnumerable<float>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static float? Min(this float? value, IEnumerable<float?> others)
        {
            return new float?[] { value }.Concat(others)
                                         .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static float? Min(this float? value, params float?[] other)
        {
            return Min(value, (IEnumerable<float?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static double Min(this double value, IEnumerable<double> others)
        {
            return new double[] { value }.Concat(others)
                                         .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static double Min(this double value, params double[] other)
        {
            return Min(value, (IEnumerable<double>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static double? Min(this double? value, IEnumerable<double?> others)
        {
            return new double?[] { value }.Concat(others)
                                          .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static double? Min(this double? value, params double?[] other)
        {
            return Min(value, (IEnumerable<double?>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static decimal Min(this decimal value, IEnumerable<decimal> others)
        {
            return new decimal[] { value }.Concat(others)
                                          .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static decimal Min(this decimal value, params decimal[] other)
        {
            return Min(value, (IEnumerable<decimal>)other);
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="others">The other values.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="others" /> is <see langword="null" />.
        /// </exception>
        public static decimal? Min(this decimal? value, IEnumerable<decimal?> others)
        {
            return new decimal?[] { value }.Concat(others)
                                           .Min();
        }

        /// <summary>
        /// Returns the minumum value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">One or more other value.</param>
        /// <returns>The minimum value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="other" /> is <see langword="null" />.
        /// </exception>
        public static decimal? Min(this decimal? value, params decimal?[] other)
        {
            return Min(value, (IEnumerable<decimal?>)other);
        }

        #endregion Methods (44)
    }
}