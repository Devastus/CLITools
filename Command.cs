using System;
using System.Collections.Generic;

namespace Devastus
{
    namespace CLITools
    {
        /// <summary>
        /// Attribute to register a method to the command list
        /// </summary>
        public class Command: Attribute, IEquatable<Command>
        {
            private string name;
            public string Name { get { return name; } }
            private string description;
            public string Description { get { return description; } }

            public Command(string name, string description = "")
            {
                this.name = name;
                this.description = description;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Command);
            }

            public bool Equals(Command other)
            {
                return other != null &&
                       name == other.name;
            }

            public override int GetHashCode()
            {
                var hashCode = -1301573508;
                hashCode = hashCode * -1521134295 + base.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
                return hashCode;
            }

            public override string ToString()
            {
                string desc = description.Length > 0 ? " - " + description : "";
                return $"{name}{desc}";
            }
        }
    }
}
