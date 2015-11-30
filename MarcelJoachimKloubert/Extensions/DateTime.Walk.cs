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
    // Walk()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (12)

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific count of ticks.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="stepInTicks">The number of ticks to walk.</param>
        /// <returns>The sequence of values.</returns>
        public static IEnumerable<DateTimeOffset> Walk(this DateTimeOffset value, long stepInTicks)
        {
            return Walk(value,
                        tickProvider: (cv) => stepInTicks);
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific step.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="step">The step to walk.</param>
        /// <returns>The sequence of values.</returns>
        public static IEnumerable<DateTimeOffset> Walk(this DateTimeOffset value, TimeSpan step)
        {
            return Walk(value: value,
                        stepProvider: (cv) => step);
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific step.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="tickProvider">The function to provides the number of ticks to walk.</param>
        /// <returns>The sequence of values.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tickProvider" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<DateTimeOffset> Walk(this DateTimeOffset value, Func<DateTimeOffset, long> tickProvider)
        {
            if (tickProvider == null)
            {
                throw new ArgumentNullException("tickProvider");
            }

            if (tickProvider == null)
            {
                throw new ArgumentNullException("tickProvider");
            }

            return Walk(value: value,
                        stepProvider: (cv) => TimeSpan.FromTicks(tickProvider(cv)));
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific step.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="stepProvider">The function that provides the step to walk.</param>
        /// <returns>The sequence of values.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stepProvider" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<DateTimeOffset> Walk(this DateTimeOffset value, Func<DateTimeOffset, TimeSpan> stepProvider)
        {
            if (stepProvider == null)
            {
                throw new ArgumentNullException("stepProvider");
            }

            var currentValue = value;
            while (true)
            {
                yield return currentValue;

                var step = stepProvider(currentValue);
                try
                {
                    currentValue = value.Add(step);
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific count of ticks.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="stepInTicks">The number of ticks to walk.</param>
        /// <returns>The sequence of values.</returns>
        public static IEnumerable<DateTime> Walk(this DateTime value, long stepInTicks)
        {
            return Walk(value,
                        tickProvider: (cv) => stepInTicks);
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific step.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="step">The step to walk.</param>
        /// <returns>The sequence of values.</returns>
        public static IEnumerable<DateTime> Walk(this DateTime value, TimeSpan step)
        {
            return Walk(value: value,
                        stepProvider: (cv) => step);
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific count of ticks.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="tickProvider">The function to provides the number of ticks to walk.</param>
        /// <returns>The sequence of values.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tickProvider" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<DateTime> Walk(this DateTime value, Func<DateTime, long> tickProvider)
        {
            if (tickProvider == null)
            {
                throw new ArgumentNullException("tickProvider");
            }

            return Walk(value: value,
                        stepProvider: (cv) => TimeSpan.FromTicks(tickProvider(cv)));
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific step.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="stepProvider">The function that provides the step to walk.</param>
        /// <returns>The sequence of values.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stepProvider" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<DateTime> Walk(this DateTime value, Func<DateTime, TimeSpan> stepProvider)
        {
            if (stepProvider == null)
            {
                throw new ArgumentNullException("stepProvider");
            }

            var currentValue = value;
            while (true)
            {
                yield return currentValue;

                var step = stepProvider(currentValue);
                try
                {
                    currentValue = value.Add(step);
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific count of ticks.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="stepInTicks">The number of ticks to walk.</param>
        /// <returns>The sequence of values.</returns>
        public static IEnumerable<TimeSpan> Walk(this TimeSpan value, long stepInTicks)
        {
            return Walk(value,
                        tickProvider: (cv) => stepInTicks);
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific step.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="step">The step to walk.</param>
        /// <returns>The sequence of values.</returns>
        public static IEnumerable<TimeSpan> Walk(this TimeSpan value, TimeSpan step)
        {
            return Walk(value: value,
                        stepProvider: (cv) => step);
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific count of ticks.
        /// </summary>
        /// /// <param name="value">The beginning value.</param>
        /// <param name="tickProvider">The function to provides the number of ticks to walk.</param>
        /// <returns>The sequence of values.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tickProvider" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TimeSpan> Walk(this TimeSpan value, Func<TimeSpan, long> tickProvider)
        {
            if (tickProvider == null)
            {
                throw new ArgumentNullException("tickProvider");
            }

            return Walk(value: value,
                        stepProvider: (cv) => TimeSpan.FromTicks(tickProvider(cv)));
        }

        /// <summary>
        /// Walks from the beginning of <paramref name="value" /> with a specific step.
        /// </summary>
        /// <param name="value">The beginning value.</param>
        /// <param name="stepProvider">The function that provides the step to walk.</param>
        /// <returns>The sequence of values.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stepProvider" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TimeSpan> Walk(this TimeSpan value, Func<TimeSpan, TimeSpan> stepProvider)
        {
            if (stepProvider == null)
            {
                throw new ArgumentNullException("stepProvider");
            }

            var currentValue = value;
            while (true)
            {
                yield return currentValue;

                var step = stepProvider(currentValue);
                try
                {
                    currentValue = value.Add(step);
                }
                catch (OverflowException)
                {
                    break;
                }
            }
        }

        #endregion Methods (12)
    }
}