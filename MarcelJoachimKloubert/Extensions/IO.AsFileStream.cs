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

namespace MarcelJoachimKloubert.Extensions
{
    // AsFileStream()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Returns a <see cref="Stream" /> as a <see cref="FileStream" />.
        /// </summary>
        /// <param name="stream">The stream to cast / convert.</param>
        /// <param name="moveToBeginning">Move cursor of result stream to beginning or not.</param>
        /// <returns>The result stream.</returns>
        /// <remarks>
        /// <see langword="null" /> is returned if <paramref name="stream" /> is also <see langword="null" />.
        /// </remarks>
        /// <remarks>
        /// If <paramref name="stream" /> is already a file stream it is simply casted; otherwise a temprary file
        /// with <see cref="FileAccess.ReadWrite" /> access is created.
        /// </remarks>
        public static FileStream AsFileStream(this Stream stream, bool moveToBeginning = false)
        {
            var result = stream as FileStream;

            if (result == null && stream != null)
            {
                result = new FileStream(path: Path.GetTempFileName(),
                                        mode: FileMode.Create, access: FileAccess.ReadWrite);
                try
                {
                    stream.CopyTo(result);

                    result.Flush();
                }
                catch (Exception)
                {
                    result.Dispose();
                    try
                    {
                        File.Delete(result.Name);
                    }
                    catch
                    {
                        // ignore
                    }

                    throw;
                }
            }

            if (result != null)
            {
                if (moveToBeginning)
                {
                    result.Position = 0;
                }
            }

            return result;
        }

        #endregion Methods
    }
}