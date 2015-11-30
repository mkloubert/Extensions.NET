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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MarcelJoachimKloubert.Extensions.Xml;

namespace MarcelJoachimKloubert.Extensions.Tests
{
    internal class Test
    {
        public string A = "1";
        private string b = "2";

        public void C()
        {
            Console.WriteLine("3");
        }

        private int D()
        {
            return 4;
        }

        private float E { get; set; }

        public double F { get { return 6; } }

        public int G(int a)
        {
            return a*2;
        }
    }

    internal static class Program
    {
        #region Methods (1)

        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                var i = typeof(int).CreateInstance<int>();

                var methods = Enumerable.Empty<Type>()
                                        // .Concat(new Type[] { typeof(MJKCoreExtensionMethods) })
                                        // .Concat(new Type[] { typeof(MJKDataExtensionMethods) })
                                        // .Concat(new Type[] { typeof(MJKWinFormsExtensionMethods) })
                                        .Concat(new Type[] { typeof(MJKXmlExtensionMethods) })
                                        .SelectMany(x => x.GetMethods(BindingFlags.Static | BindingFlags.Public))
                                        .Where(x => x.GetCustomAttributes(typeof(ExtensionAttribute), true).Length > 0)
                                        .OrderBy(x => x.Name, StringComparer.InvariantCultureIgnoreCase)
                                        .ToArray();

                var s = string.Join("\n* ", methods.Select(x => x.Name).Distinct());

                Console.WriteLine(methods.Length);

                var t = new Test().AsDynamic();

                Console.WriteLine(t.A);
                t.A = "11";
                Console.WriteLine(t.A);

                t.C();
                Console.WriteLine(t.G(20));

                var dict = new Dictionary<string, object>();
                dict["a"] = "45dnjdsank";

                var o = dict.Build(d =>
                    {
                        return new Test()
                        {
                            A = (string)d["a"],
                        };
                    });

                var taskCtx = Task.Factory.StartNewTask((ctx) =>
                    {
                        if (ctx != null)
                        {
                        }
                    }, actionState: 12);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR!]: {0}", ex.GetBaseException());
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("===== ENTER =====");
            Console.ReadLine();
        }

        #endregion Methods (1)
    }
}