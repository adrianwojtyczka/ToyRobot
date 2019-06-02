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
    public class MoveCommandTests
    {
        [Fact]
        public void Execute_RobotGiven_ShouldCallRobotMoveMethod()
        {
            // Arrange
            var robotMock = new Mock<IRobot>();
            var moveCommand = new MoveCommand();

            // Act
            moveCommand.Execute(robotMock.Object);

            // Assert
            robotMock.Verify(robot => robot.Move(), Times.Once());
        }
    }
}
