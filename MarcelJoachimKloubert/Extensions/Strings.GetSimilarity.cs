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
    // GetSimilarity()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (1)

        /// <summary>
        /// Calculates the similarity between that string and another.
        /// </summary>
        /// <param name="str">The current string.</param>
        /// <param name="other">The user string.</param>
        /// <param name="ignoreCase">Ignore case or not.</param>
        /// <param name="trim">Trim both strings or not.</param>
        /// <returns>
        /// A value that indicates the similarity (0 for 0% and 1 for 100%).
        /// </returns>
        public static double GetSimilarity(this string str, string other, bool ignoreCase = false, bool trim = false)
        {
            if (str == null && other == null)
            {
                return 1;
            }

            if (str == null ^ other == null)
            {
                return 0;
            }

            if (ignoreCase)
            {
                str = str.ToLower();
                other = other.ToLower();
            }

            if (trim)
            {
                str = str.Trim();
                other = other.Trim();
            }

            var distance = 0;

            // calculate levenstein distance
            if (str != other)
            {
                var matrix = new int[str.Length + 1, other.Length + 1];

                for (var i = 0; i <= str.Length; i++)
                {
                    // delete
                    matrix[i, 0] = i;
                }

                for (var j = 0; j <= other.Length; j++)
                {
                    // insert
                    matrix[0, j] = j;
                }

                for (var i = 0; i < str.Length; i++)
                {
                    for (var j = 0; j < other.Length; j++)
                    {
                        if (str[i] == other[j])
                        {
                            matrix[i + 1, j + 1] = matrix[i, j];
                        }
                        else
                        {
                            // delete or insert
                            matrix[i + 1, j + 1] = Math.Min(matrix[i, j + 1] + 1, matrix[i + 1, j] + 1);

                            // substitution
                            matrix[i + 1, j + 1] = Math.Min(matrix[i + 1, j + 1], matrix[i, j] + 1);
                        }
                    }
                }

                distance = matrix[str.Length, other.Length];
            }

            if (distance == 0)
            {
                return 1D;
            }

            var longestLen = (double)Math.Max(str.Length, other.Length);
            var percentage = (double)distance / longestLen;

            return 1D - percentage;
        }

        #endregion Methods (1)
    }
}