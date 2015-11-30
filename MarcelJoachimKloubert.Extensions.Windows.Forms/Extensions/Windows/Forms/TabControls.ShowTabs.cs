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
using System.Windows.Forms;

namespace MarcelJoachimKloubert.Extensions.Windows.Forms
{
    // ShowTabs()
    static partial class MJKWinFormsExtensionMethods
    {
        #region Methods (1)

        /// <summary>
        /// Shows / restores the tabs of a <see cref="TabControl" />.
        /// </summary>
        /// <param name="tabCtrl">The control.</param>
        public static void ShowTabs(this TabControl tabCtrl)
        {
            if (tabCtrl == null)
            {
                throw new ArgumentNullException("tabCtrl");
            }

            TabAppearance appearance;
            Size tabSize;
            TabSizeMode sizeMode;
            lock (_HIDE_SHOW_TABS)
            {
                object[] data;
                if (!_HIDE_SHOW_TABS.TryGetValue(tabCtrl, out data))
                {
                    // no backup => nothing more to do here
                    return;
                }

                appearance = (TabAppearance)data[0];
                tabSize = (Size)data[1];
                sizeMode = (TabSizeMode)data[2];
            }

            tabCtrl.Appearance = appearance;
            tabCtrl.ItemSize = tabSize;
            tabCtrl.SizeMode = sizeMode;
        }

        #endregion Methods (1)
    }
}