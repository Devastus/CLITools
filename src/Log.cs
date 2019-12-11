using System;

namespace Devastus
{
    namespace CLITools
    {
        /// <summary>
        /// Utilities for colorizing console printing
        /// </summary>
        public static class Log
        {
            /// <summary>
            /// Wrapper for Console.Write
            /// </summary>
            /// <param name="obj"></param>
            public static void Write(params object[] obj)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
            }

            /// <summary>
            /// Wrapper for Console.WriteLine
            /// </summary>
            /// <param name="obj"></param>
            public static void WriteLine(params object[] obj)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            /// <summary>
            /// Write to the console with color
            /// </summary>
            /// <param name="foreground"></param>
            /// <param name="background"></param>
            /// <param name="obj"></param>
            public static void WriteColor(ConsoleColor foreground, ConsoleColor background, params object[] obj)
            {
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                for(int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.ResetColor();
            }

            /// <summary>
            /// Write a full line to the console with color
            /// </summary>
            /// <param name="foreground"></param>
            /// <param name="background"></param>
            /// <param name="obj"></param>
            public static void WriteLineColor(ConsoleColor foreground, ConsoleColor background, params object[] obj)
            {
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
                Console.ResetColor();
            }
        }
    }
}
