using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ToyRobot.IO;
using static ToyRobot.Resources.Commands;

namespace ToyRobot.Commands
{
    public class CommandFactory : ICommandFactory
    {
        #region Constants

        /// <summary>
        /// Separator between command name and parameters
        /// </summary>
        public const char CommandNameParametersSeparator = ' ';

        /// <summary>
        /// Separator between parameters
        /// </summary>
        public const char CommandParametersSeparator = ',';

        /// <summary>
        /// Place command name
        /// </summary>
        public const string PlaceCommandName = "PLACE";

        /// <summary>
        /// Move command name
        /// </summary>
        public const string MoveCommandName = "MOVE";

        /// <summary>
        /// Rotate left command name
        /// </summary>
        public const string LeftCommandName = "LEFT";

        /// <summary>
        /// Rotate right command name
        /// </summary>
        public const string RightCommandName = "RIGHT";

        /// <summary>
        /// Report command name
        /// </summary>
        public const string ReportCommandName = "REPORT";

        #endregion

        #region Private members

        /// <summary>
        /// Service provider used for DI
        /// </summary>
        private readonly IServiceProvider _services;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="services">Service provider</param>
        public CommandFactory(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the command corresponding to the string input.
        /// </summary>
        /// <param name="input">Input from which create the command.</param>
        /// <returns>Returns the command corresponding to the input string.</returns>
        /// <exception cref="InvalidCommandException">Exception is thrown when the string input contains invalid command.</exception>
        public ICommand CreateCommand(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var commandNameParameters = input.Split(CommandNameParametersSeparator);
            switch (commandNameParameters[0].ToUpper())
            {
                case PlaceCommandName:
                    return CreatePlaceCommand(commandNameParameters[1]);

                case MoveCommandName:
                    return CreateMoveCommand();

                case LeftCommandName:
                    return CreateRotateLeftCommand();

                case RightCommandName:
                    return CreateRotateRightCommand();

                case ReportCommandName:
                    return CreateReportCommand();

                default:
                    throw new InvalidCommandException(string.Format(InvalidCommand, commandNameParameters[0]));
            }
        }

        /// <summary>
        /// Creates place command
        /// </summary>
        /// <param name="commandParameters">Command parameters</param>
        /// <returns>Returns created place command</returns>
        private PlaceCommand CreatePlaceCommand(string commandParameters)
        {
            // Check if the parameters are in correct number
            var commandParametersSplitted = commandParameters.Split(CommandParametersSeparator);
            if (commandParametersSplitted.Length != 3)
                throw new InvalidCommandException(string.Format(PlaceCommandInvalidNumberOfParameters, PlaceCommandName));

            // Check if the first parameter is an integer
            if (!int.TryParse(commandParametersSplitted[0], out var x))
                throw new InvalidCommandException(PlaceCommandInvalidFirstParameter);

            // Check if the second parameter is an integer
            if (!int.TryParse(commandParametersSplitted[1], out var y))
                throw new InvalidCommandException(PlaceCommandInvalidSecondParameter);

            // Check if the third parameter has the correct value
            if (!Enum.TryParse<Direction>(commandParametersSplitted[2], true, out var facing))
                throw new InvalidCommandException(string.Format(PlaceCommandInvalidThirdParameter, Utils.GetDirectionNames()));

            return new PlaceCommand(x, y, facing);
        }

        /// <summary>
        /// Creates move command
        /// </summary>
        /// <returns>Returns created move command</returns>
        private MoveCommand CreateMoveCommand()
        {
            return new MoveCommand();
        }

        /// <summary>
        /// Creates rotate left command
        /// </summary>
        /// <returns>Returns created rotate left command</returns>
        private RotateLeftCommand CreateRotateLeftCommand()
        {
            return new RotateLeftCommand();
        }

        /// <summary>
        /// Creates rotate right command
        /// </summary>
        /// <returns>Returns created rotate right command</returns>
        private RotateRightCommand CreateRotateRightCommand()
        {
            return new RotateRightCommand();
        }

        /// <summary>
        /// Creates report command
        /// </summary>
        /// <returns>Returns created report command</returns>
        private ReportCommand CreateReportCommand()
        {
            var output = _services.GetService<IOutput>();
            return new ReportCommand(output);
        }

        #endregion
    }
}