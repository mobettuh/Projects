/* Author: Maurice Huynh
 * 
 * Class: UnitTest
 *          
 * UnitTest is responsible for automated unit tests that you can add to and run to
 * check the integrity of our application.
 * 
 * Run all or individual tests through the test explorer.
 * 
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FCDCodingExercise;

namespace OperationTests
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Test that the logic produces some expected number of operations based on known outputs
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            String actual = "10101";
            String expected = "10011";
            QuestionOne q1 = new QuestionOne();

            int nTurns = q1.CalculateTurns(actual, expected);

            if (nTurns >= 0)
            {
                Console.WriteLine("A is now equal to 'expected' and it took {0} transformations.", nTurns);
            }
            // assert
            Assert.AreEqual(nTurns, 8, "Unit test for minimum operations passed.");
        }

        /// <summary>
        /// Test that the logic will invalidate if actual and expected are the same string size
        /// per requirement
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            String actual = "10101";
            String expected = "1001100000000000";
            QuestionOne q1 = new QuestionOne();

            int nTurns = q1.CalculateTurns(actual, expected);

            // assert
            Assert.AreEqual(nTurns, -1, "Unit test for checking that actual and expected inputs are same size. Passed.");
        }

        /// <summary>
        /// Test that 'expected' can not exceed over 50 characters
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            String actual = "10101";
            String expected = "100110000010011000001001100000100110000010011000001001100000"; //longer than 50 chars
            QuestionOne q1 = new QuestionOne();

            int nTurns = q1.CalculateTurns(actual, expected);

            // assert
            Assert.AreEqual(nTurns, -1, "Unit test for checking that 'expected' input don't exceed 50 characters. Passed.");
        }

        /// <summary>
        /// Test that 'actual' can not exceed over 50 characters
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            String actual = "101010000010101000001010100000101010000010101000001010100000"; //longer than 50 chars
            String expected = "10011"; 
            QuestionOne q1 = new QuestionOne();

            int nTurns = q1.CalculateTurns(actual, expected);

            // assert
            Assert.AreEqual(nTurns, -1, "Unit test for checking that 'actual' input don't exceed 50 characters. Passed.");
        }

        /// <summary>
        /// Test that 'actual' contains only 1s and 0s
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            String actual = "abcdef"; //longer than 50 chars
            String expected = "10011";
            QuestionOne q1 = new QuestionOne();

            int nTurns = q1.CalculateTurns(actual, expected);

            // assert
            Assert.AreEqual(nTurns, -1, "Unit test for checking that 'actual' contains only 0s and 1s. Passed.");
        }

        /// <summary>
        /// Test that 'expected' contains only 1s and 0s
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            String actual = "10011"; //longer than 50 chars
            String expected = "abcdef";
            QuestionOne q1 = new QuestionOne();

            int nTurns = q1.CalculateTurns(actual, expected);

            // assert
            Assert.AreEqual(nTurns, -1, "Unit test for checking that 'expected' contains only 0s and 1s. Passed.");
        }

    }
}
