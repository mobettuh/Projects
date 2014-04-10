/* Author: Maurice Huynh
 * 
 * Language: C#
 * Class Name: QuestionOne
 * Method Name: CalculateTurns
 * Method Signature: + Int32 (String actual, String expected)
 * Description
 * You are given 3 variables A, B, and C where A is initialized with the ‘actual’ value and B and C are empty. You must determine the smallest number of transformations required to transform A into ‘expected’. In order to do this you can only perform the following transformations:
 * 1.	Remove the left-most character from A and append It to the end of B
 * 2.	Remove the left-most character from A and append it to the end of C
 * 3.	Remove the left-most character from B and append it to the start of A
 * 4.	Remove the left-most character from C and append it to the start of A
 * The ‘actual’ and ‘expected’ strings can only contain the values ‘0’ and ‘1’ for example the “010101”.
 * The ‘actual’ and ‘expected’ strings will be the same size.
 * The largest ‘expected’ string can only be a maximum 50 characters long.
 * 
 * Sample Output:
 * 
 * A = “10101”   B = “”   C = “”
 * Transform 1 – Remove left most character from A and append it to end of B
 * A = “0101”   B = “1”   C = “”
 * Transform 1 - Remove left most character from A and append it to end of B
 * A = “101”   B = “10”   C = “”
 * Transform 2 – Remove left most character from A and append it to end of C
 * A = “01”   B = “10”   C = “1”
 * Transform 1 – Remove left most character from A and append it to end of B
 * A = “1”   B = “100”   C = “1”
 * Transform 3 – Remove left most character from B and append it to start of A
 * A = “11”   B = “00”   C = “1”
 * Transform 3 – Remove left most character from B and append it to start of A
 * A = “011”   B = “0”   C = “1”
 * Transform 3 – Remove left most character from B and append it to start of A
 * A = “0011”   B = “”   C = “1”
 * Transform 4 – Remove left most character from C and append it to start of A
 * A = “10011”   B = “”   C = “”
 * 
 * A is now equal to ‘expected’ and it took 8 transformations
 * 
 * Expected Output: Will exactly reflect the format 'Sample Output'.
 * 
 * Note: For comprehensibility, abstraction and cleanliness I've abstracted this project into 3 portions. 
 * You have the QuestionOne class which is contained in a file in and of itself.
 * 
 * Unit tests are already built into the solution and can be identified by the OperationTests project
 * and all you need to do for unit testing is to bring up the test explorer and click 'Run All' test.
 * 
 * Finally, we have the main or entry point that will kick off the program with test input
 * and run the CalculateTurns method.
 * 
 * Live long and prosper!!!
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCDCodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            ///In actually using immutable string are better off as you don't expect to modify them
            string actual = "10101";
            string expected = "10011";
            QuestionOne Q = new QuestionOne();

            int nOperations = Q.CalculateTurns(actual, expected);

            if (nOperations != -1)
                Console.WriteLine("A is now equal to 'expected' and it took {0} transformations.", nOperations);
            else
                Console.WriteLine("Unable to computer the number operations because of invalid inputs. Verify actual and expected values are valid per spec.");

            Console.WriteLine("Press <enter> to exit program.");
            Console.ReadLine();
        }
    }
}
