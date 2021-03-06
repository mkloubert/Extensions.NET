﻿/**********************************************************************************************************************
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
using System.IO;
using System.Linq;
using System.Xml;

namespace MarcelJoachimKloubert.Extensions
{
    // AsString()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (1)

        /// <summary>
        /// Returns an object as string.
        /// </summary>
        /// <param name="obj">The object to cast / convert.</param>
        /// <param name="dbNullAsNull">
        /// Handle <see cref="DBNull" /> as <see langword="null" /> reference or not.
        /// </param>
        /// <returns>
        /// <paramref name="obj" /> as string or <see langword="null" /> if <paramref name="obj" />
        /// is <see langword="null" /> or <see cref="DBNull" /> (<paramref name="dbNullAsNull" /> must
        /// be <see langword="true" /> in that case).
        /// </returns>
        public static string AsString(this object obj, bool dbNullAsNull = true)
        {
            if (obj is string)
            {
                return (string)obj;
            }

            if (dbNullAsNull && DBNull.Value.Equals(obj))
            {
                obj = null;
            }

            if (obj == null)
            {
                return null;
            }

            if (obj is IEnumerable<char>)
            {
                var charArray = obj as char[];
                if (charArray == null)
                {
                    charArray = ((IEnumerable<char>)obj).ToArray();
                }

                return new string(charArray);
            }

            if (obj is TextReader)
            {
                return ((TextReader)obj).ReadToEnd();
            }

            if (obj is XmlNode)
            {
                return ((XmlNode)obj).OuterXml;
            }

            if (obj is XmlReader)
            {
                return ((XmlReader)obj).ReadOuterXml();
            }

            return obj.ToString() ?? string.Empty;
        }

        #endregion Methods (1)
    }
}