using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.IO
{
    public interface IOutput
    {
        /// <summary>
        /// Writes the message to the standard output
        /// </summary>
        /// <param name="message">Message to write to the standard output</param>
        void WriteLine(string message);
    }
}
