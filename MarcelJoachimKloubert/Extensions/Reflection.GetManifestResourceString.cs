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
using System.IO;
using System.Reflection;
using System.Text;

namespace MarcelJoachimKloubert.Extensions
{
    // GetManifestResourceString()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (6)

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as an UTF-8 string.
        /// </summary>
        /// <typeparam name="T">The type that is used for the namespace of the resource.</typeparam>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <returns>The string or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> is <see langword="null" />.
        /// </exception>
        public static string GetManifestResourceString<T>(this Assembly asm, string name)
        {
            return GetManifestResourceString<T>(asm: asm,
                                                name: name,
                                                enc: Encoding.UTF8);
        }

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as a string.
        /// </summary>
        /// <typeparam name="T">The type that is used for the namespace of the resource.</typeparam>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <param name="enc">The charset to use.</param>
        /// <returns>The string or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> and/or <paramref name="enc" /> are <see langword="null" />.
        /// </exception>
        public static string GetManifestResourceString<T>(this Assembly asm, string name, Encoding enc)
        {
            return GetManifestResourceString(asm: asm,
                                             type: typeof(T),
                                             name: name,
                                             enc: enc);
        }

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as an UTF-8 string.
        /// </summary>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <returns>The string or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> is <see langword="null" />.
        /// </exception>
        public static string GetManifestResourceString(this Assembly asm, string name)
        {
            return GetManifestResourceString(asm: asm,
                                             name: name,
                                             enc: Encoding.UTF8);
        }

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as a string.
        /// </summary>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <param name="enc">The charset to use.</param>
        /// <returns>The string or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> and/or <paramref name="enc" /> are <see langword="null" />.
        /// </exception>
        public static string GetManifestResourceString(this Assembly asm, string name, Encoding enc)
        {
            if (asm == null)
            {
                throw new ArgumentNullException("asm");
            }

            if (enc == null)
            {
                throw new ArgumentNullException("enc");
            }

            var stream = asm.GetManifestResourceStream(name);
            if (stream == null)
            {
                return null;
            }

            using (stream)
            {
                using (var temp = new MemoryStream())
                {
                    stream.CopyTo(temp);

                    return enc.GetString(temp.ToArray(), 0, (int)temp.Length);
                }
            }
        }

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as an UTF-8 string.
        /// </summary>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="type">The type that is used for the namespace of the resource.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <returns>The string or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" /> is <see langword="null" />.
        /// </exception>
        public static string GetManifestResourceString(this Assembly asm, Type type, string name)
        {
            return GetManifestResourceString(asm: asm,
                                             type: type,
                                             name: name,
                                             enc: Encoding.UTF8);
        }

        /// <summary>
        /// Returns an embedded resource inside an <see cref="Assembly" /> as a string.
        /// </summary>
        /// <param name="asm">The assembly where the resource is stored.</param>
        /// <param name="type">The type that is used for the namespace of the resource.</param>
        /// <param name="name">The name / relative path of the resource.</param>
        /// <param name="enc">The charset to use.</param>
        /// <returns>The string or <see langword="null" /> if not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="asm" />, <paramref name="type" /> and/or <paramref name="enc" /> are <see langword="null" />.
        /// </exception>
        public static string GetManifestResourceString(this Assembly asm, Type type, string name, Encoding enc)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var ns = type.Namespace;
            name = string.IsNullOrEmpty(ns) ? name
                                            : string.Format("{0}.{1}",
                                                            ns, name);

            return GetManifestResourceString(asm: asm, name: name,
                                             enc: enc);
        }

        #endregion Methods (6)
    }
}