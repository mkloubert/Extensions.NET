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

using System.Threading.Tasks;

namespace MarcelJoachimKloubert.Extensions
{
    #region INTERFACE: ITaskContext

    /// <summary>
    /// Describes a context for a <see cref="Task" />.
    /// </summary>
    public interface ITaskContext
    {
        #region Properties (1)

        /// <summary>
        /// Gets the underlying task.
        /// </summary>
        Task Task { get; }

        #endregion Properties (1)

        #region Methods (3)

        /// <summary>
        /// Cancels the task.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Starts the task.
        /// </summary>
        void Start();

        /// <summary>
        /// Waits for the task.
        /// </summary>
        void Wait();

        #endregion Methods (3)
    }

    #endregion INTERFACE: ITaskContext

    #region INTERFACE: ITaskContext<TResult>

    /// <summary>
    /// Describes a context for a <see cref="Task" /> with a result.
    /// </summary>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public interface ITaskContext<TResult> : ITaskContext
    {
        #region Properties (1)

        /// <inheriteddoc />
        new Task<TResult> Task { get; }

        #endregion Properties (1)
    }

    #endregion INTERFACE: ITaskContext<TResult>
}