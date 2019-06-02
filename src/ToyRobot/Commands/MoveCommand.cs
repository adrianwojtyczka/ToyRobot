using System;

namespace ToyRobot.Commands
{
    public class MoveCommand : ICommand
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MoveCommand()
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Execute the move command on the robot
        /// </summary>
        /// <param name="robot">Robot on which execute the move command</param>
        public void Execute(IRobot robot)
        {
            robot.Move();
        }

        #endregion
    }
}