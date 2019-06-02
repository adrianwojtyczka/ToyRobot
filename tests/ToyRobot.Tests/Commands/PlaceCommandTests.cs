using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using Xunit;

namespace ToyRobot.Tests.Commands
{
    public class PlaceCommandTests
    {
        [Fact]
        public void Execute_RobotAndCoordinatesAndFacingGiven_ShouldCallRobotPlaceMethodWithCorrectCoordinatesAndFacing()
        {
            const int x = 2;
            const int y = 2;
            const Direction facing = Direction.South;

            // Arrange
            var robotMock = new Mock<IRobot>();
            var placeCommand = new PlaceCommand(x, y, facing);

            // Act
            placeCommand.Execute(robotMock.Object);

            // Assert
            robotMock.Verify(robot => robot.Place(x, y, facing), Times.Once());
        }
    }
}
