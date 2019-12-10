using System;
using System.Collections.Generic;
using System.Reflection;

namespace CLITools
{
    /// <summary>
    /// Utility class for running registered commands
    /// </summary>
    public static class Cmd
    {
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

            if (args != null && args.Length > 0)
            {
                Command cmd = new Command(args[0]);
                MethodInfo method;
                if (cmdMap.TryGetValue(cmd, out method))
                {
                    return Invoke(method, args.Slice(1));
                }
                else
                {
                    Color.Write(ConsoleColor.Red, ConsoleColor.Black, "[ERROR]");
                    Console.WriteLine($": command '{cmd.Name}' does not exist");
                }
            }

            Help();
            return false;
        }

        /// <summary>
        /// Invoke the given command with arguments
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool Invoke(MethodInfo method, string[] args)
        {
            try
            {
                method.Invoke(null, new object[] { args });
                return true;
            }
            catch (TargetInvocationException tie)
            {
                var ex = tie.InnerException;
                Color.Write(ConsoleColor.Red, ConsoleColor.Black, "[ERROR]");
                Console.WriteLine(": " + ex.Message);
                return false;
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
