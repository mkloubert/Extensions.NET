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
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace MarcelJoachimKloubert.Extensions.UnitTests
{
    internal class Program
    {
        #region Methods (2)

        private static void InvokeForConsole(Action action,
                                             ConsoleColor? foreColor = null, ConsoleColor? bgColor = null)
        {
            var oldForeColor = Console.ForegroundColor;
            var oldBackColor = Console.BackgroundColor;

            try
            {
                if (foreColor.HasValue)
                {
                    Console.ForegroundColor = foreColor.Value;
                }

                if (bgColor.HasValue)
                {
                    Console.BackgroundColor = bgColor.Value;
                }

                if (action != null)
                {
                    action();
                }
            }
            finally
            {
                Console.ForegroundColor = oldForeColor;
                Console.BackgroundColor = oldBackColor;
            }
        }

        [STAThread]
        private static int Main()
        {
            var exitCode = 0;

            try
            {
                var asms = new[]
                {
                    Assembly.GetExecutingAssembly(),
                };

                foreach (var type in asms.SelectMany(x => x.GetTypes())
                                         .Where(t => t.IsPublic &&
                                                     (t.IsAbstract == false))
                                         .OrderBy(t => t.Name, StringComparer.InvariantCultureIgnoreCase))
                {
                    if (type.GetCustomAttributes(typeof(global::NUnit.Framework.IgnoreAttribute), true)
                            .Any())
                    {
                        continue;
                    }

                    if (!type.GetCustomAttributes(typeof(global::NUnit.Framework.TestFixtureAttribute), true)
                             .Any())
                    {
                        continue;
                    }

                    try
                    {
                        var obj = Activator.CreateInstance(type);
                        Console.WriteLine("{0} ...", obj.GetType().Name);

                        var allMethods = obj.GetType()
                                            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                            .OrderBy(m => m.Name, StringComparer.OrdinalIgnoreCase)
                                            .ToArray();

                        try
                        {
                            var fixtureSetupMethod = allMethods.SingleOrDefault(m => m.GetCustomAttributes(typeof(global::NUnit.Framework.OneTimeSetUpAttribute), true)
                                                                                      .Any());
                            if (fixtureSetupMethod != null)
                            {
                                fixtureSetupMethod.Invoke(obj, null);
                            }

                            var setupMethod = allMethods.SingleOrDefault(m => m.GetCustomAttributes(typeof(global::NUnit.Framework.SetUpAttribute), true)
                                                                               .Any());

                            var tearDownMethod = allMethods.SingleOrDefault(m => m.GetCustomAttributes(typeof(global::NUnit.Framework.TearDownAttribute), true)
                                                                                  .Any());

                            foreach (var method in allMethods)
                            {
                                if (method.GetCustomAttributes(typeof(global::NUnit.Framework.IgnoreAttribute), true)
                                          .Any())
                                {
                                    // ignored
                                    continue;
                                }

                                var testAttribs = method.GetCustomAttributes(typeof(global::NUnit.Framework.TestAttribute), true)
                                                        .Cast<TestAttribute>()
                                                        .ToArray();
                                if (testAttribs.Length < 1)
                                {
                                    // not marked as test
                                    continue;
                                }

                                try
                                {
                                    Console.Write("\t'{0}' ... ", method.Name);

                                    if (setupMethod != null)
                                    {
                                        setupMethod.Invoke(obj, null);
                                    }

                                    method.Invoke(obj, null);

                                    InvokeForConsole(() => Console.WriteLine("[OK]"),
                                                     ConsoleColor.Green,
                                                     ConsoleColor.Black);
                                }
                                catch (Exception ex)
                                {
                                    var innerEx = ex.GetBaseException();

                                    var aex = innerEx as AssertionException;
                                    if (aex != null)
                                    {
                                        InvokeForConsole(() => Console.WriteLine("[Failed]: {0}",
                                                                                 aex.Message),
                                                         ConsoleColor.Red,
                                                         ConsoleColor.Black);
                                    }
                                    else
                                    {
                                        Console.WriteLine("[ERROR!]: {0}",
                                                          ex.GetBaseException());    
                                    }
                                }
                                finally
                                {
                                    if (tearDownMethod != null)
                                    {
                                        tearDownMethod.Invoke(obj, null);
                                    }
                                }
                            }
                        }
                        finally
                        {
                            var fixtureTearDownMethod = allMethods.SingleOrDefault(m => m.GetCustomAttributes(typeof(global::NUnit.Framework.OneTimeTearDownAttribute), true)
                                                                                         .Any());
                            if (fixtureTearDownMethod != null)
                            {
                                fixtureTearDownMethod.Invoke(obj, null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[ERROR!]: {0}",
                                          ex.GetBaseException());
                    }
                }
            }
            catch (Exception ex)
            {
                exitCode = 1;

                Console.WriteLine("[ERROR!]: {0}",
                                  ex.GetBaseException());
            }

            Console.WriteLine();
            Console.WriteLine();

#if DEBUG
            Console.WriteLine("===== ENTER =====");
            Console.ReadLine();
#endif

            return exitCode;
        }

        #endregion Methods (1)
    }
}