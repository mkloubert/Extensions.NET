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
using System.Dynamic;
using System.Reflection;

namespace MarcelJoachimKloubert.Extensions
{
    // AsDynamic()
    static partial class MJKCoreExtensionMethods
    {
        #region Methods (2)

        /// <summary>
        /// Returns an object as dynmaic object.
        /// </summary>
        /// <param name="obj">The input value.</param>
        /// <returns>The output value.</returns>
        public static dynamic AsDynamic(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var items = obj as IEnumerable<KeyValuePair<string, object>>;
            if (items == null)
            {
                var temp = new Dictionary<string, object>();
                {
                    var wrapMethod = new Func<MethodInfo, MethodWrapper>((m) =>
                        {
                            return (args) => InvokeMethodInfo(m, args,
                                                              obj);
                        });

                    // fields
                    foreach (var f in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
                    {
                        temp.Add(f.Name,
                                 f.GetValue(obj));
                    }

                    // properties
                    foreach (var p in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (p.GetIndexParameters().Length > 0)
                        {
                            continue;
                        }

                        var getter = p.GetGetMethod();
                        if (getter == null)
                        {
                            continue;
                        }

                        temp.Add(p.Name,
                                 p.GetValue(obj: obj, index: null));
                    }

                    // methods
                    foreach (var m in obj.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    {
                        temp.Add(m.Name,
                                 wrapMethod(m));
                    }
                }

                items = temp;
            }

            var dict = items as IDictionary<string, object>;
            if (dict == null)
            {
                dict = new Dictionary<string, object>();

                using (var e = items.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        dict.Add(e.Current);
                    }
                }
            }

            var result = dict as ExpandoObject;
            if (result == null)
            {
                result = new ExpandoObject();

                using (var e = dict.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        ((IDictionary<string, object>)result).Add(e.Current);
                    }
                }
            }

            return result;
        }

        #endregion Methods (2)
    }
}