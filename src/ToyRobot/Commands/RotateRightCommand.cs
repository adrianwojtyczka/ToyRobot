using System;

namespace ToyRobot.Commands
{
    public class RotateRightCommand : ICommand
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RotateRightCommand()
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Execute the rotate right command on the robot
        /// </summary>
        /// <param name="robot">Robot on which execute the rotate right command</param>
        public void Execute(IRobot robot)
        {
            robot.RotateRight();
        }

        #endregion
    }
}