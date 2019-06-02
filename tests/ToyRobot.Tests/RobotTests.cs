using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.IO;
using Xunit;

namespace ToyRobot.Tests
{
    public class RobotTests
    {
        #region Constants

        private const string ReportMessageFormat = "{0},{1},{2}";

        #endregion

        #region Place method tests

        [Theory]
        [InlineData(0, 0, Direction.North)]
        [InlineData(0, 4, Direction.East)]
        [InlineData(4, 0, Direction.South)]
        [InlineData(4, 4, Direction.West)]
        public void Place_AtValidCoordinatesAndFacing_ShouldBeOnSetCoordinatesAndFacing(int x, int y, Direction facing)
        {
            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.Place(x, y, facing);

            // Assert
            Assert.Equal(x, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(facing, robot.Facing);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(5, 5)]
        [InlineData(-1, 0)]
        [InlineData(5, 4)]
        [InlineData(0, -1)]
        [InlineData(4, 5)]
        public void Place_AtInvalidCoordinates_ShouldThrowRobotException(int x, int y)
        {
            const Direction facing = Direction.North;

            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.Place(x, y, facing);

            // Assert
            Assert.Throws<RobotException>(() => robot.X);
            Assert.Throws<RobotException>(() => robot.Y);
            Assert.Throws<RobotException>(() => robot.Facing);
        }

        #endregion

        #region Move method tests

        [Theory]
        [InlineData(2, 2, Direction.North, 2, 3)]
        [InlineData(2, 2, Direction.South, 2, 1)]
        [InlineData(2, 2, Direction.West, 1, 2)]
        [InlineData(2, 2, Direction.East, 3, 2)]
        public void Move_PlaceAndMoveOneUnitForward_ShouldBeAtNextCoordinate(int x, int y, Direction facing, int expectedX, int expectedY)
        {
            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.Place(x, y, facing);
            robot.Move();

            // Assert
            Assert.Equal(expectedX, robot.X);
            Assert.Equal(expectedY, robot.Y);
            Assert.Equal(facing, robot.Facing);
        }

        [Fact]
        public void Move_WithoutPlacing_ShouldThrowRobotException()
        {
            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.Move();

            // Assert
            Assert.Throws<RobotException>(() => robot.X);
            Assert.Throws<RobotException>(() => robot.Y);
            Assert.Throws<RobotException>(() => robot.Facing);
        }

        [Theory]
        [InlineData(2, 4, Direction.North)]
        [InlineData(2, 0, Direction.South)]
        [InlineData(0, 2, Direction.West)]
        [InlineData(4, 2, Direction.East)]
        public void Move_PlaceAtBoundAndMoveOutsideBounds_ShouldBeAtPlacedCoordinates(int x, int y, Direction facing)
        {
            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.Place(x, y, facing);
            robot.Move();

            // Assert
            Assert.Equal(x, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(facing, robot.Facing);
        }

        #endregion

        #region Rotate methods tests

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        public void RotateLeft_PlaceAndRotateLeft_ShouldBeFacingPreviousDirection(Direction facing, Direction expectedFacing)
        {
            const int x = 2;
            const int y = 2;

            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.Place(x, y, facing);
            robot.RotateLeft();

            // Assert
            Assert.Equal(x, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(expectedFacing, robot.Facing);
        }

        [Fact]
        public void RotateLeft_WithoutPlacing_ShouldThrowRobotException()
        {
            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.RotateLeft();

            // Assert
            Assert.Throws<RobotException>(() => robot.X);
            Assert.Throws<RobotException>(() => robot.Y);
            Assert.Throws<RobotException>(() => robot.Facing);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void RotateRight_PlaceAndRotateRight_ShouldBeFacingNextDirection(Direction facing, Direction expectedFacing)
        {
            const int x = 2;
            const int y = 2;

            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.Place(x, y, facing);
            robot.RotateRight();

            // Assert
            Assert.Equal(x, robot.X);
            Assert.Equal(y, robot.Y);
            Assert.Equal(expectedFacing, robot.Facing);
        }

        [Fact]
        public void RotateRight_WithoutPlacing_ShouldThrowRobotException()
        {
            // Arrange
            var robot = TestHelper.CreateRobot();

            // Act
            robot.RotateRight();

            // Assert
            Assert.Throws<RobotException>(() => robot.X);
            Assert.Throws<RobotException>(() => robot.Y);
            Assert.Throws<RobotException>(() => robot.Facing);
        }

        #endregion

        #region Report tests

        [Fact]
        public void Report_PlaceAndReportOnGivenOutput_ShouldWritePlacedCoordinatesAndFacing()
        {
            const int x = 2;
            const int y = 2;
            const Direction facing = Direction.North;

            // Arrange
            var robot = TestHelper.CreateRobot();

            var outputMock = new Mock<IOutput>();

            // Act
            robot.Place(x, y, facing);
            robot.Report(outputMock.Object);

            // Assert
            outputMock.Verify(output => output.WriteLine(string.Format(ReportMessageFormat, x, y, facing.ToString().ToUpper())), Times.Once());
        }

        [Fact]
        public void Report_ReportOnGivenOutput_ShouldNotWrite()
        {
            const int x = 2;
            const int y = 2;
            const Direction facing = Direction.North;

            // Arrange
            var robot = TestHelper.CreateRobot();

            var outputMock = new Mock<IOutput>();

            // Act
            robot.Report(outputMock.Object);

            // Assert
            outputMock.Verify(output => output.WriteLine(string.Format(ReportMessageFormat, x, y, facing.ToString().ToUpper())), Times.Never());
        }

        #endregion
    }
}

