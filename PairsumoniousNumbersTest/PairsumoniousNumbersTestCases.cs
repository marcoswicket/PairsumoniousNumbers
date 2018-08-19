using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairsumoniousNumbers;

namespace PairsumoniousNumbersTest
{
	[TestClass]
	public class PairsumoniousNumbersTestCases
	{
		[TestMethod]
		[DataRow("3 1269 1160 1663", "383 777 886\n")]
		[DataRow("3 1 1 1", "Impossible\n")]
		[DataRow("5 226 223 225 224 227 229 228 226 225 227", "111 112 113 114 115\n")]
		[DataRow("5 216 210 204 212 220 214 222 208 216 210", "101 103 107 109 113\n")]
		[DataRow("5 -1 0 -1 -2 1 0 -1 1 0 -1", "-1 -1 0 0 1\n")]
		public void TestCases(string input, string expectedResult)
		{
			string result = Program.EntrancePoint(input);
			Assert.AreEqual(result, expectedResult);
		}
	}
}
