using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using ToyRobot.IO;

namespace ToyRobot.Tests
{
    internal class TestHelper
    {
        internal static CommandFactory CreateCommandFactory()
        {
            return CreateCommandFactory(out _);
        }

        internal static CommandFactory CreateCommandFactory(out Mock<IOutput> outputMock)
        {
            outputMock = new Mock<IOutput>();

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(mock => mock.GetService(typeof(IOutput))).Returns(outputMock.Object);

            var commandFactory = new CommandFactory(serviceProviderMock.Object);

            return commandFactory;
        }

        internal static Robot CreateRobot()
        {
            var robot = new Robot();
            return robot;
        }
    }
}
