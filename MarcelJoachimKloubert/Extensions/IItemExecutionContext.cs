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

namespace MarcelJoachimKloubert.Extensions
{
    #region INTERFACE: IItemExecutionContext<out TItem>

    /// <summary>
    /// Describes an item execution context.
    /// </summary>
    /// <typeparam name="TItem">Type of the item.</typeparam>
    public interface IItemExecutionContext<out TItem>
    {
        #region Properties (4)

        /// <summary>
        /// Gets or sets if the whole operation should be canceled or not.
        /// </summary>
        bool Cancel { get; set; }

        /// <summary>
        /// Gets or sets if the operation should be continued on error or not.
        /// </summary>
        bool ContinueOnError { get; set; }

        /// <summary>
        /// Gets the zer based index.
        /// </summary>
        long Index { get; }

        /// <summary>
        /// Gets the item.
        /// </summary>
        TItem Item { get; }

        #endregion Properties (4)
    }

    #endregion INTERFACE: IItemExecutionContext<out TItem>

    #region INTERFACE: IItemExecutionContext<out TItem, out TState>

    /// <summary>
    /// Describes an item execution context with a state object.
    /// </summary>
    /// <typeparam name="TItem">Type of the item.</typeparam>
    /// <typeparam name="TState">Type of the state object.</typeparam>
    public interface IItemExecutionContext<out TItem, out TState> : IItemExecutionContext<TItem>
    {
        #region Properties (1)

        /// <summary>
        /// Gets the state object.
        /// </summary>
        TState State { get; }

        #endregion Properties (1)
    }

    #endregion INTERFACE: IItemExecutionContext<out TItem, out TState>
}