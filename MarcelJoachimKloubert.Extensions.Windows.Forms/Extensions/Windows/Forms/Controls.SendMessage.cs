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
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MarcelJoachimKloubert.Extensions.Windows.Forms
{
    // SendMessage()
    static partial class MJKWinFormsExtensionMethods
    {
        #region Methods (4)

        /// <summary>
        /// <see cref="Control.DefWndProc(ref Message)" />
        /// </summary>
        public static void SendMessage(this Control ctrl, ref Message msg)
        {
            if (ctrl == null)
            {
                throw new ArgumentNullException("ctrl");
            }

            var msgTypeRef = typeof(Message).MakeByRefType();

            // find 'Control.DefWndProc(ref Message)' method
            var defWndProcMethod = ctrl.GetType()
                                       .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                       .First(m =>
                                            {
                                                if (m.Name != "DefWndProc")
                                                {
                                                    return false;
                                                }

                                                var p = m.GetParameters();
                                                return (p.Length == 1) &&
                                                       (msgTypeRef == p[0].ParameterType);
                                            });

            var @params = new object[] { msg };
            defWndProcMethod.Invoke(ctrl, @params);

            msg = (Message)@params[0];
        }

        /// <summary>
        /// <see cref="Control.DefWndProc(ref Message)" />
        /// </summary>
        public static Message SendMessage(this Control ctrl, IntPtr hWnd, int msg, int wparam, int lparam)
        {
            return SendMessage(ctrl, hWnd, msg, (IntPtr)wparam, (IntPtr)lparam);
        }

        /// <summary>
        /// <see cref="Control.DefWndProc(ref Message)" />
        /// </summary>
        public static Message SendMessage(this Control ctrl, int hWnd, int msg, int wparam, int lparam)
        {
            return SendMessage(ctrl, (IntPtr)hWnd, msg, (IntPtr)wparam, (IntPtr)lparam);
        }

        /// <summary>
        /// <see cref="Control.DefWndProc(ref Message)" />
        /// </summary>
        public static Message SendMessage(this Control ctrl, IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            var result = Message.Create(hWnd, msg, wparam, lparam);
            SendMessage(ctrl, ref result);

            return result;
        }

        #endregion Methods (4)
    }
}