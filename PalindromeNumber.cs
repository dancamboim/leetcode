// Given an integer x, return true if x is a palindrome, and false otherwise.

// Example 1:
// Input: x = 121
// Output: true
// Explanation: 121 reads as 121 from left to right and from right to left.
// Example 2:

// Input: x = -121
// Output: false
// Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
// Example 3:

// Input: x = 10
// Output: false
// Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

// Follow up: Could you solve it without converting the integer to a string?
namespace LeetcodeExercices
{
    public class IsPalindromeComparingReverseArray
    {
        public bool ComparingReverseArray(int x)
        {
            //Runtime: 6 ms - beats 22.32%
            //memory: 38.85mb ms - beats 17.72%

            var numberString = x.ToString().ToCharArray();
            var numberStringReverse = (char[])numberString.Clone();

            Array.Reverse(numberStringReverse);

            return numberString.SequenceEqual(numberStringReverse);
        }

        //Runtime 8ms Beats 17.13% =(
        //Memory 37.34mb Beats 27.38% =(
        public bool NoConvertingToCharArray(int x)
        {
            //A negative number will never be a palindrome!
            if (x < 0) return false;


            //Log10(x) is undefined for negative numbers!
            // Math.Log10(12345) ≈ 4.09 → floor = 4 → +1 → 5 digits
            // If number == 0, this formula breaks
            if (x == 0) return true;
            int xLength = (int)Math.Floor(Math.Log10(x)) + 1;

            int[] xArray = new int[xLength];
            var xAux = x;

            for (var i = xLength - 1; i >= 0; i--)
            { //will iterate starting from the end, that's why i--
                xArray[i] = xAux % 10; // % 10 → gets the last digit (like 5 from 12345)
                xAux /= 10; //removes the last digit (12345 → 1234 → ...)
            }

            xAux = x;
            int[] xReversed = new int[xLength];
            for (var i = 0; i < xLength; i++) //will iterate starting from the initial position in the array, that's why i++
            {
                xReversed[i] = xAux % 10;
                xAux /= 10;
            }

            return xArray.SequenceEqual(xReversed);
        }

        //Runtime 3ms - Beats 36.78%
        //Memory 35.66Mb Beats 56.18%
        public bool NoConvertingToCharArrayUsingOneArrayOnly(int x)
        {

            //A negative number will never be a palindrome!
            if (x < 0) return false;

            //Log10(x) is undefined for negative numbers!
            // Math.Log10(12345) ≈ 4.09 → floor = 4 → +1 → 5 digits
            // If number == 0, this formula breaks
            if (x == 0) return true;
            int xLength = (int)Math.Floor(Math.Log10(x)) + 1;

            int[] xArray = new int[xLength];

            //will iterate starting from the end, that's why i--
            for (var i = xLength - 1; i >= 0; i--)
            {
                xArray[i] = x % 10; // % 10 → gets the last digit (like 5 from 12345)
                x /= 10; //removes the last digit (12345 → 1234 → ...)
            }

            //Will iterate i < xLength / 2 because it has only to compare to the other half of the array
            for (var i = 0; i < xLength / 2; i++)
            {
                if (xArray[i] != xArray[xLength - 1 - i]) return false;
            }
            return true;

        }
    }
}