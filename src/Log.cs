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
                Debug = ConsoleColor.White,
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

            public static void SetLogLevel(Level level)
            {
                logLevel = level;
            }

            public static void ToggleTimestamp(bool timestamp)
            {
                useTimestamp = timestamp;
            }

            public static void Error(params object[] obj)
            {
                if (logLevel < Level.Error) return;
                Console.ForegroundColor = (ConsoleColor)LevelColor.Error;
                Console.BackgroundColor = ConsoleColor.Black;
                PrintTimestamp();
                Console.Write("[ERROR] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            public static void Warn(params object[] obj)
            {
                if (logLevel < Level.Warn) return;
                Console.ForegroundColor = (ConsoleColor)Level.Warn;
                Console.BackgroundColor = ConsoleColor.Black;
                PrintTimestamp();
                Console.Write("[WARN] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            public static void Info(params object[] obj)
            {
                if (logLevel < Level.Info) return;
                Console.ForegroundColor = (ConsoleColor)Level.Info;
                Console.BackgroundColor = ConsoleColor.Black;
                PrintTimestamp();
                Console.Write("[INFO] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            public static void Debug(params object[] obj)
            {
                if (logLevel < Level.Debug) return;
                Console.ForegroundColor = (ConsoleColor)Level.Debug;
                Console.BackgroundColor = ConsoleColor.Black;
                PrintTimestamp();
                Console.Write("[DEBUG] ");
                Console.ResetColor();
                for (int i = 0; i < obj.Length; i++)
                {
                    Console.Write(obj[i]);
                }
                Console.Write("\n");
            }

            public static void Trace(params object[] obj)
            {
                if (logLevel < Level.Trace) return;
                Console.ForegroundColor = (ConsoleColor)Level.Trace;
                Console.BackgroundColor = ConsoleColor.Black;
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
        }
    }
}
