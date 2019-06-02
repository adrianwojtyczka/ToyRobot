using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.IO
{
    public class StandardInput : IInput
    {
        /// <summary>
        /// Reads the value from the standard input
        /// </summary>
        /// <returns>Returns the value read from the standard input</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
