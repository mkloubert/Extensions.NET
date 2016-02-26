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

namespace MarcelJoachimKloubert.Extensions
{
    // Invoke()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods

        /// <summary>
        /// Invokes a delegate.
        /// </summary>
        /// <param name="delegate">The delegate to invoke.</param>
        /// <param name="args">The arguments for the invocation.</param>
        /// <returns>The result of the invocation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="delegate" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// At least one value in <paramref name="args" /> could not be used as
        /// parameter for <paramref name="delegate" />.
        /// </exception>
        public static object Invoke(this Delegate @delegate,
                                    params object[] args)
        {
            if (@delegate == null)
            {
                throw new ArgumentNullException(nameof(@delegate));
            }

            var method = @delegate.GetMethodInfo();
            var @params = method.GetParameters();

            args = (args ?? new object[] { null }).ToArray();
            if (args.Length != @params.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(args));
            }

            for (var i = 0; i < args.Length; i++)
            {
                args[i] = ConvertObject(args[i],
                                        @params[i].ParameterType);
            }

            return InvokeMethodInfo(method, args,
                                    @delegate.Target);
        }

        /// <summary>
        /// Invokes a delegate.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="delegate">The delegate to invoke.</param>
        /// <param name="args">The arguments for the invocation.</param>
        /// <returns>The result of the invocation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="delegate" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// Cannot convert result to <typeparamref name="TResult" /> --or--
        /// at least one value in <paramref name="args" /> could not be used as
        /// parameter for <paramref name="delegate" />.
        /// </exception>
        public static TResult Invoke<TResult>(this Delegate @delegate,
                                              params object[] args)
        {
            return ConvertObject<TResult>(Invoke(@delegate: @delegate,
                                                 args: args));
        }

        #endregion Methods
    }
}