using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        if (n <= 0) // Check for base case
            return 0;

        return n * n + SumSquaresRecursive(n - 1); // Recursive case: sum of squares up to n
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        if (word.Length == size) // Base case: if the current word has reached the desired size
        {
            results.Add(word);
            return;
        }
        for (int i = 0; i < letters.Length; i++) // Recursive case: build permutations
        {
            char currentChar = letters[i];
            string remainingChars = letters.Remove(i, 1); // Remove the used character
            PermutationsChoose(results, remainingChars, size, word + currentChar); // Recurse with the remaining characters
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Initialize memoization dictionary on first call
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }
        else if (remember.ContainsKey(s))
        {
            return remember[s]; // Return cached result if it exists
        }

        // TODO Start Problem 3

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways; // Store result in memoization dictionary
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        int wildcardIndex = pattern.IndexOf('*');
        if (wildcardIndex == -1) // Base case: no wildcards left
        {
            results.Add(pattern);
            return;
        }
        string withZero = pattern.Substring(0, wildcardIndex) + "0" + pattern.Substring(wildcardIndex + 1);
        string withOne = pattern.Substring(0, wildcardIndex) + "1" + pattern.Substring(wildcardIndex + 1);
        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
        
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    /// 
    /*
    public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// A maze is defined as a list of lists.  The outer list
    /// contains a representation of each row in the maze.  You can
    /// assume that the maze will be square (same number of rows
    /// and columns). The inner lists show what is in the maze:
    /// 
    /// 0 = Wall (You can't go through this)
    /// 1 = Open Path (You can go through this)
    /// 2 = End (You want to get to this point to win)
    /// 
    /// See the Prove instructions for graphical representations of
    /// the 2 test mazes defined below.
    /// 
    /// The 'IsEnd' and the 'IsValidMove' functions are
    /// already written for you.  These functions assume that the first
    /// square in the maze is (0,0).  These functions also assume
    /// that you can't leave the boundaries of the maze and that you 
    /// can't visit the same square in the same path (no circles).
    /// 
    /// The 'currPath' variable is a list of (x,y) tuples that 
    /// represent the path we are currently on.  If you add a new position
    /// to the path, make sure that you add the tuple to the list so that the
    /// 'IsValidMove' function works properly.
    /// 
    /// The goal is to implement the 'SolveMaze' function to return
    /// all paths to the end square using recursion.  When you find a path, 
    /// then adding it to the return value list will be as simple as 'results.Add(currPath.AsString())'.
    /// </summary>
    /// <summary>
    /// Helper function to determine if the (x,y) position is at 
    /// the end of the maze.
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }


    /// <summary>
    /// Helper function to determine if the (x,y) position is a valid
    /// place to move given the size of the maze, the content of the maze,
    /// and the current path already traversed.
    /// </summary>
    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        // Can't go outside of the maze boundary (assume maze is a square)
        if (x > Width - 1 || x < 0)
            return false;
        if (y > Height - 1 || y < 0)
            return false;
        // Can't go through a wall
        if (Data[y * Height + x] == 0)
            return false;
        // Can't go if we have already been there (don't go in circles)
        if (currPath.Contains((x, y)))
            return false;
        // Otherwise, we are good
        return true;
    }
}
    */
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE

        // Check if the current position is the end
        if (maze.IsEnd(x, y))
        {
            currPath.Add((x, y)); // Add the end position to the path
            results.Add(currPath.AsString()); // Add the current path to results
            currPath.RemoveAt(currPath.Count - 1); // Backtrack
            return;
        }

        // Possible moves: right, down, left, up
        var directions = new List<(int, int)> { (1, 0), (0, 1), (-1, 0), (0, -1) };
        currPath.Add((x, y)); // Add current position to path
        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath); // Recurse to new position
            }
        }
        currPath.RemoveAt(currPath.Count - 1); // Backtrack
        
        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}