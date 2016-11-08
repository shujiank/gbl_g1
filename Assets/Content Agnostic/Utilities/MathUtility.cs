using UnityEngine;
using System.Collections;

/// <summary>
/// This class handles evaluating player input as mathematical expressions.
/// It also supports generating and storing one "target" number that you may
/// want the player to hit. You may want to use some or all of this class.
/// Some parts you are unlikely to want, but are kept in as templates you
/// can modify to get your desired functionality. This class assumes that you
/// have char values for the player's input from the Tile system.
/// NOTE: Currently only supports the four basic operators, no parentheses,
/// no order of operations (left to right) and only does integer division!
/// </summary>
public static class MathUtility
{
    public static int target { get; private set; } // The number the player has to make their equation evaluate to.
    private static char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Char versions of 0 - 9.
    private const int MIN = 0; // The minimum possible target value.
    private const int MAX = 15; // The maximum possible target value.
    private const int ERROR = -999; // The value that represents an error during input parsing (ends on an operator, divide by 0, etc). It is up to your code to check for this value!

    // Picks a random target number.
    public static void generateTarget()
    {
        target = Random.Range(MIN, MAX + 1);
    }

    // Determines if player input equals our target number.
    public static bool validOperation(char[] input)
    {
        bool valid = false;
        // Check that we didn't get a blank.
        if (input[0] != 0)
        {
            int eval = evaluate(compactInput(input));
            if (eval == target)
            {
                valid = true;
            }
        }
        return valid;
    }

