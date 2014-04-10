/* Author: Maurice Huynh
 * 
 * Class: QuestionOne
 * Methods: CalculateTurns, CheckForErrors, PrintVarsToScreen, LeftA_To_EndB, 
 *          LeftA_To_EndC, LeftB_To_StartA, LeftC_To_StartA
 *          
 * QuestionOne class is the encapsulation of all members or member functions required to 
 * perform a calculation of minimum transformations. Included with this class I've defined
 * a set of helper functions to make things more clean and abstracted. The core of the 
 * operations is CalculateTurns method which will kick off the big bang of operations.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCDCodingExercise
{
    /// <summary>
    /// QuestionOne class encapsulates all the details involved with transposing and calculating the number
    /// of operations to convert a variable 'A' to an 'expected' string. 
    /// </summary>
    public class QuestionOne
    {
        /// <summary>
        /// CalculateTurns is going to kick off the show with a big bang!!!
        /// This method will require the 'actual' and 'expected' string for its signature.
        /// Are you actually reading these comments Ron? ^_^
        /// </summary>
        /// <returns>The minimum number of operations required to produce the expected string result</returns>
        public int CalculateTurns(String actual, String expected)
        {
            ///The Big Bang Theory
            ///Lets Cha Cha Cha!
            ///Per requirement these variables are tracked for the operations performed
            String A = actual;
            String B = "";
            String C = "";
            int nOperations = 0;

            PrintVarsToScreen(ref A, ref B, ref C);

            ///Check to see if anything needs to be done first
            ///Actual and Expected may already equal in string comparison
            if (actual.Equals(expected))
            {
                return nOperations;
            }

            #region Check Logic
            if (CheckForErrors(actual, expected) == -1)
                return -1;
            #endregion

            #region Operational Logic
            try
            {
                ///Check for common substring from tail between actual and expected
                ///We can eliminate some overhead operations if parts portion of the 'A' or 'actual' from the
                ///tail end matches up with 'expected' string thus saving us peforming extra move operations for 
                ///substrings that already match.
                int count = actual.Length - 1;
                foreach (char letter in actual)
                {
                    if (actual[count] == expected[count])
                        count--;
                    else
                        break;
                }
                int tailSubstringIndex = count;

                for (int i = 0; i <= tailSubstringIndex; i++)
                {
                    if (A.Substring(0, 1) == "1")
                    {
                        LeftA_To_EndB(ref A, ref B, ref C, ref nOperations);
                    }
                    else
                    {
                        LeftA_To_EndC(ref A, ref B, ref C, ref nOperations);
                    }
                }

                for (int i = 0; i <= tailSubstringIndex; i++)
                {
                    if (expected[i] == '1')
                    {
                        LeftB_To_StartA(ref A, ref B, ref C, ref nOperations);
                    }
                    else
                    {
                        LeftC_To_StartA(ref A, ref B, ref C, ref nOperations);
                    }
                }

            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine("Error: Couldn't calculate operation before stack overflowed - {0}", ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: Index out of Range, check array - {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            #endregion

            return nOperations;
        }

        /// <summary>
        /// CheckForErrors is a helper method to perform a series of checks we should do to 
        /// catch any issues before performing out operation routine logic
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        private int CheckForErrors(String actual, String expected)
        {
            ///Check to ensure characters don't exceed 50
            if (actual.Length > 50)
            {
                Console.WriteLine("Actual: '{0} length exceeds 50 characters", actual);
                return -1;
            }

            ///Check to ensure characters don't exceed 50
            if (expected.Length > 50)
            {
                Console.WriteLine("Expected: '{0}' length exceeds 50 characters", expected);
                return -1;
            }

            ///Check to make sure 'actual' and 'expected' are of same length
            if (actual.Length != expected.Length)
            {
                Console.WriteLine("Actual: '{0}' and Expected: '{1}' strings are not equal", actual, expected);
                return -1;
            }

            ///Check to make sure 'actual' string only contain '0' and '1'
            foreach (char letter in actual)
            {
                if (letter != '0' && letter != '1')
                {
                    Console.WriteLine("'actual': {0} contains more than just '0's and '1's", actual);
                    return -1;
                }
            }

            ///Check to make sure 'expected' string only contain '0' and '1'
            foreach (char letter in expected)
            {
                if (letter != '0' && letter != '1')
                {
                    Console.WriteLine("'expected': {0} contains more than just '0's and '1's", expected);
                    return -1;
                }
            }

            return 0;
        }

        /// <summary>
        /// PrintVarsToScreen is helper method that can be used anytime to print values to screen
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        private void PrintVarsToScreen(ref String A, ref String B, ref String C)
        {
            Console.WriteLine("A=\"{0}\" B=\"{1}\" C=\"{2}\"", A, B, C);
        }

        /// <summary>
        /// LeftA_To_EndB is a helper method to remove the left most character from A and
        /// append it to the end of B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="count"></param>
        private void LeftA_To_EndB(ref String A, ref String B, ref String C, ref int count)
        {
            Console.WriteLine("Transform 1 - Remove left most character from A and append to end of B");
            B = B + A.Substring(0, 1);
            A = A.Substring(1, A.Length - 1);
            count++;
            PrintVarsToScreen(ref A, ref B, ref C);
        }

        /// <summary>
        /// LeftA_To_EndC is a helper method to remove left most character from A and append it to C
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="count"></param>
        private void LeftA_To_EndC(ref String A, ref String B, ref String C, ref int count)
        {
            Console.WriteLine("Transform 2 - Remove left most character from A and append to end of C");
            C = C + A.Substring(0, 1);
            A = A.Substring(1, A.Length - 1);
            count++;
            PrintVarsToScreen(ref A, ref B, ref C);
        }

        /// <summary>
        /// LeftB_To_StartA is a helper method to remove the left most character from B and append
        /// it to start of A
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="count"></param>
        private void LeftB_To_StartA(ref String A, ref String B, ref String C, ref int count)
        {
            Console.WriteLine("Transform 3 - Remove left most character from B and append it to start of A");
            A = B.Substring(0, 1) + A;
            B = B.Substring(1, B.Length - 1);
            count++;
            PrintVarsToScreen(ref A, ref B, ref C);
        }

        /// <summary>
        /// LeftC_To_StartA is a helper method to remove the left most character from C
        /// and append it to the start of A
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="count"></param>
        private void LeftC_To_StartA(ref String A, ref String B, ref String C, ref int count)
        {
            Console.WriteLine("Transform 4 - Remove left most character from C and append it to the start of A");
            A = C.Substring(0, 1) + A;
            C = C.Substring(1, C.Length - 1);
            count++;
            PrintVarsToScreen(ref A, ref B, ref C);
        }
    }

}
