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
using System.Drawing;
using System.Reflection;

namespace MarcelJoachimKloubert.Extensions.Drawing
{
    // GetManifestResourceImage()
    static partial class MJKDrawingExtensionMethods
    {
        #region Methods (3)

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as a bitmap.
        /// </summary>
        /// <typeparam name="T">The type that is used for the namespace of the resource.</typeparam>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <returns>The image or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> is <see langword="null" />.
        /// </exception>
        public static Image GetManifestResourceImage<T>(this Assembly asm, string name)
        {
            return GetManifestResourceImage(asm: asm,
                                            type: typeof(T),
                                            name: name);
        }

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as a bitmap.
        /// </summary>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <returns>The image or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> is <see langword="null" />.
        /// </exception>
        public static Image GetManifestResourceImage(this Assembly asm, string name)
        {
            if (asm == null)
            {
                throw new ArgumentNullException("asm");
            }

            var stream = asm.GetManifestResourceStream(name);
            if (stream == null)
            {
                return null;
            }

            using (stream)
            {
                return Image.FromStream(stream);
            }
        }

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as a bitmap.
        /// </summary>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="type">The type that is used for the namespace of the resource.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <returns>The image or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> and/or <paramref name="type" /> are <see langword="null" />.
        /// </exception>
        public static Image GetManifestResourceImage(this Assembly asm, Type type, string name)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var ns = type.Namespace;
            name = string.IsNullOrEmpty(ns) ? name
                                            : string.Format("{0}.{1}",
                                                            ns, name);

            return GetManifestResourceImage(asm: asm,
                                            name: name);
        }

        #endregion Methods (3)
    }
}