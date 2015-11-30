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
using System.Threading.Tasks;

namespace MarcelJoachimKloubert.Extensions
{
    // StartAll()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Starts a list of tasks.
        /// </summary>
        /// <param name="tasks">The tasks to start.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// <returns>
        /// The started tasks or <see langword="null" /> if <paramref name="tasks" /> is also <see langword="null" />.
        /// </returns>
        /// <exception cref="AggregateException">
        /// At least one task could not be started.
        /// </exception>
        public static Task[] StartAll(
            this IEnumerable<Task> tasks,
            TaskScheduler scheduler = null)
        {
            AggregateException exceptions;
            var result = StartAll(tasks: tasks,
                                  exceptions: out exceptions,
                                  scheduler: scheduler);

            if (exceptions != null)
            {
                throw exceptions;
            }

            return result;
        }

        /// <summary>
        /// Starts a list of tasks.
        /// </summary>
        /// <param name="tasks">The tasks to start.</param>
        /// <param name="exceptions">The variable where to write the occurred exceptions to.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// The started tasks or <see langword="null" /> if <paramref name="tasks" /> is also <see langword="null" />.
        public static Task[] StartAll(
            this IEnumerable<Task> tasks,
            out AggregateException exceptions,
            TaskScheduler scheduler = null)
        {
            exceptions = null;

            if (tasks == null)
            {
                return null;
            }

            var occurredExceptions = new List<Exception>();

            var startedTasks = new List<Task>();

            try
            {
                using (var e = tasks.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        try
                        {
                            var t = e.Current;
                            if (t == null)
                            {
                                continue;
                            }

                            if (scheduler == null)
                            {
                                t.Start();
                            }
                            else
                            {
                                t.Start(scheduler);
                            }

                            startedTasks.Add(t);
                        }
                        catch (Exception ex)
                        {
                            occurredExceptions.Add(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                occurredExceptions.Add(ex);
            }

            if (occurredExceptions.Count > 0)
            {
                exceptions = new AggregateException(occurredExceptions);
            }

            return startedTasks.ToArray();
        }

        #endregion Methods (2)
    }
}