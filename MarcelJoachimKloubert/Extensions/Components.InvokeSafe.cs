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

namespace MarcelJoachimKloubert.Extensions
{
    // InvokeSafe()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (6)

        /// <summary>
        /// Invokes an object thread safe.
        /// </summary>
        /// <typeparam name="TObj">Type of the object.</typeparam>
        /// <param name="obj">the object to synchronize.</param>
        /// <param name="action">The action to invoke.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeSafe<TObj>(this TObj obj, Action<TObj> action)
            where TObj : global::System.ComponentModel.ISynchronizeInvoke
        {
            InvokeSafe(obj: obj,
                       action: (o, a) => a(o),
                       actionState: action);
        }

        /// <summary>
        /// Invokes an object thread safe.
        /// </summary>
        /// <typeparam name="TObj">Type of the object.</typeparam>
        /// <typeparam name="TState">The type of the object for <paramref name="action" />.</typeparam>
        /// <param name="obj">the object to synchronize.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionState">The second argument for <paramref name="action" />.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeSafe<TObj, TState>(this TObj obj,
                                                    Action<TObj, TState> action, TState actionState)
            where TObj : global::System.ComponentModel.ISynchronizeInvoke
        {
            InvokeSafe(obj: obj,
                       action: action, actionStateFactory: (o) => actionState);
        }

        /// <summary>
        /// Invokes an object thread safe.
        /// </summary>
        /// <typeparam name="TObj">Type of the object.</typeparam>
        /// <typeparam name="TState">The type of the object for <paramref name="action" />.</typeparam>
        /// <param name="obj">the object to synchronize.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionStateFactory">The function that returns the second argument for <paramref name="action" />.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj" />, <paramref name="action" /> and/or <paramref name="actionStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeSafe<TObj, TState>(this TObj obj,
                                                    Action<TObj, TState> action, Func<TObj, TState> actionStateFactory)
            where TObj : global::System.ComponentModel.ISynchronizeInvoke
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (actionStateFactory == null)
            {
                throw new ArgumentNullException("actionStateFactory");
            }

            InvokeSafe(
                obj: obj,
                func: (o, s) =>
                    {
                        s.Action(o,
                                 s.StateFactory(o));

                        return (object)null;
                    },
                funcState: new
                    {
                        Action = action,
                        StateFactory = actionStateFactory,
                    });
        }

        /// <summary>
        /// Invokes an object thread safe.
        /// </summary>
        /// <typeparam name="TObj">Type of the object.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="obj">the object to synchronize.</param>
        /// <param name="func">The function to invoke.</param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeSafe<TObj, TResult>(this TObj obj, Func<TObj, TResult> func)
            where TObj : global::System.ComponentModel.ISynchronizeInvoke
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            return InvokeSafe(obj: obj,
                              func: (o, f) => f(o),
                              funcState: func);
        }

        /// <summary>
        /// Invokes an object thread safe.
        /// </summary>
        /// <typeparam name="TObj">Type of the object.</typeparam>
        /// <typeparam name="TState">The type of the object for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="obj">the object to synchronize.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcState">The second argument for <paramref name="func" />.</param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeSafe<TObj, TState, TResult>(this TObj obj,
                                                                Func<TObj, TState, TResult> func, TState funcState)
            where TObj : global::System.ComponentModel.ISynchronizeInvoke
        {
            return InvokeSafe(obj: obj,
                              func: func, funcStateFactory: (o) => funcState);
        }

        /// <summary>
        /// Invokes an object thread safe.
        /// </summary>
        /// <typeparam name="TObj">Type of the object.</typeparam>
        /// <typeparam name="TState">The type of the object for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="obj">the object to synchronize.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcStateFactory">The function that returns the second argument for <paramref name="func" />.</param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj" />, <paramref name="func" /> and/or <paramref name="funcStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeSafe<TObj, TState, TResult>(this TObj obj,
                                                                Func<TObj, TState, TResult> func, Func<TObj, TState> funcStateFactory)
            where TObj : global::System.ComponentModel.ISynchronizeInvoke
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            if (funcStateFactory == null)
            {
                throw new ArgumentNullException("funcStateFactory");
            }

            if (obj.InvokeRequired)
            {
                return (TResult)obj.Invoke(new Func<TObj, Func<TObj, TState, TResult>, Func<TObj, TState>, TResult>(InvokeSafe<TObj, TState, TResult>),
                                           new object[] { obj, func, funcStateFactory });
            }

            return func(obj,
                        funcStateFactory(obj));
        }

        #endregion Methods (6)
    }
}