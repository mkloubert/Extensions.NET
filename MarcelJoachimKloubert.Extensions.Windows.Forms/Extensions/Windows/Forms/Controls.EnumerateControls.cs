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
using System.Linq;
using System.Windows.Forms;

namespace MarcelJoachimKloubert.Extensions.Windows.Forms
{
    // EnumerateControls()
    static partial class MJKWinFormsExtensionMethods
    {
        #region Methods (4)

        /// <summary>
        /// Returns a sequence of controls of a specific type from the collection of a control.
        /// </summary>
        /// <param name="ctrl">The underlying control.</param>
        /// <returns>The child controls of <paramref name="ctrl" />.</returns>
        /// <exception cref="NullReferenceException">
        /// <paramref name="ctrl" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<Control> EnumerateControls(this Control ctrl)
        {
            if (ctrl == null)
            {
                throw new ArgumentNullException("ctrl");
            }

            return EnumerateControls(coll: ctrl.Controls);
        }

        /// <summary>
        /// Returns a sequence of controls.
        /// </summary>
        /// <param name="coll">The underlying collection.</param>
        /// <returns>The controls.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="coll" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<Control> EnumerateControls(this Control.ControlCollection coll)
        {
            if (coll == null)
            {
                throw new ArgumentNullException("coll");
            }

            return EnumerateControls<Control>(coll: coll);
        }

        /// <summary>
        /// Returns a sequence of controls of a specific type from the collection of a control.
        /// </summary>
        /// <typeparam name="TCtrl">The type of controls that should be filtered out.</typeparam>
        /// <param name="ctrl">The underlying control.</param>
        /// <returns>The child controls of <paramref name="ctrl" />.</returns>
        /// <exception cref="NullReferenceException">
        /// <paramref name="ctrl" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TCtrl> EnumerateControls<TCtrl>(this Control ctrl)
            where TCtrl : global::System.Windows.Forms.Control
        {
            return EnumerateControls<TCtrl>(coll: ctrl.Controls);
        }

        /// <summary>
        /// Returns a sequence of controls of a specific type.
        /// </summary>
        /// <typeparam name="TCtrl">The type of controls that should be filtered out.</typeparam>
        /// <param name="coll">The underlying collection.</param>
        /// <returns>The controls.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="coll" /> is <see langword="null" />.
        /// </exception>
        public static IEnumerable<TCtrl> EnumerateControls<TCtrl>(this Control.ControlCollection coll)
            where TCtrl : global::System.Windows.Forms.Control
        {
            if (coll == null)
            {
                throw new ArgumentNullException("coll");
            }

            return coll.OfType<TCtrl>();
        }

        #endregion Methods (4)
    }
}