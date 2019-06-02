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
    public class ReportCommandTests
    {
        [Fact]
        public void Execute_RobotAndOutputGiven_ShouldCallRobotReportMethod()
        {
            // Arrange
            var robotMock = new Mock<IRobot>();
            var outputMock = new Mock<IOutput>();

            var reportCommand = new ReportCommand(outputMock.Object);

            // Act
            reportCommand.Execute(robotMock.Object);

            // Assert
            robotMock.Verify(robot => robot.Report(outputMock.Object), Times.Once());
        }
    }
}
