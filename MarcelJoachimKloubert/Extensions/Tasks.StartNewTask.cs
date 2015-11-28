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
using System.Threading;
using System.Threading.Tasks;

namespace MarcelJoachimKloubert.Extensions
{
    // StartNewTask()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (6)

        /// <summary>
        /// Starts a new task.
        /// </summary>
        /// <param name="factory">The underlying factory.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="creationOptions">The options.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// <returns>The underlying context.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static ITaskContext StartNewTask(this TaskFactory factory,
                                                Action<ITaskExecutionContext> action,
                                                TaskCreationOptions creationOptions = TaskCreationOptions.None, TaskScheduler scheduler = null)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return StartNewTask(factory: factory,
                                action: (ctx) => ctx.State(ctx), actionState: action,
                                creationOptions: creationOptions, scheduler: scheduler);
        }

        /// <summary>
        /// Starts a new task.
        /// </summary>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="factory">The underlying factory.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionState">The second argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// <returns>The underlying context.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" /> and/or <paramref name="action" /> is <see langword="null" />.
        /// </exception>
        public static ITaskContext StartNewTask<TState>(this TaskFactory factory,
                                                        Action<ITaskExecutionContext<TState>> action, TState actionState,
                                                        TaskCreationOptions creationOptions = TaskCreationOptions.None, TaskScheduler scheduler = null)
        {
            return StartNewTask<TState>(factory: factory,
                                        action: action, actionStateFactory: (tc) => actionState,
                                        creationOptions: creationOptions, scheduler: scheduler);
        }

        /// <summary>
        /// Starts a new task.
        /// </summary>
        /// <typeparam name="TState">Type of the second argument for <paramref name="action" />.</typeparam>
        /// <param name="factory">The underlying factory.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="actionStateFactory">The provider that returns the second argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// <returns>The underlying context.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" />, <paramref name="action" /> and/or <paramref name="actionStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static ITaskContext StartNewTask<TState>(this TaskFactory factory,
                                                        Action<ITaskExecutionContext<TState>> action, Func<ITaskContext, TState> actionStateFactory,
                                                        TaskCreationOptions creationOptions = TaskCreationOptions.None, TaskScheduler scheduler = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (actionStateFactory == null)
            {
                throw new ArgumentNullException(nameof(actionStateFactory));
            }

            var result = new TaskContext()
                {
                    CancellationSource = new CancellationTokenSource(),
                    Scheduler = scheduler ?? factory.Scheduler,
                };

            var newTask = new Task(action: (state) =>
                {
                    var taskArgs = (object[])state;

                    var taskAction = (Action<ITaskExecutionContext<TState>>)taskArgs[0];
                    var stateFactory = (Func<ITaskContext, TState>)taskArgs[1];
                    var taskCtx = (TaskContext)taskArgs[2];

                    var ctx = new TaskExecutionContext<TState>()
                        {
                            CancelToken = taskCtx.CancellationSource.Token,
                            StateProvider = () => stateFactory(taskCtx),
                        };

                    taskAction(ctx);
                }, state: new object[] { action, actionStateFactory, result }
                 , creationOptions: creationOptions
                 , cancellationToken: result.CancellationSource.Token);

            result.Task = newTask;

            result.Start();
            return result;
        }

        /// <summary>
        /// Starts a new task.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="factory">The underlying factory.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="creationOptions">The options.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// <returns>The underlying context.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static ITaskContext<TResult> StartNewTask<TResult>(this TaskFactory<TResult> factory,
                                                                  Func<ITaskExecutionContext, TResult> func,
                                                                  TaskCreationOptions creationOptions = TaskCreationOptions.None, TaskScheduler scheduler = null)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return StartNewTask(factory: factory,
                                func: (ctx) => ctx.State(ctx), funcState: func,
                                creationOptions: creationOptions, scheduler: scheduler);
        }

        /// <summary>
        /// Starts a new task.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="func" />.</typeparam>
        /// <param name="factory">The underlying factory.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcState">The second argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// <returns>The underlying context.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" /> and/or <paramref name="func" /> is <see langword="null" />.
        /// </exception>
        public static ITaskContext<TResult> StartNewTask<TState, TResult>(this TaskFactory<TResult> factory,
                                                                          Func<ITaskExecutionContext<TState>, TResult> func, TState funcState,
                                                                          TaskCreationOptions creationOptions = TaskCreationOptions.None, TaskScheduler scheduler = null)
        {
            return StartNewTask(factory: factory,
                                func: func, funcStateFactory: (tc) => funcState,
                                creationOptions: creationOptions, scheduler: scheduler);
        }

        /// <summary>
        /// Starts a new task.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <typeparam name="TState">Type of the second argument for <paramref name="func" />.</typeparam>
        /// <param name="factory">The underlying factory.</param>
        /// <param name="func">The function to invoke.</param>
        /// <param name="funcStateFactory">The provider that returns the second argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <param name="scheduler">The custom scheduler to use.</param>
        /// <returns>The underlying context.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="factory" />, <paramref name="func" /> and/or <paramref name="funcStateFactory" /> is <see langword="null" />.
        /// </exception>
        public static ITaskContext<TResult> StartNewTask<TState, TResult>(this TaskFactory<TResult> factory,
                                                                          Func<ITaskExecutionContext<TState>, TResult> func, Func<ITaskContext<TResult>, TState> funcStateFactory,
                                                                          TaskCreationOptions creationOptions = TaskCreationOptions.None, TaskScheduler scheduler = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (funcStateFactory == null)
            {
                throw new ArgumentNullException(nameof(funcStateFactory));
            }

            var result = new TaskContext<TResult>()
                {
                    CancellationSource = new CancellationTokenSource(),
                    Scheduler = scheduler ?? factory.Scheduler,
                };

            var newTask = new Task<TResult>(function: (state) =>
                {
                    var taskArgs = (object[])state;

                    var taskFunc = (Func<ITaskExecutionContext<TState>, TResult>)taskArgs[0];
                    var stateFactory = (Func<ITaskContext<TResult>, TState>)taskArgs[1];
                    var taskCtx = (TaskContext<TResult>)taskArgs[2];

                    var ctx = new TaskExecutionContext<TState>()
                        {
                            CancelToken = taskCtx.CancellationSource.Token,
                            StateProvider = () => stateFactory(taskCtx),
                        };

                    return taskFunc(ctx);
                }, state: new object[] { func, funcStateFactory, result }
                 , creationOptions: creationOptions
                 , cancellationToken: result.CancellationSource.Token);

            result.Task = newTask;

            result.Start();
            return result;
        }

        #endregion Methods (6)
    }
}