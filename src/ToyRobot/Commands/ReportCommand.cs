using System;
using ToyRobot.IO;

namespace ToyRobot.Commands
{
    public class ReportCommand : ICommand
    {
        #region Private members

        /// <summary>
        /// Output on which report the coordinates and facing direction
        /// </summary>
        private readonly IOutput _output;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="output">Output on which report the coordinates and facing direction</param>
        public ReportCommand(IOutput output)
        {
            _output = output;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute the report command on the robot
        /// </summary>
        /// <param name="robot">Robot on which execute the report command</param>
        public void Execute(IRobot robot)
        {
            robot.Report(_output);
        }

        #endregion
    }
}