using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using ToyRobot.IO;
using Xunit;

namespace ToyRobot.Tests.Commands
{
    public class CommandFactoryTests
    {
        #region CreateCommand method - place command tests

        [Fact]
        public void CreateCommand_PlaceCommandNameAndCoordinatesAndFacingGiven_ShouldCreatePlaceCommandWithPassedCoordinatesAndFacing()
        {
            const int x = 1;
            const int y = 3;
            const Direction facing = Direction.East;

            // Arrange
            var commandFactory = TestHelper.CreateCommandFactory();

            string placeCommandString = CommandFactory.PlaceCommandName +
                CommandFactory.CommandNameParametersSeparator + x +
                CommandFactory.CommandParametersSeparator + y +
                CommandFactory.CommandParametersSeparator + facing.ToString().ToUpper();

            // Act
            var placeCommand = commandFactory.CreateCommand(placeCommandString);

            // Assert
            Assert.IsType<PlaceCommand>(placeCommand);
            Assert.Equal(x, (placeCommand as PlaceCommand).X);
            Assert.Equal(y, (placeCommand as PlaceCommand).Y);
            Assert.Equal(facing, (placeCommand as PlaceCommand).Facing);
        }

        [Fact]
        public void CreateCommand_PlaceCommandNameAndFirstCoordinateWrongType_ShouldThrowInvalidCommandException()
        {
            const string x = "x";
            const int y = 3;
            const Direction facing = Direction.East;

            // Arrange
            string placeCommandString = CommandFactory.PlaceCommandName +
                CommandFactory.CommandNameParametersSeparator + x +
                CommandFactory.CommandParametersSeparator + y +
                CommandFactory.CommandParametersSeparator + facing.ToString().ToUpper();

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var exception = Record.Exception(() => commandFactory.CreateCommand(placeCommandString));

            // Assert
            Assert.IsType<InvalidCommandException>(exception);
        }

        [Fact]
        public void CreateCommand_PlaceCommandNameAndSecondCoordinateWrongType_ShouldThrowInvalidCommandException()
        {
            const int x = 1;
            const string y = "y";
            const Direction facing = Direction.East;

            // Arrange
            string placeCommandString = CommandFactory.PlaceCommandName +
                CommandFactory.CommandNameParametersSeparator + x +
                CommandFactory.CommandParametersSeparator + y +
                CommandFactory.CommandParametersSeparator + facing.ToString().ToUpper();

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var exception = Record.Exception(() => commandFactory.CreateCommand(placeCommandString));

            // Assert
            Assert.IsType<InvalidCommandException>(exception);
        }

        [Fact]
        public void CreateCommand_PlaceCommandNameAndDirectionInvalidName_ShouldThrowInvalidCommandException()
        {
            const int x = 1;
            const int y = 3;
            const string facing = "direction";

            // Arrange
            string placeCommandString = CommandFactory.PlaceCommandName +
                CommandFactory.CommandNameParametersSeparator + x +
                CommandFactory.CommandParametersSeparator + y +
                CommandFactory.CommandParametersSeparator + facing.ToString().ToUpper();

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var exception = Record.Exception(() => commandFactory.CreateCommand(placeCommandString));

            // Assert
            Assert.IsType<InvalidCommandException>(exception);
        }

        [Fact]
        public void CreateCommand_PlaceCommandNameWithLessParameters_ShouldThrowInvalidCommandException()
        {
            const int x = 1;
            const int y = 3;

            // Arrange
            string placeCommandString = CommandFactory.PlaceCommandName +
                CommandFactory.CommandNameParametersSeparator + x +
                CommandFactory.CommandParametersSeparator + y;

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var exception = Record.Exception(() => commandFactory.CreateCommand(placeCommandString));

            // Assert
            Assert.IsType<InvalidCommandException>(exception);
        }

        [Fact]
        public void CreateCommand_PlaceCommandNameWithMoreParameters_ShouldThrowInvalidCommandException()
        {
            const int x = 1;
            const int y = 3;
            const Direction facing = Direction.East;

            // Arrange
            string placeCommandString = CommandFactory.PlaceCommandName +
                CommandFactory.CommandNameParametersSeparator + x +
                CommandFactory.CommandParametersSeparator + y +
                CommandFactory.CommandParametersSeparator + facing.ToString().ToUpper() +
                CommandFactory.CommandParametersSeparator;

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var exception = Record.Exception(() => commandFactory.CreateCommand(placeCommandString));

            // Assert
            Assert.IsType<InvalidCommandException>(exception);
        }

        #endregion

        #region CreateCommand method - move command tests

        [Fact]
        public void CreateCommand_MoveCommandName_ShouldCreateMoveCommand()
        {
            // Arrange
            string moveCommandString = CommandFactory.MoveCommandName;

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var moveCommand = commandFactory.CreateCommand(moveCommandString);

            // Assert
            Assert.IsType<MoveCommand>(moveCommand);
        }

        #endregion

        #region CreateCommand method - rotate commands tests

        [Fact]
        public void CreateCommand_LeftCommandName_ShouldCreateRotateLeftCommand()
        {
            // Arrange
            string leftCommandString = CommandFactory.LeftCommandName;

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var rotateLeftCommand = commandFactory.CreateCommand(leftCommandString);

            // Assert
            Assert.IsType<RotateLeftCommand>(rotateLeftCommand);
        }

        [Fact]
        public void CreateCommand_RightCommandName_ShouldCreateRotateRightCommand()
        {
            // Arrange
            string rightCommandString = CommandFactory.RightCommandName;

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var rotateRightCommand = commandFactory.CreateCommand(rightCommandString);

            // Assert
            Assert.IsType<RotateRightCommand>(rotateRightCommand);
        }

        #endregion

        #region CreateCommand method - report command tests

        [Fact]
        public void CreateCommand_ReportCommandNameWithOutput_SholdCreateReportCommandWithGivenOutput()
        {
            // Arrange
            string reportCommandString = CommandFactory.ReportCommandName;

            var commandFactory = TestHelper.CreateCommandFactory();

            // Act
            var reportCommand = commandFactory.CreateCommand(reportCommandString);

            // Assert
            Assert.IsType<ReportCommand>(reportCommand);
        }

        #endregion
    }
}
