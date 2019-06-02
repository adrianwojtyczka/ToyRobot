using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using ToyRobot.IO;

namespace ToyRobot.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Arguments</param>
        static void Main(string[] args)
        {
            // Build service provider
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IApplication, Application>()
                .AddSingleton<ICommandFactory, CommandFactory>()
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddTransient<IInput, StandardInput>()
                .AddTransient<IOutput, StandardOutput>()
                .AddTransient<IRobot, Robot>()
                .AddLogging(config =>
                {
                    config.AddProvider(new SerilogLoggerProvider(
                        new LoggerConfiguration()
                        .ReadFrom.AppSettings()
                        .CreateLogger()
                    ));
                })
                .BuildServiceProvider();

            // Run the application
            serviceProvider.GetRequiredService<IApplication>().Run();
        }
    }
}
