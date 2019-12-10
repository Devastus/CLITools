using System;

namespace CLITools
{
    /// <summary>
    /// Utilities for colorizing console printing
    /// </summary>
    public static class Color
    {
        /// <summary>
        /// Write to the console with color
        /// </summary>
        /// <param name="foreground"></param>
        /// <param name="background"></param>
        /// <param name="obj"></param>
        public static void Write(ConsoleColor foreground, ConsoleColor background, params object[] obj)
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
        public static void WriteLine(ConsoleColor foreground, ConsoleColor background, params object[] obj)
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
