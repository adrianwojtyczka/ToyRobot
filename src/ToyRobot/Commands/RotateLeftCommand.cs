using System;

namespace ToyRobot.Commands
{
    public class RotateLeftCommand : ICommand
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RotateLeftCommand()
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Execute the rotate left command on the robot
        /// </summary>
        /// <param name="robot">Robot on which execute the rotate left command</param>
        public void Execute(IRobot robot)
        {
            robot.RotateLeft();
        }

        #endregion
    }
}