using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Level1Dialogue
{

    public static string[] BACKTRACKING_WARNING =
    {
        "Backtracking Warning", "Since you made some backtracking moves, I am sending you some intel our research team acquired. Hope it helps!"
    };
    public static string[] GREETINGS =
    {
        "Greetings", "Command you spacecraft and efficiently utilize the remaining fuel to reach the destination planet."
    };

    public static string[] OBJECTIVE =
    {
        "Objective", "Command you spacecraft and efficiently utilize the remaining fuel to reach the destination planet."
    };

    public static string[] PDA =
    {
        "PDA", "Personal Data Assistant provides you with information regarding your current location in the multiverse, the location of the destination planet, the directions in which your can maneuver represented by vectors, the number of times you made a maneuver in each direction and the fuel remaining."
    };

    public static string[] VECTOR_INFORMATION =
    {
        "Vector Information", "In mathematics, physics, and engineering, a Euclidean vector is a geometric object that has magnitude (or length) and direction. Vectors can be added to other vectors according to vector algebra."
    };

    public static string[] VECTOR_NOTATION =
    {
        "Vector Notation", "In vertical representation of vectors, the top element represents the x component and the other represents the y component. For the sake of establishment of relationship, the PDA represents (x, y) co-ordinates using the same notation."
    };

    public static string[] MOVEMENT =
    {
        "Movement", "Maneuvering your spacecraft requires you to input a scalar multiple for the vector in the input box at the tip of the arrow representing the vector and then clicking the 'Go!' button."
    };

    public static string[] FUEL =
    {
        "Fuel", "Each move consumes a specific fraction of the fuel. You have enough fuel to make at most 3 wrong moves."
    };

    public static string[] BACKTRACKING =
    {
        "Backtracking", "You can multiply the vector with negative scalars to negate a previous move. Negative scalar multiplication is not required to reach the destination. It is a provision for you to correct a wrong decision and will be regaded as a indicator of confusion which will subsequently unlock a hint in the journal. Since you have only 3 extra moves to reach destination, you can earn upto 4 hints which successively build up to the final solution."
    };

    public static string[] HINT1 =
    {
        "Hint 1", "A linear equation is an algebraic equation in which each term is either a constant or the product of a constant and (the first power of) a single variable. A simple example of a linear equation with only one variable, x, may be written in the form: ax + b = 0, where a and b are constants and a ≠ 0"
    };

    public static string[] HINT2 =
    {
        "Hint 2", "A linear system of two equations with two variables is any system that can be written in the form: \n\tax + by = c\n\tcx + dy = e\n..where any of the constants can be zero with the exception that each equation must have at least one variable in it. Also, the system is called linear if the variables are only to the first power, are only in the numerator and there are no products of variables in any of the equations."
    };

    public static string[] HINT3 =
    {
        "Hint 3", "One of the ways to solve such a system of linear equations with two variables is the method of elimination.  In this method we multiply one or both of the equations by appropriate numbers (i.e. multiply every term in the equation by the number) so that one of the variables will have the same coefficient with opposite signs.  Then next step is to add the two equations together.  Because one of the variables had the same coefficient with opposite signs it will be eliminated when we add the two equations.  The result will be a single equation that we can solve for one of the variables.  Once this is done substitute this answer back into one of the original equations."
    };

    public static string[] HINT4 =
    {
        "Solution", "Suppose destination co-ordinates are (c, d), vector_1 = (x, y) and vector_2 = (u, v). Let the number of times we travel in the direction of vector_1 be 'a' and 'b' for vector_2.\nThis gives us 2 linear equations. The sum of x component of both vectors should be equal to x co-ordinate of the destination since we start at (0, 0). Same goes for the y components. This gives us the equation: -\n\tax + bu = c\n\tay + bv = d"
    };

}
