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
    public class RotateRightCommandTests
    {
        [Fact]
        public void Execute_RobotGiven_ShouldCallRobotRotateRightMethod()
        {
            // Arrange
            var robotMock = new Mock<IRobot>();

            var rotateRightCommand = new RotateRightCommand();

            // Act
            rotateRightCommand.Execute(robotMock.Object);

            // Assert
            robotMock.Verify(robot => robot.RotateRight(), Times.Once());
        }
    }
}
