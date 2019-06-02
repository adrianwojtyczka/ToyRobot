using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using ToyRobot.IO;
using static ToyRobot.ConsoleApp.Resources.Application;

namespace ToyRobot.ConsoleApp
{
    public class Application : IApplication
    {
        /// <summary>
        /// Input from which read the commands
        /// </summary>
        private readonly IInput _input;

        /// <summary>
        /// Output to which write reports
        /// </summary>
        private readonly IOutput _output;

        /// <summary>
        /// Command factory
        /// </summary>
        private readonly ICommandFactory _commandFactory;

        /// <summary>
        /// Robot on which execute the commands
        /// </summary>
        private readonly IRobot _robot;

        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<Application> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input">Input from which read the commands</param>
        /// <param name="output">Output to which write reports</param>
        /// <param name="commandFactory">Command factory</param>
        /// <param name="robot">Robot on which execute the commands</param>
        /// <param name="logger">Logger</param>
        public Application(IInput input, IOutput output, ICommandFactory commandFactory, IRobot robot, ILogger<Application> logger)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
            _robot = robot ?? throw new ArgumentNullException(nameof(robot));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Runs the application
        /// </summary>
        public void Run()
        {
            for (; ; )
            {
                try
                {
                    // Get command
                    _output.WriteLine(InsertCommand);
                    var message = _input.ReadLine();

                    // Log inserted command
                    _logger.LogInformation(string.Format(LogInsertedCommand, message));

                    // Execute command
                    var command = _commandFactory.CreateCommand(message);
                    command.Execute(_robot);
                }
                catch (InvalidCommandException ex)
                {
                    _logger.LogWarning(ex.Message);
                    _output.WriteLine(ex.Message);
                }
                catch (RobotException ex)
                {
                    _logger.LogWarning(ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
            }
        }
    }
}
