using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public static class Utils
    {
        private const string DirectionNamesSeparator = ",";

        /// <summary>
        /// Concatenates the names of the constants in a specified enumeration, using the specified separator
        /// </summary>
        /// <param name="enumType">An enumeration type</param>
        /// <param name="separator">The string to use as a separator</param>
        /// <returns>A string that consists of the names of the constants in a specified enumeration delimited by the separator string</returns>
        public static string GetDirectionNames()
        {
            var enumNames = Enum.GetNames(typeof(Direction));
            return string.Join(DirectionNamesSeparator, enumNames);
        }
    }
}
