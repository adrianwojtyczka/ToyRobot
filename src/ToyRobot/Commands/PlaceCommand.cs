using System;

namespace ToyRobot.Commands
{
    public class PlaceCommand : ICommand
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X coordinate on which place the robot</param>
        /// <param name="y">Y coordinate on which place the robot</param>
        /// <param name="facing">Facing direction on which place the robot</param>
        public PlaceCommand(int x, int y, Direction facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute the place command on the robot
        /// </summary>
        /// <param name="robot">Robot on which execute the place command</param>
        public void Execute(IRobot robot)
        {
            robot.Place(X, Y, Facing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// X coordinate on which place the robots
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y coordinate on which place the robots
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Facing direction on which place the robot
        /// </summary>
        public Direction Facing { get; }

        #endregion
    }
}