using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.IO
{
    public interface IInput
    {
        /// <summary>
        /// Reads the value from the standard input
        /// </summary>
        /// <returns>Returns the value read from the standard input</returns>
        string ReadLine();
    }
}
