using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.IO
{
    public class StandardOutput : IOutput
    {
        /// <summary>
        /// Writes the message to the standard output
        /// </summary>
        /// <param name="message">Message to write to the standard output</param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
