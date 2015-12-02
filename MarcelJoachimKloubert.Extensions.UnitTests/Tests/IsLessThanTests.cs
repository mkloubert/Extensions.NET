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

namespace MarcelJoachimKloubert.Extensions.UnitTests.Tests
{
    /// <summary>
    /// Tests for IsLessThan() extension method.
    /// </summary>
    public class IsLessThanTests : TestFixtureBase
    {
        #region Methods (8)

        [Test]
        public void TestByte()
        {
            byte a = 3;
            byte b = 2;
            byte c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        [Test]
        public void TestSByte()
        {
            sbyte a = 3;
            sbyte b = 2;
            sbyte c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        [Test]
        public void TestInt16()
        {
            short a = 3;
            short b = 2;
            short c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        [Test]
        public void TestUInt16()
        {
            ushort a = 3;
            ushort b = 2;
            ushort c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        [Test]
        public void TestInt32()
        {
            int a = 3;
            int b = 2;
            int c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        [Test]
        public void TestUInt32()
        {
            uint a = 3;
            uint b = 2;
            uint c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        [Test]
        public void TestInt64()
        {
            long a = 3;
            long b = 2;
            long c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        [Test]
        public void TestUInt64()
        {
            ulong a = 3;
            ulong b = 2;
            ulong c = 3;

            Assert.IsFalse(a.IsLessThan(b));
            Assert.IsTrue(b.IsLessThan(a));
            Assert.IsTrue(b.IsLessThan(c));
            Assert.IsFalse(a.IsLessThan(c));
        }

        #endregion Methods (8)
    }
}