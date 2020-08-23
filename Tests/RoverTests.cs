using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using HepsiBurada.MarsRover.Infrastructure.Operations.ParserOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestFixture]
        public void TestCase_12N_LMLMLMLMM()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");

            _parse.Parser(commandStringBuilder.ToString());
            
            Assert.AreEqual("1 3 N", _plate.ToString());
        }
    }
}
