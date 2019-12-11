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
            public enum Level
            {
                None = 0,
                Error = 1,
                Warn = 2,
                Info = 3,
                Debug = 4,
                Trace = 5
            }

            enum LevelColor
            {
                Error = ConsoleColor.Red,
                Warn = ConsoleColor.Yellow,
                Info = ConsoleColor.Green,
                Debug = ConsoleColor.Cyan,
                Trace = ConsoleColor.Gray
            }

            private static Level logLevel = Level.Info;
            private static bool useTimestamp = false;

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
                SetConsoleColor(foreground, background);
                for (int i = 0; i < obj.Length; i++)
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
                SetConsoleColor(foreground, background);
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
                Console.ResetColor();
            }

            /// <summary>
            /// Set the level of what messages get printed to the log
            /// </summary>
            /// <param name="level"></param>
            public static void SetLogLevel(Level level)
            {
                logLevel = level;
            }

            /// <summary>
            /// Toggle timestamp in log messages
            /// </summary>
            /// <param name="timestamp"></param>
            public static void ToggleTimestamp(bool timestamp)
            {
                useTimestamp = timestamp;
            }

            /// <summary>
            /// Print an error message
            /// </summary>
            /// <param name="obj"></param>
            public static void Error(params object[] obj)
            {
                if (logLevel < Level.Error) return;
                SetConsoleColor((ConsoleColor)LevelColor.Error);
                PrintTimestamp();
                Console.Write("[ERROR] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            /// <summary>
            /// Print a warning message
            /// </summary>
            /// <param name="obj"></param>
            public static void Warn(params object[] obj)
            {
                if (logLevel < Level.Warn) return;
                SetConsoleColor((ConsoleColor)LevelColor.Warn);
                PrintTimestamp();
                Console.Write("[WARN] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            /// <summary>
            /// Print an info message
            /// </summary>
            /// <param name="obj"></param>
            public static void Info(params object[] obj)
            {
                if (logLevel < Level.Info) return;
                SetConsoleColor((ConsoleColor)LevelColor.Info);
                PrintTimestamp();
                Console.Write("[INFO] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            /// <summary>
            /// Print a debug message
            /// </summary>
            /// <param name="obj"></param>
            public static void Debug(params object[] obj)
            {
                if (logLevel < Level.Debug) return;
                SetConsoleColor((ConsoleColor)LevelColor.Debug);
                PrintTimestamp();
                Console.Write("[DEBUG] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            /// <summary>
            /// Print a trace message
            /// </summary>
            /// <param name="obj"></param>
            public static void Trace(params object[] obj)
            {
                if (logLevel < Level.Trace) return;
                SetConsoleColor((ConsoleColor)LevelColor.Trace);
                PrintTimestamp();
                Console.Write("[TRACE] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            private static void PrintTimestamp()
            {
                if (useTimestamp)
                {
                    Console.Write($"[{System.DateTime.Now.ToString()}] ");
                }
            }

            private static void SetConsoleColor(ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
            {
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
            }
        }
    }
}
