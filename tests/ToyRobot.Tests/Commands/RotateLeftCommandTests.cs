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
    public class RotateLeftCommandTests
    {
        [Fact]
        public void Execute_RobotGiven_ShouldCallRobotRotateLeftMethod()
        {
            // Arrange
            var robotMock = new Mock<IRobot>();

            var rotateLeftCommand = new RotateLeftCommand();

            // Act
            rotateLeftCommand.Execute(robotMock.Object);

            // Assert
            robotMock.Verify(robot => robot.RotateLeft(), Times.Once());
        }
    }
}
