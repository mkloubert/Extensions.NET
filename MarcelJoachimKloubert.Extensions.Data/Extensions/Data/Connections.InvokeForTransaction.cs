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
using System.Data.Common;

namespace MarcelJoachimKloubert.Extensions.Data
{
    // InvokeForTransaction()
    static partial class MJKDataExtensionMethods
    {
        #region Methods (6)

        /// <summary>
        /// Begins a transaction and invokes an action for it.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="action">The action to invoke.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="conn" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeForTransaction(this DbConnection conn, Action<DbTransaction> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            InvokeForTransaction(conn: conn,
                                 action: (t, a) => a(t), actionState: action);
        }

        /// <summary>
        /// Begins a transaction and invokes an action for it.
        /// </summary>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="conn">The connection.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionState">The second argument for <paramref name="action" />.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="conn" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeForTransaction<TState>(this DbConnection conn,
                                                        Action<DbTransaction, TState> action, TState actionState)
        {
            InvokeForTransaction(conn: conn,
                                 action: action, actionStateFactory: (t) => actionState);
        }

        /// <summary>
        /// Begins a transaction and invokes an action for it.
        /// </summary>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="conn">The connection.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionStateFactory">The function that returns the second argument for <paramref name="action" />.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="conn" />, <paramref name="action" /> and/or <paramref name="actionStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeForTransaction<TState>(this DbConnection conn,
                                                        Action<DbTransaction, TState> action, Func<DbTransaction, TState> actionStateFactory)
        {
            if (conn == null)
            {
                throw new ArgumentNullException(nameof(conn));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (actionStateFactory == null)
            {
                throw new ArgumentNullException(nameof(actionStateFactory));
            }

            InvokeForTransaction(
                conn: conn,
                func: (transaction, state) =>
                    {
                        state.Action(transaction,
                                     state.StateFactory(transaction));

                        return (object)null;
                    },
                funcState: new
                {
                    Action = action,
                    StateFactory = actionStateFactory,
                });
        }

        /// <summary>
        /// Begins a transaction and invokes a function for it.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="conn">The connection.</param>
        /// <param name="func">The function to invoke.</param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="conn" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeForTransaction<TResult>(this DbConnection conn, Func<DbTransaction, TResult> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return InvokeForTransaction(conn: conn,
                                        func: (t, f) => f(t), funcState: func);
        }

        /// <summary>
        /// Begins a transaction and invokes a function for it.
        /// </summary>
        /// <typeparam name="TState">Type of the second argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="conn">The connection.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcState">The second argument for <paramref name="func" />.</param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="conn" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeForTransaction<TState, TResult>(this DbConnection conn,
                                                                    Func<DbTransaction, TState, TResult> func, TState funcState)
        {
            return InvokeForTransaction(conn: conn,
                                        func: func, funcStateFactory: (t) => funcState);
        }

        /// <summary>
        /// Begins a transaction and invokes a function for it.
        /// </summary>
        /// <typeparam name="TState">Type of the second argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="conn">The connection.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcStateFactory">The function that returns the second argument for <paramref name="func" />.</param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="conn" />, <paramref name="func" /> and/or <paramref name="funcStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeForTransaction<TState, TResult>(this DbConnection conn,
                                                                    Func<DbTransaction, TState, TResult> func, Func<DbTransaction, TState> funcStateFactory)
        {
            if (conn == null)
            {
                throw new ArgumentNullException(nameof(conn));
            }

            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (funcStateFactory == null)
            {
                throw new ArgumentNullException(nameof(funcStateFactory));
            }

            var transaction = conn.BeginTransaction();
            try
            {
                var result = func(transaction,
                                  funcStateFactory(transaction));

                transaction.Commit();

                return result;
            }
            catch
            {
                transaction.Rollback();

                throw;
            }
        }

        #endregion Methods (6)
    }
}