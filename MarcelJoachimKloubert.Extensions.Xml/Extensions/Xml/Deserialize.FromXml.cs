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
using System.Xml;
using System.Xml.Serialization;

namespace MarcelJoachimKloubert.Extensions.Xml
{
    // FromXml
    static partial class MJKXmlExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Deserializes XML data to an object.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="xml">The XML data.</param>
        /// <returns>The deserialized object.</returns>
        public static TTarget FromXml<TTarget>(this string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return default(TTarget);
            }

            using (var reader = new StringReader(xml))
            {
                return FromXml<TTarget>(reader);
            }
        }

        /// <summary>
        /// Deserializes XML data to an object.
        /// </summary>
        /// <param name="xml">The XML data.</param>
        /// <param name="targetType">The target type.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="targetType" /> is <see langword="null" />.
        /// </exception>
        public static object FromXml(this string xml, Type targetType)
        {
            if (targetType == null)
            {
                throw new ArgumentNullException("targetType");
            }

            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            using (var reader = new StringReader(xml))
            {
                return FromXml(reader, targetType);
            }
        }

        /// <summary>
        /// Deserializes XML data to an object.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="reader">The reader that contains the data.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> is <see langword="null" />.
        /// </exception>
        public static TTarget FromXml<TTarget>(this TextReader reader)
        {
            return (TTarget)FromXml(reader, typeof(TTarget));
        }

        /// <summary>
        /// Deserializes XML data to an object.
        /// </summary>
        /// <param name="reader">The reader that contains the data.</param>
        /// <param name="targetType">The target type.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reader" /> is <see langword="null" />.
        /// </exception>
        public static object FromXml(this TextReader reader, Type targetType)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            if (targetType == null)
            {
                throw new ArgumentNullException("targetType");
            }

            return new XmlSerializer(targetType).Deserialize(reader);
        }

        /// <summary>
        /// Deserializes XML data to an object.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="xmlReader">The reader that contains the data.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="xmlReader" /> is <see langword="null" />.
        /// </exception>
        public static TTarget FromXml<TTarget>(this XmlReader xmlReader)
        {
            return (TTarget)FromXml(xmlReader, typeof(TTarget));
        }

        /// <summary>
        /// Deserializes XML data to an object.
        /// </summary>
        /// <param name="xmlReader">The reader that contains the data.</param>
        /// <param name="targetType">The target type.</param>
        /// <returns>The deserialized object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="xmlReader" /> is <see langword="null" />.
        /// </exception>
        public static object FromXml(this XmlReader xmlReader, Type targetType)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException("xmlReader");
            }

            if (targetType == null)
            {
                throw new ArgumentNullException("targetType");
            }

            return new XmlSerializer(targetType).Deserialize(xmlReader);
        }

        #endregion Methods
    }
}