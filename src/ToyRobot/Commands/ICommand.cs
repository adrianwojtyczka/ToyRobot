using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Executes the command on the robot
        /// </summary>
        /// <param name="robot">Robot on which execute the command</param>
        void Execute(IRobot robot);
    }
}
