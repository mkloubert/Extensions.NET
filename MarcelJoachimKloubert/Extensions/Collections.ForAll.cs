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

namespace MarcelJoachimKloubert.Extensions
{
    // ForAll()
    static partial class MJKCoreExtensionMethods
    {
        #region CLASS: ItemExecutionContext<TItem, TState>

        internal class ItemExecutionContext<TItem, TState> : IItemExecutionContext<TItem, TState>
        {
            #region Properties (5)

            public bool Cancel
            {
                get;
                set;
            }

            public bool ContinueOnError
            {
                get;
                set;
            }

            public long Index
            {
                get;
                internal set;
            }

            public TItem Item
            {
                get;
                internal set;
            }

            public TState State
            {
                get;
                internal set;
            }

            #endregion Properties (5)
        }

        #endregion CLASS: ItemExecutionContext<TItem, TState>

        #region Methods (3)

        /// <summary>
        /// Invokes an action for all items of a sequences even if exceptions are thrown.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <param name="seq">The sequence with the items.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="throwExceptions">
        /// Throw all occured exceptions (<see langword="true" />) or return them (<see langword="false" />).
        /// </param>
        /// <returns>
        /// All thrown exceptions or <see langword="null" /> if no exception was thrown while invocation
        /// and <paramref name="throwExceptions" /> is <see langword="false" />.
        /// </returns>
        /// <exception cref="AggregateException">
        /// At least one exception was thrown while invokation and
        /// <paramref name="throwExceptions" /> is <see langword="true" />.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="seq" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static AggregateException ForAll<T>(this IEnumerable<T> seq,
                                                   Action<IItemExecutionContext<T>> action,
                                                   bool throwExceptions = true)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            return ForAll(seq: seq,
                          action: (ctx) => ctx.State(ctx),
                          actionState: action,
                          throwExceptions: throwExceptions);
        }

        /// <summary>
        /// Invokes an action for all items of a sequences even if exceptions are thrown.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="seq">The sequence with the items.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionState">The value for the second argument of <paramref name="action" />.</param>
        /// <param name="throwExceptions">
        /// Throw all occured exceptions (<see langword="true" />) or return them (<see langword="false" />).
        /// </param>
        /// <returns>
        /// All thrown exceptions or <see langword="null" /> if no exception was thrown while invocation
        /// and <paramref name="throwExceptions" /> is <see langword="false" />.
        /// </returns>
        /// <exception cref="AggregateException">
        /// At least one exception was thrown while invokation and
        /// <paramref name="throwExceptions" /> is <see langword="true" />.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="seq" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static AggregateException ForAll<T, TState>(this IEnumerable<T> seq,
                                                           Action<IItemExecutionContext<T, TState>> action, TState actionState,
                                                           bool throwExceptions = true)
        {
            return ForAll<T, TState>(seq: seq,
                                     action: action, actionStateFactory: (item, index) => actionState,
                                     throwExceptions: throwExceptions);
        }

        /// <summary>
        /// Invokes an action for all items of a sequences even if exceptions are thrown.
        /// </summary>
        /// <typeparam name="T">Type of the items.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="seq">The sequence with the items.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionStateFactory">The function that returns the value for the second argument of <paramref name="action" />.</param>
        /// <param name="throwExceptions">
        /// Throw all occured exceptions (<see langword="true" />) or return them (<see langword="false" />).
        /// </param>
        /// <returns>
        /// All thrown exceptions or <see langword="null" /> if no exception was thrown while invocation
        /// and <paramref name="throwExceptions" /> is <see langword="false" />.
        /// </returns>
        /// <exception cref="AggregateException">
        /// At least one exception was thrown while invokation and
        /// <paramref name="throwExceptions" /> is <see langword="true" />.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="seq" />, <paramref name="action" /> and/or <paramref name="actionStateFactory" />
        /// is <see langword="null" />.
        /// </exception>
        public static AggregateException ForAll<T, TState>(this IEnumerable<T> seq,
                                                           Action<IItemExecutionContext<T, TState>> action, Func<T, long, TState> actionStateFactory,
                                                           bool throwExceptions = true)
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (actionStateFactory == null)
            {
                throw new ArgumentNullException("actionStateFactory");
            }

            var exceptions = new List<Exception>();

            AggregateException result = null;

            try
            {
                using (var enumerator = seq.GetEnumerator())
                {
                    long index = -1;
                    while (enumerator.MoveNext())
                    {
                        var ctx = new ItemExecutionContext<T, TState>
                            {
                                Cancel = false,
                                ContinueOnError = true
                            };

                        try
                        {
                            ctx.Index = ++index;
                            ctx.Item = enumerator.Current;
                            ctx.State = actionStateFactory(ctx.Item, ctx.Index);

                            action(ctx);
                        }
                        catch (Exception ex)
                        {
                            exceptions.Add(ex);

                            if (!ctx.ContinueOnError)
                            {
                                break;
                            }
                        }

                        if (ctx.Cancel)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }

            if (exceptions.Count > 0)
            {
                result = new AggregateException(innerExceptions: exceptions);

                if (throwExceptions)
                {
                    throw result;
                }
            }

            return result;
        }

        #endregion Methods (3)
    }
}