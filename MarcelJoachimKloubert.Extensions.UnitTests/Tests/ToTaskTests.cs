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

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarcelJoachimKloubert.Extensions.UnitTests.Tests
{
    /// <summary>
    /// Tests for ToTask() extension method.
    /// </summary>
    public class ToTaskTests : TestFixtureBase
    {
        #region Methods (2)

        [Test]
        public void TestActions()
        {
            int? expectedValue = null;

            var actionsToTest = new Dictionary<Task, int>()
            {
                { new Action(() => expectedValue = 1).ToTask(), 1 },
                { new Action<int>((a) => expectedValue = a + 1).ToTask(2), 3 },
                { new Action<int, int>((a, b) => expectedValue = a + b + 1).ToTask(2, 3), 6 },
                { new Action<int, int, int>((a, b, c) => expectedValue = a + b + c + 1).ToTask(2, 3, 4), 10 },
                { new Action<int, int, int, int>((a, b, c, d) => expectedValue = a + b + c + d + 1).ToTask(2, 3, 4, 5), 15 },
                { new Action<int, int, int, int, int>((a, b, c, d, e) => expectedValue = a + b + c + d + e + 1).ToTask(2, 3, 4, 5, 6), 21 },
                { new Action<int, int, int, int, int, int>((a, b, c, d, e, f) => expectedValue = a + b + c + d + e + f + 1).ToTask(2, 3, 4, 5, 6, 7), 28 },
                { new Action<int, int, int, int, int, int, int>((a, b, c, d, e, f, g) => expectedValue = a + b + c + d + e + f + g + 1).ToTask(2, 3, 4, 5, 6, 7, 8), 36 },
                { new Action<int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h) => expectedValue = a + b + c + d + e + f + g + h + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9), 45 },
                { new Action<int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i) => expectedValue = a + b + c + d + e + f + g + h + i + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10), 55 },
                { new Action<int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j) => expectedValue = a + b + c + d + e + f + g + h + i + j + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11), 66 },
                { new Action<int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k) => expectedValue = a + b + c + d + e + f + g + h + i + j + k + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12), 78 },
                { new Action<int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l) => expectedValue = a + b + c + d + e + f + g + h + i + j + k + l + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13), 91 },
                { new Action<int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m) => expectedValue = a + b + c + d + e + f + g + h + i + j + k + l + m + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14), 105 },
                { new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m, n) => expectedValue = a + b + c + d + e + f + g + h + i + j + k + l + m + n + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15), 120 },
                { new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => expectedValue = a + b + c + d + e + f + g + h + i + j + k + l + m + n + o + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16), 136 },
                { new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => expectedValue = a + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17), 153 },
            };

            foreach (var item in actionsToTest)
            {
                expectedValue = null;

                var task = item.Key;
                var ev = item.Value;

                task.Start();
                task.Wait();

                Assert.NotNull(expectedValue);
                Assert.AreEqual(expectedValue.Value, ev);
            }
        }

        [Test]
        public void TestFuncs()
        {
            var actionsToTest = new Dictionary<Task<int>, int>()
            {
                { new Func<int>(() => 1).ToTask(), 1 },
                { new Func<int, int>((a) => a + 1).ToTask(2), 3 },
                { new Func<int, int, int>((a, b) => a + b + 1).ToTask(2, 3), 6 },
                { new Func<int, int, int, int>((a, b, c) => a + b + c + 1).ToTask(2, 3, 4), 10 },
                { new Func<int, int, int, int, int>((a, b, c, d) => a + b + c + d + 1).ToTask(2, 3, 4, 5), 15 },
                { new Func<int, int, int, int, int, int>((a, b, c, d, e) => a + b + c + d + e + 1).ToTask(2, 3, 4, 5, 6), 21 },
                { new Func<int, int, int, int, int, int, int>((a, b, c, d, e, f) => a + b + c + d + e + f + 1).ToTask(2, 3, 4, 5, 6, 7), 28 },
                { new Func<int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g) => a + b + c + d + e + f + g + 1).ToTask(2, 3, 4, 5, 6, 7, 8), 36 },
                { new Func<int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h) => a + b + c + d + e + f + g + h + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9), 45 },
                { new Func<int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i) => a + b + c + d + e + f + g + h + i + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10), 55 },
                { new Func<int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j) => a + b + c + d + e + f + g + h + i + j + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11), 66 },
                { new Func<int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k) => a + b + c + d + e + f + g + h + i + j + k + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12), 78 },
                { new Func<int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l) => a + b + c + d + e + f + g + h + i + j + k + l + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13), 91 },
                { new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m) => a + b + c + d + e + f + g + h + i + j + k + l + m + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14), 105 },
                { new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m, n) => a + b + c + d + e + f + g + h + i + j + k + l + m + n + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15), 120 },
                { new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => a + b + c + d + e + f + g + h + i + j + k + l + m + n + o + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16), 136 },
                { new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>((a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => a + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + 1).ToTask(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17), 153 },
            };

            foreach (var item in actionsToTest)
            {
                var task = item.Key;
                var ev = item.Value;

                task.Start();
                task.Wait();

                var expectedValue = task.Result;

                Assert.IsFalse(task.IsFaulted);
                Assert.AreEqual(expectedValue, ev);
            }
        }

        #endregion Methods (2)
    }
}