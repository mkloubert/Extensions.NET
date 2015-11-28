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
    // InvokeForStream()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (6)

        /// <summary>
        /// Invokes an action for a stream and restores the old position after invokation (if possible).
        /// </summary>
        /// <typeparam name="TStream">Type of the stream.</typeparam>
        /// <param name="stream">The underlying stream.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="restorePosition">
        /// Restore position of <paramref name="stream" /> after invocation if possible; otherwise <see langword="false" />.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeForStream<TStream>(this TStream stream,
                                                    Action<TStream> action,
                                                    bool restorePosition = true)
            where TStream : global::System.IO.Stream
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            InvokeForStream(stream: stream,
                            action: (s, @as) => @as.Action(s),
                            actionState: new
                            {
                                Action = action,
                            },
                            restorePosition: restorePosition);
        }

        /// <summary>
        /// Invokes an action for a stream and restores the old position after invokation (if possible).
        /// </summary>
        /// <typeparam name="TStream">Type of the stream.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="stream">The underlying stream.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionState">The object for the 2nd argument of <paramref name="action" />.</param>
        /// <param name="restorePosition">
        /// Restore position of <paramref name="stream" /> after invocation if possible; otherwise <see langword="false" />.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeForStream<TStream, TState>(this TStream stream,
                                                            Action<TStream, TState> action, TState actionState,
                                                            bool restorePosition = true)
            where TStream : global::System.IO.Stream
        {
            InvokeForStream<TStream, TState>(stream: stream,
                                             action: action,
                                             actionStateFactory: (s) => actionState,
                                             restorePosition: restorePosition);
        }

        /// <summary>
        /// Invokes an action for a stream and restores the old position after invokation (if possible).
        /// </summary>
        /// <typeparam name="TStream">Type of the stream.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="stream">The underlying stream.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionStateFactory">The function that returns the object for the 2nd argument of <paramref name="action" />.</param>
        /// <param name="restorePosition">
        /// Restore position of <paramref name="stream" /> after invocation if possible; otherwise <see langword="false" />.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" />, <paramref name="action" /> and/or <paramref name="actionStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static void InvokeForStream<TStream, TState>(this TStream stream,
                                                            Action<TStream, TState> action, Func<TStream, TState> actionStateFactory,
                                                            bool restorePosition = true)
            where TStream : global::System.IO.Stream
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (actionStateFactory == null)
            {
                throw new ArgumentNullException(nameof(actionStateFactory));
            }

            InvokeForStream(stream: stream,
                            func: (s, fs) =>
                            {
                                fs.Action(s,
                                          fs.StateFactory(s));

                                return (object)null;
                            },
                            funcState: new
                            {
                                Action = action,
                                StateFactory = actionStateFactory,
                            },
                            restorePosition: restorePosition);
        }

        /// <summary>
        /// Invokes a function for a stream and restores the old position after invokation (if possible).
        /// </summary>
        /// <typeparam name="TStream">Type of the stream.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="stream">The underlying stream.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="restorePosition">
        /// Restore position of <paramref name="stream" /> after invocation if possible; otherwise <see langword="false" />.
        /// </param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeForStream<TStream, TResult>(this TStream stream,
                                                                Func<TStream, TResult> func,
                                                                bool restorePosition = true)
            where TStream : global::System.IO.Stream
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return InvokeForStream(stream: stream,
                                   func: (s, fs) => fs.Func(s),
                                   funcState: new
                                   {
                                       Func = func,
                                   },
                                   restorePosition: restorePosition);
        }

        /// <summary>
        /// Invokes a function for a stream and restores the old position after invokation (if possible).
        /// </summary>
        /// <typeparam name="TStream">Type of the stream.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="stream">The underlying stream.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcState">Tthe object for the 2nd argument of <paramref name="func" />.</param>
        /// <param name="restorePosition">
        /// Restore position of <paramref name="stream" /> after invocation if possible; otherwise <see langword="false" />.
        /// </param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeForStream<TStream, TState, TResult>(this TStream stream,
                                                                        Func<TStream, TState, TResult> func, TState funcState,
                                                                        bool restorePosition = true)
            where TStream : global::System.IO.Stream
        {
            return InvokeForStream<TStream, TState, TResult>(stream: stream,
                                                             func: func, funcStateFactory: (s) => funcState,
                                                             restorePosition: restorePosition);
        }

        /// <summary>
        /// Invokes a function for a stream and restores the old position after invokation (if possible).
        /// </summary>
        /// <typeparam name="TStream">Type of the stream.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="stream">The underlying stream.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcStateFactory">The function that returns the object for the 2nd argument of <paramref name="func" />.</param>
        /// <param name="restorePosition">
        /// Restore position of <paramref name="stream" /> after invocation if possible; otherwise <see langword="false" />.
        /// </param>
        /// <returns>The result of <paramref name="func" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream" />, <paramref name="func" /> and/or <paramref name="funcStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static TResult InvokeForStream<TStream, TState, TResult>(this TStream stream,
                                                                        Func<TStream, TState, TResult> func, Func<TStream, TState> funcStateFactory,
                                                                        bool restorePosition = true)
            where TStream : global::System.IO.Stream
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (funcStateFactory == null)
            {
                throw new ArgumentNullException(nameof(funcStateFactory));
            }

            long? oldPosition = null;
            try
            {
                if (restorePosition)
                {
                    if (stream.CanSeek)
                    {
                        oldPosition = stream.Position;
                    }
                }

                return func(stream,
                            funcStateFactory(stream));
            }
            finally
            {
                if (oldPosition.HasValue)
                {
                    stream.Position = oldPosition.Value;
                }
            }
        }

        #endregion Methods (6)
    }
}