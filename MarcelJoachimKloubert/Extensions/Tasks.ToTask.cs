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
using System.Threading.Tasks;

namespace MarcelJoachimKloubert.Extensions
{
    // ToTask
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (39)

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <param name="action">The action to convert.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask(
            this Action action,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[0],
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T">Type of the argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T>(
            this Action<T> action,
            T arg0,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2>(
            this Action<T1, T2> action,
            T1 arg0, T2 arg1,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3>(
            this Action<T1, T2, T3> action,
            T1 arg0, T2 arg1, T3 arg2,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5>(
            this Action<T1, T2, T3, T4, T5> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6>(
            this Action<T1, T2, T3, T4, T5, T6> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7>(
            this Action<T1, T2, T3, T4, T5, T6, T7> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="action" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="action" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="action" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="action" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="action" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="action" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T14">Type of the 14th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="action" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="action" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="action" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="action" />.</param>
        /// <param name="arg13">The fourteenth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12, T14 arg13,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T14">Type of the 14th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T15">Type of the 15th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="action" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="action" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="action" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="action" />.</param>
        /// <param name="arg13">The fourteenth argument for <paramref name="action" />.</param>
        /// <param name="arg14">The fiveteenth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12, T14 arg13, T15 arg14,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts an action to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T14">Type of the 14th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T15">Type of the 15th argument for <paramref name="action" />.</typeparam>
        /// <typeparam name="T16">Type of the 16th argument for <paramref name="action" />.</typeparam>
        /// <param name="action">The action to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="action" />.</param>
        /// <param name="arg1">The second argument for <paramref name="action" />.</param>
        /// <param name="arg2">The third argument for <paramref name="action" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="action" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="action" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="action" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="action" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="action" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="action" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="action" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="action" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="action" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="action" />.</param>
        /// <param name="arg13">The fourteenth argument for <paramref name="action" />.</param>
        /// <param name="arg14">The fiveteenth argument for <paramref name="action" />.</param>
        /// <param name="arg15">The sixteenth argument for <paramref name="action" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="action" /> is also <see langword="null" />.
        /// </returns>
        public static Task ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12, T14 arg13, T15 arg14, T16 arg15,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask(@delegate: action,
                          argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15 },
                          creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<TResult>(
            this Func<TResult> func,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[0],
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T, TResult>(
            this Func<T, TResult> func,
            T arg0,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, TResult>(
            this Func<T1, T2, TResult> func,
            T1 arg0, T2 arg1,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func,
            T1 arg0, T2 arg1, T3 arg2,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="func" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="func" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="func" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="func" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="func" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="func" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T14">Type of the 14th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="func" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="func" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="func" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="func" />.</param>
        /// <param name="arg13">The fourteenth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12, T14 arg13,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T14">Type of the 14th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T15">Type of the 15th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="func" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="func" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="func" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="func" />.</param>
        /// <param name="arg13">The fourteenth argument for <paramref name="func" />.</param>
        /// <param name="arg14">The fiveteenth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12, T14 arg13, T15 arg14,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a function to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T1">Type of the 1st argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T2">Type of the 2nd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T3">Type of the 3rd argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T4">Type of the 4th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T5">Type of the 5th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T6">Type of the 6th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T7">Type of the 7th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T8">Type of the 8th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T9">Type of the 9th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T10">Type of the 10th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T11">Type of the 11th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T12">Type of the 12th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T13">Type of the 13th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T14">Type of the 14th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T15">Type of the 15th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="T16">Type of the 16th argument for <paramref name="func" />.</typeparam>
        /// <typeparam name="TResult">Type of the result of <paramref name="func" />.</typeparam>
        /// <param name="func">The function to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="func" />.</param>
        /// <param name="arg1">The second argument for <paramref name="func" />.</param>
        /// <param name="arg2">The third argument for <paramref name="func" />.</param>
        /// <param name="arg3">The fourth argument for <paramref name="func" />.</param>
        /// <param name="arg4">The fifth argument for <paramref name="func" />.</param>
        /// <param name="arg5">The sixth argument for <paramref name="func" />.</param>
        /// <param name="arg6">The seventh argument for <paramref name="func" />.</param>
        /// <param name="arg7">The eigth argument for <paramref name="func" />.</param>
        /// <param name="arg8">The nineth argument for <paramref name="func" />.</param>
        /// <param name="arg9">The tenth argument for <paramref name="func" />.</param>
        /// <param name="arg10">The eleventh argument for <paramref name="func" />.</param>
        /// <param name="arg11">The twelvth argument for <paramref name="func" />.</param>
        /// <param name="arg12">The thirdteenth argument for <paramref name="func" />.</param>
        /// <param name="arg13">The fourteenth argument for <paramref name="func" />.</param>
        /// <param name="arg14">The fiveteenth argument for <paramref name="func" />.</param>
        /// <param name="arg15">The sixteenth argument for <paramref name="func" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="func" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func,
            T1 arg0, T2 arg1, T3 arg2, T4 arg3, T5 arg4, T6 arg5, T7 arg6, T8 arg7, T9 arg8, T10 arg9, T11 arg10, T12 arg11, T13 arg12, T14 arg13, T15 arg14, T16 arg15,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<TResult>(@delegate: func,
                                   argList: new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15 },
                                   creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a predicate to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="T">Type of the 1st argument for <paramref name="predicate" />.</typeparam>
        /// <param name="predicate">The predicate to convert.</param>
        /// <param name="arg0">The first argument for <paramref name="predicate" />.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="predicate" /> is also <see langword="null" />.
        /// </returns>
        public static Task<bool> ToTask<T>(
            Predicate<T> predicate,
            T arg0,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            return ToTask<bool>(@delegate: predicate,
                                argList: new object[] { arg0 },
                                creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a delegate to a <see cref="Task" />.
        /// </summary>
        /// <param name="delegate">The delegate to convert.</param>
        /// <param name="args">The list of arguments for the invocation.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="delegate" /> is also <see langword="null" />.
        /// </returns>
        public static Task<object> ToTask(
            this Delegate @delegate,
            params object[] args
        )
        {
            return ToTask<object>(@delegate: @delegate,
                                  args: args);
        }

        /// <summary>
        /// Converts a delegate to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="delegate">The delegate to convert.</param>
        /// <param name="args">The list of arguments for the invocation.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="delegate" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<TResult>(
            this Delegate @delegate,
            params object[] args
        )
        {
            return ToTask<TResult>(@delegate: @delegate,
                                   argList: args);
        }

        /// <summary>
        /// Converts a delegate to a <see cref="Task" />.
        /// </summary>
        /// <param name="delegate">The delegate to convert.</param>
        /// <param name="argList">The list of arguments for the invocation.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="delegate" /> is also <see langword="null" />.
        /// </returns>
        public static Task<object> ToTask(
            this Delegate @delegate,
            IEnumerable<object> argList,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
            )
        {
            return ToTask<object>(@delegate: @delegate,
                                  argList: argList,
                                  creationOptions: creationOptions);
        }

        /// <summary>
        /// Converts a delegate to a <see cref="Task" />.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="delegate">The delegate to convert.</param>
        /// <param name="argList">The list of arguments for the invocation.</param>
        /// <param name="creationOptions">The options.</param>
        /// <returns>
        /// The task or <see langword="null" /> if <paramref name="delegate" /> is also <see langword="null" />.
        /// </returns>
        public static Task<TResult> ToTask<TResult>(
            this Delegate @delegate,
            IEnumerable<object> argList,
            TaskCreationOptions creationOptions = TaskCreationOptions.None
        )
        {
            if (@delegate == null)
            {
                return null;
            }

            var args = argList as object[];
            if (argList != null && args == null)
            {
                args = argList.ToArray();
            }

            args = args ?? new object[] { null };
            if (args.Length < 1)
            {
                args = null;
            }

            return new Task<TResult>(
                function: (state) =>
                {
                    var taskArgs = (object[])state;

                    var d = (Delegate)taskArgs[0];
                    var a = (object[])taskArgs[1];

                    return (TResult)d.Method
                                     .Invoke(obj: d.Target,
                                             parameters: a);
                },
                state: new object[] { @delegate, args },
                creationOptions: creationOptions);
        }

        #endregion Methods (39)
    }
}