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
    // Shuffle()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (1)

        /// <summary>
        /// Swaps the elements in a list in random order.
        /// </summary>
        /// <typeparam name="T">Type of the elements of <paramref name="list" />.</typeparam>
        /// <param name="list">The list that should be shuffled.</param>
        /// <param name="rand">The custom random number generator to use.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="list" /> and/or <paramref name="rand" /> is <see langword="null" />.
        /// </exception>
        public static void Shuffle<T>(this IList<T> list, Random rand = null)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            rand = rand ?? new Random();

            var itemCount = list.Count;
            for (var i = 0; i < itemCount; i++)
            {
                var newIdx = rand.Next(0, itemCount);
                var temp = list[i];

                list[i] = list[newIdx];
                list[newIdx] = temp;
            }
        }

        #endregion Methods (1)
    }
}