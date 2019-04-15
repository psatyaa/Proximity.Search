using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proximity.Search.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proximity.Search.UnitTest
{
    [TestClass]
    public class UtilitiesTest
    {
        public string[] Inputs { get; set; } =
        {
            "Mark", "Smith", "10","input.txt"
        };

        [TestMethod]
        
        public void CheckValidFileName()
        {
            Utilities utilities = new Utilities();
            var response = utilities.ValidateInputs(Inputs);
            //Incase of valid input file error response will be null.
            Assert.IsNull(response);
        }

        [TestMethod]
        public void CheckInValidFileName()
        {
            Inputs[3] = "foo.txt";
            Utilities utilities = new Utilities();
            var response = utilities.ValidateInputs(Inputs);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Success, false);
        }

        [TestMethod]
        public void CheckRangeValues_GreaterThan2()
        {
            Utilities utilities = new Utilities();
            var response = utilities.ValidateInputs(Inputs);
            Assert.IsNull(response);
        }

        [TestMethod]
        public void CheckRangeValues_LessThan2()
        {
            Inputs[2] = "1";
            Utilities utilities = new Utilities();
            var response = utilities.ValidateInputs(Inputs);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Success, false);
        }

        [TestMethod]
        public void LessThan4Parameters()
        {
            string[] input = { "1", "2" };
            Utilities utilities = new Utilities();
            var response = utilities.ValidateInputs(input);
            Assert.IsNull(response);
        }

    }
}
