using System;
using System.Collections.Generic;
using System.Reflection;

namespace Devastus
{
    namespace CLITools
    {
        /// <summary>
        /// Utility class for running registered commands
        /// </summary>
        public static class Cmd
        {
            private const string HELP_CMD = "help";
            private static Dictionary<Command, MethodInfo> cmdMap;
        
            /// <summary>
            /// Parse given command line arguments and perform a command from the result
            /// </summary>
            /// <param name="args"></param>
            /// <returns>Boolean value of whether command was succesful or not</returns>
            public static bool Run(params string[] args)
            {
                if (cmdMap == null)
                {
                    Init();
                }

                if (args != null && args.Length > 0 && args[0] != HELP_CMD)
                {
                    try
                    {
                        Command cmd = new Command(args[0]);
                        MethodInfo method;
                        if (cmdMap.TryGetValue(cmd, out method))
                        {
                            Invoke(method, args.Slice(1));
                            return true;
                        }
                        else
                        {
                            throw new Exception($"Command '{cmd.Name}' does not exist");
                        }
                    }
                    catch (Exception e)
                    {
                        Color.Write(ConsoleColor.Red, ConsoleColor.Black, "[ERROR]");
                        Console.WriteLine($": {e.Message}");
                    }
                }
                else
                {
                    Help();
                }
                
                return false;
            }

            /// <summary>
            /// Clear stored commands from the command map
            /// </summary>
            public static void Clear()
            {
                cmdMap.Clear();
            }

            /// <summary>
            /// Invoke the given command with arguments
            /// </summary>
            /// <param name="method"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            private static void Invoke(MethodInfo method, string[] args)
            {
                try
                {
                    method.Invoke(null, new object[] { args });
                }
                catch (TargetInvocationException tie)
                {
                    throw tie.InnerException;
                }
            }

            /// <summary>
            /// Initialize the command map from methods decorated with Command attributes
            /// </summary>
            private static void Init()
            {
                cmdMap = new Dictionary<Command, MethodInfo>();
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach(var assembly in assemblies)
                {
                    Type[] types = assembly.GetTypes();
                    foreach(var type in types)
                    {
                        MethodInfo[] methods = type.GetMethods();
                        foreach(var method in methods)
                        {
                            if (!method.IsStatic) continue;
                            Command[] attributes = (Command[])method.GetCustomAttributes<Command>(false);
                            if (attributes.Length > 0 && !cmdMap.ContainsKey(attributes[0]))
                            {
                                cmdMap.Add(attributes[0], method);
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Print commands and their descriptions to the console
            /// </summary>
            private static void Help()
            {
                Color.WriteLine(ConsoleColor.Yellow, ConsoleColor.Black, "Available commands:");
                var keys = cmdMap.Keys;
                if (keys.Count > 0)
                {
                    foreach(var key in keys)
                    {
                        MethodInfo method = cmdMap[key];
                        var parameters = method.GetParameters();
                        Color.Write(ConsoleColor.Green, ConsoleColor.Black, key.Name);
                        Console.WriteLine(" - " + key.Description);
                    }
                }
                else
                {
                    Console.WriteLine("None available");
                }
            }
        }
    }
}
