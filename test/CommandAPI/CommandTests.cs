using CommandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommandAPI.Tests
{
    public class CommandTests: IDisposable

    {
        Command testCommand;
        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Arrange
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };
            //Act
            testCommand.HowTo = "Execute Unit Tests";
            //Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform()
        {
            //Arrange
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "Esto cambiara",
                CommandLine = "dotnet test"
            };
            //Act
            testCommand.Platform = "Esto cambiara";
            //Assert
            Assert.Equal("Esto cambiara", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {
            //Arrange
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "Esto cambiara",
                CommandLine = "Linea cambiada"
            };
            //Act
            testCommand.CommandLine = "Linea cambiada";
            //Assert
            Assert.Equal("Linea cambiada", testCommand.CommandLine);
        }
       
    }

}
