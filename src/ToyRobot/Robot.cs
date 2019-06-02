using System;
using ToyRobot.IO;
using static ToyRobot.Resources.Robot;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        #region Constants

        /// <summary>
        /// Table lower X bound
        /// </summary>
        private const int LowerXBound = 0;

        /// <summary>
        /// Table lower Y bound
        /// </summary>
        private const int LowerYBound = 0;

        /// <summary>
        /// Table upper X bound
        /// </summary>
        private const int UpperXBound = 4;

        /// <summary>
        /// Table upper Y bound
        /// </summary>
        private const int UpperYBound = 4;

        #endregion

        #region Private members

        /// <summary>
        /// Robot current X coordinate
        /// </summary>
        private int _x;

        /// <summary>
        /// Robot current Y coordinate
        /// </summary>
        private int _y;

        /// <summary>
        /// Robot current facing direction
        /// </summary>
        private Direction _facing;

        /// <summary>
        /// Indicates if the robot is on the table
        /// </summary>
        private bool _isPlaced;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Robot()
        { }

        #endregion

        #region Public methods

        /// <summary>
        /// Places the robot on given coordinates and facing direction
        /// </summary>
        /// <param name="x">X coordinate on which place the robot</param>
        /// <param name="y">Y coordinate on which place the robot</param>
        /// <param name="facing">Facing direction</param>
        public void Place(int x, int y, Direction facing)
        {
            // Doesn't place the robot if the coordinates are out of bound
            if (x < LowerXBound || x > UpperXBound ||
                y < LowerYBound || y > UpperYBound)
                return;

            // Set the robot coordinates
            _x = x;
            _y = y;
            _facing = facing;
            _isPlaced = true;
        }

        /// <summary>
        /// Moves the robot one step on the facing direction
        /// </summary>
        public void Move()
        {
            // If the robot is not already placed, ignore
            if (!_isPlaced)
                return;

            // Move the robot to the facing direction
            switch(_facing)
            {
                case Direction.North:
                    if (_y < UpperYBound)
                        _y++;
                    break;

                case Direction.South:
                    if (_y > LowerYBound)
                        _y--;
                    break;

                case Direction.East:
                    if (_x < UpperXBound)
                        _x++;
                    break;

                case Direction.West:
                    if (_x > LowerXBound)
                        _x--;
                    break;
            }
        }

        /// <summary>
        /// Rotates the robot to the left
        /// </summary>
        public void RotateLeft()
        {
            // If the robot is not already placed, ignore
            if (!_isPlaced)
                return;

            // Set previous facing direction
            var facingDirectionInt = (int)_facing;
            facingDirectionInt--;

            // Set the west facing direction while rotating left from north
            if (facingDirectionInt == -1)
                facingDirectionInt = (int)Direction.West;

            // Set facing direction
            _facing = (Direction)facingDirectionInt;
        }

        /// <summary>
        /// Rotates the robot to the right
        /// </summary>
        public void RotateRight()
        {
            // If the robot is not already placed, ignore
            if (!_isPlaced)
                return;

            // Set next facing direction
            var facingDirectionInt = (int)_facing;
            facingDirectionInt++;

            // Set the north facing direction while rotating right from west
            if (facingDirectionInt == 4)
                facingDirectionInt = (int)Direction.North;

            // Set facing direction
            _facing = (Direction)facingDirectionInt;
        }

        /// <summary>
        /// Reports the robot coordinates and facing to the given output
        /// </summary>
        /// <param name="output">Output to which report the coordinates and facing</param>
        public void Report(IOutput output)
        {
            // If the robot is not already placed, ignore
            if (!_isPlaced)
                return;

            var message = string.Format(ReportFormat, _x, _y, _facing.ToString().ToUpper());
            output.WriteLine(message);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get robot current X coordinate
        /// </summary>
        /// <exception cref="RobotException">Exception throwed when the robot was not already placed</exception>
        public int X
        {
            get
            {
                if (!_isPlaced)
                    throw new RobotException(RobotNotPlaced);

                return _x;
            }
        }

        /// <summary>
        /// Get robot current Y coordinate
        /// </summary>
        /// <exception cref="RobotException">Exception throwed when the robot was not already placed</exception>
        public int Y
        {
            get
            {
                if (!_isPlaced)
                    throw new RobotException(RobotNotPlaced);

                return _y;
            }
        }

        /// <summary>
        /// Get robot current facing direction
        /// </summary>
        /// <exception cref="RobotException">Exception throwed when the robot was not already placed</exception>
        public Direction Facing
        {
            get
            {
                if (!_isPlaced)
                    throw new RobotException(RobotNotPlaced);

                return _facing;
            }
        }

        #endregion
    }
}