    // Converts the individual chars into strings we can evaluate.
    // Example: '1','3','+','7' becomes "13", "+", "7"
    private static ArrayList compactInput(char[] input)
    {
        int tempVal = ERROR;
        string tempStr = "0";
        ArrayList tempList = new ArrayList();
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '+':
                case '-':
                case 'x':
                case '/':
                    tempVal = int.Parse(tempStr);
                    tempList.Add(tempVal);
                    tempList.Add(input[i]);
                    tempVal = ERROR;
                    tempStr = "0";
                    break;
                default:
                    tempStr += input[i];
                    break;
            }
        }
        // Check that they didn't end on an operator
        if (int.TryParse(tempStr, out tempVal))
        {
            tempList.Add(tempVal);
        }
        return tempList;
    }

    // Evaluates the expression the player gave.
    private static int evaluate(ArrayList expression)
    {
        int eval = ERROR;
        // Every other item will be an operator, so if count is even, we ended on an operator, which is illegal.
        if (expression.Count % 2 == 1)
        {
            eval = (int)expression[0];
            int curNum;
            expression.RemoveAt(0);
            char curOp;
            while (expression.Count > 0)
            {
                curOp = (char)expression[0];
                expression.RemoveAt(0);
                curNum = (int)expression[0];
                expression.RemoveAt(0);
                switch (curOp)
                {
                    case '+':
                        eval += curNum;
                        break;
                    case '-':
                        eval -= curNum;
                        break;
                    case 'x':
                        eval *= curNum;
                        break;
                    case '/':
                        // Guard against divide by 0
                        if (curNum != 0)
                        {
                            eval /= curNum;
                        }
                        else
                        {
                            eval = ERROR;
                            expression.Clear();
                        }
                        break;
                }
            }
        }
        return eval;
    }

    /// <summary>
    /// Picks numbers and operators that will evaluate to target.
    /// This is here to help make sure players have moves avaliable.
    /// If you want to make changes to difficulty and/or this class, 
    /// you will probably want to make them here, or in the 
    /// supporter functions below.
    /// </summary>
    /// <returns>The new set of tiles for the player.</returns>
    public static char[] getAnswer()
    {
        char[] temp;

        // Pick a random operator to work on.
        int decider = Random.Range(0, 4);
        switch (decider)
        {
            case 0:
                temp = getAddition();
                break;
            case 1:
                temp = getSubtraction();
                break;
            case 2:
                temp = getMultiply();
                break;
            default:
                temp = getDivide();
                break;
        }

        return temp;
    }

    // Builds an addition answer.
    private static char[] getAddition()
    {
        char[] temp = new char[5];
        int index = 0;
        // This random number + X = target
        int randPlace = Random.Range(MIN, target + 1);
        // Is rand 1 or 2 digits?
        if (oneDigit(randPlace))
        {
            temp[index++] = nums[randPlace];
        }
        else
        {
            temp[index++] = nums[randPlace / 10];
            temp[index++] = nums[randPlace % 10];
        }
        temp[index++] = '+';
        // Determine X
        int add = target - randPlace;
        if (oneDigit(add))
        {
            temp[index++] = nums[add];
        }
        else
        {
            temp[index++] = nums[randPlace / 10];
            temp[index++] = nums[randPlace % 10];
        }
        // Fill any trailing blanks.
        while (index < temp.Length)
        {
            temp[index++] = randNum();
        }
        return temp;
    }

    // Builds a subtraction answer.
    private static char[] getSubtraction()
    {
        char[] temp = new char[5];
        int index = 0;
        // Get a random number >= target so we can subtract from it to target.
        int rand = Random.Range(target, MAX);
        // If rand is 2 digits, we need to break it down into two single digits.
        if (oneDigit(rand))
        {
            temp[index++] = nums[rand];
        }
        else
        {
            temp[index++] = nums[rand / 10];
            temp[index++] = nums[rand % 10];
        }
        temp[index++] = '-';
        // Same process for the difference.
        int diff = rand - target;
        if (oneDigit(diff))
        {
            temp[index++] = nums[diff];
        }
        else
        {
            temp[index++] = nums[rand / 10];
            temp[index++] = nums[rand % 10];
        }
        while (index < temp.Length)
        {
            temp[index++] = randNum();
        }
        return temp;
    }

    // Builds a multiplication answer.
    private static char[] getMultiply()
    {
        char[] temp = new char[5];

        // For now, we will make sure it is not prime so that we can easily make a multiply solution.
        while (isPrime(target))
        {
            generateTarget();
        }

        // Guard agaisnt divide by 0.
        int tempMin = MIN;
        if (tempMin == 0)
        {
            tempMin++;
        }
        int index = 0;
        // Get a random number we'll use as our factor.
        int randPlace = Random.Range(tempMin, nums.Length - 1);
        temp[index++] = nums[randPlace];
        temp[index++] = 'x';

        // Determine quotient and remainder so we can see if it's an even division or not.
        int div = target / randPlace;
        if (oneDigit(div))
        {
            temp[index] = nums[div];
        }
        else
        {
            temp[index++] = nums[div / 10];
            temp[index++] = nums[div % 10];
        }
        int mod = target % randPlace;
        // If not, we can just add mod.
        if (mod != 0)
        {
            temp[index++] = '+';
            temp[index++] = nums[mod];
        }
        // If it is, put two random numbers in the last two spots.
        while (index < temp.Length)
        {
            temp[index++] = randNum();
        }
        return temp;
    }

    // Builds a division answer.
    private static char[] getDivide()
    {
        char[] temp = new char[7];
        // Guard against 0, otherwise suggested answer will be 0/0.
        while (target < 1)
        {
            generateTarget();
        }
        int index = 0;
        // Get the random number we will multiply by to get our divisor.
        int rand = Random.Range(1, target + 1);
        if (oneDigit(rand))
        {
            temp[index++] = nums[rand];
        }
        else
        {
            temp[index++] = nums[rand / 10];
            temp[index++] = nums[rand % 10];
        }
        temp[index++] = '/';
        // Get our product, which we will add so that it can be divided by rand to make target.
        int prod = rand * target;
        if (oneDigit(prod))
        {
            temp[index++] = nums[prod];
        }
        else
        {
            temp[index++] = nums[prod % 10];
            int prod2 = prod / 10;
            // Prod may be three digits.
            if (oneDigit(prod2))
            {
                temp[index++] = nums[prod2];
            }
            else
            {
                temp[index++] = nums[prod2 / 10];
                temp[index++] = nums[prod2 % 10];
            }

        }
        while (index < temp.Length)
        {
            temp[index++] = randNum();
        }
        return temp;
    }

    // Utility to get a random number when filling out the rest of the array.
    private static char randNum()
    {
        return nums[Random.Range(0, nums.Length)];
    }

    // Utility to determine if a number has more than 1 digit.
    private static bool oneDigit(int num)
    {
        return ((num / 10) == 0);
    }

    // Determines if target is prime. Based off of: http://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
    public static bool isPrime(int number)
    {
        bool prime = true;
        int boundary = (int)System.Math.Floor(System.Math.Sqrt(number));

        if (number == 1)
        {
            prime = false;
        }

        for (int i = 2; i <= boundary; ++i)
        {
            if (number % i == 0)
            {
                prime = false;
            }
        }

        return prime;
    }



}