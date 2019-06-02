using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests
{
    public class CreateAndExecuteCommandTests
    {
        const int x = 1;
        const int y = 2;
        const Direction facing = Direction.East;

        [Fact]
        public void CreateAndExecuteCommand_PlaceCommandGiven_ShouldPlaceRobotOnGivenCoordinates()
        {
            // Arrange
            var commandFactory = TestHelper.CreateCommandFactory();
            var robot = TestHelper.CreateRobot();

            // Act
            ExecutePlaceCommand(x, y, facing, commandFactory, robot);

            // Assert
            Assert.Equal(x, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(facing, robot.Facing);
        }

        [Fact]
        public void CreateAndExecuteCommand_PlaceAndMoveCommandsGiven_ShouldMoveRobotToTheFacingDirection()
        {
            // Arrange
            var commandFactory = TestHelper.CreateCommandFactory();
            var robot = TestHelper.CreateRobot();

            // Act
            ExecutePlaceCommand(x, y, facing, commandFactory, robot);
            var moveCommand = commandFactory.CreateCommand(CommandFactory.MoveCommandName);
            moveCommand.Execute(robot);

            // Assert
            Assert.Equal(x + 1, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(facing, robot.Facing);
        }

        [Fact]
        public void CreateAndExecuteCommand_PlaceAndRotateLeftCommandsGiven_ShouldRotateRobotToTheLeftAtPlacedCoordinates()
        {
            // Arrange
            var commandFactory = TestHelper.CreateCommandFactory();
            var robot = TestHelper.CreateRobot();

            // Act
            ExecutePlaceCommand(x, y, facing, commandFactory, robot);
            var rotateLeftCommand = commandFactory.CreateCommand(CommandFactory.LeftCommandName);
            rotateLeftCommand.Execute(robot);

            // Assert
            Assert.Equal(x, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(Direction.North, robot.Facing);
        }

        [Fact]
        public void CreateAndExecuteCommand_PlaceAndRotateRightCommandsGiven_ShouldRotateRobotToTheRightAtPlacedCoordinates()
        {
            // Arrange
            var commandFactory = TestHelper.CreateCommandFactory();
            var robot = TestHelper.CreateRobot();

            // Act
            ExecutePlaceCommand(x, y, facing, commandFactory, robot);
            var rotateRightCommand = commandFactory.CreateCommand(CommandFactory.RightCommandName);
            rotateRightCommand.Execute(robot);

            // Assert
            Assert.Equal(x, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(Direction.South, robot.Facing);
        }

        [Fact]
        public void CreateAndExecuteCommand_PlaceAndReportCommandsGiven_ShouldReportPlacedCoordinates()
        {
            // Arrange
            var commandFactory = TestHelper.CreateCommandFactory(out var outputMock);
            var robot = TestHelper.CreateRobot();

            // Act
            ExecutePlaceCommand(x, y, facing, commandFactory, robot);
            var reportCommand = commandFactory.CreateCommand(CommandFactory.ReportCommandName);
            reportCommand.Execute(robot);

            // Assert
            outputMock.Verify(output => output.WriteLine($"{x},{y},{facing.ToString().ToUpper()}"), Times.Once());
        }

        #region Helper methods

        private void ExecutePlaceCommand(int x, int y, Direction facing, CommandFactory commandFactory, Robot robot)
        {
            // Create place command input
            string placeCommandString = CommandFactory.PlaceCommandName +
                            CommandFactory.CommandNameParametersSeparator + x +
                            CommandFactory.CommandParametersSeparator + y +
                            CommandFactory.CommandParametersSeparator + facing;

            // Create and execute place command
            var placeCommand = commandFactory.CreateCommand(placeCommandString);
            placeCommand.Execute(robot);
        }

        #endregion
    }
}
