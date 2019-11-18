using System;

/// <summary>
/// Represents game difficulties 
/// </summary>
public class Difficulty
{
    public int MIN_SPEED;
    public int MAX_SPEED;
    public int SPEED;
    public int TIME;
    public int MULTIPLIER;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="difficulty"></param> Easy, medium or hard.
    public Difficulty(String difficulty)
    {
        if (difficulty.Equals("easy"))
        {
            MIN_SPEED = 2;
            MAX_SPEED = 4;
            SPEED = 1;
            TIME = 100;
            MULTIPLIER = 1;
        }
        else if (difficulty.Equals("medium"))
        {
            MIN_SPEED = 4;
            MAX_SPEED = 6;
            SPEED = 2;
            TIME = 80;
            MULTIPLIER = 2;
        }
        else if (difficulty.Equals("hard"))
        {
            MIN_SPEED = 4;
            MAX_SPEED = 6;
            SPEED = 2;
            TIME = 60;
            MULTIPLIER = 3;

        }
    }
}
