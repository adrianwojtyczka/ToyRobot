using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.IO;

namespace ToyRobot
{
    public interface IRobot
    {
        /// <summary>
        /// Places the robot on given coordinates and facing direction
        /// </summary>
        /// <param name="x">X coordinate on which place the robot</param>
        /// <param name="y">Y coordinate on which place the robot</param>
        /// <param name="facing">Facing direction</param>
        void Place(int x, int y, Direction facing);

        /// <summary>
        /// Moves the robot one step to the facing direction
        /// </summary>
        void Move();

        /// <summary>
        /// Rotates the robot to the left
        /// </summary>
        void RotateLeft();

        /// <summary>
        /// Rotates the robot to the right
        /// </summary>
        void RotateRight();

        /// <summary>
        /// Reports the robot coordinates and facing to the given output
        /// </summary>
        /// <param name="output">Output to which report the coordinates and facing</param>
        void Report(IOutput output);

        /// <summary>
        /// Current X coordinate of the robot
        /// </summary>
        int X { get; }

        /// <summary>
        /// Current Y coordinate of the robot
        /// </summary>
        int Y { get; }

        /// <summary>
        /// Current facing direction of the robot
        /// </summary>
        Direction Facing { get; }
    }
}
