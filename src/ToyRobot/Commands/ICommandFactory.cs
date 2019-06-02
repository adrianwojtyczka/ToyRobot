using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Commands
{
    public interface ICommandFactory
    {
        /// <summary>
        /// Creates the command corresponding to the string input
        /// </summary>
        /// <param name="input">Input from which create the command</param>
        /// <returns>Returns the command corresponding to the input string</returns>
        ICommand CreateCommand(string input);
    }
}
