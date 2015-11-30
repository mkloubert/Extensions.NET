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

using System.Drawing;
using System.Drawing.Imaging;

namespace MarcelJoachimKloubert.Extensions.Drawing
{
    // Grayscale()
    static partial class MJKDrawingExtensionMethods
    {
        #region Methods (1)

        /// <summary>
        /// Converts a <see cref="Bitmap" /> to its grayscale version.
        /// </summary>
        /// <param name="input">The input bitmap.</param>
        /// <returns>The converted bitmap or <see langword="null" /> if <paramref name="input" /> is also <see langword="null" />.</returns>
        public static Bitmap Grayscale(this Bitmap input)
        {
            if (input == null)
            {
                return null;
            }

            var result = new Bitmap(input.Width, input.Height);
            try
            {
                using (var g = Graphics.FromImage(result))
                {
                    var colorMatrix = new ColorMatrix(new float[][]
                    {
                       new float[] { .3f, .3f, .3f, 0, 0 },
                       new float[] { .59f, .59f, .59f, 0, 0 },
                       new float[] { .11f, .11f, .11f, 0, 0 },
                       new float[] { 0, 0, 0, 1, 0 },
                       new float[] { 0, 0, 0, 0, 1 },
                    });

                    using (var attributes = new ImageAttributes())
                    {
                        attributes.SetColorMatrix(colorMatrix);

                        g.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height),
                                    0, 0, input.Width, input.Height, GraphicsUnit.Pixel, attributes);
                    }
                }
            }
            catch
            {
                result.Dispose();

                throw;
            }

            return result;
        }

        #endregion Methods (1)
    }
}