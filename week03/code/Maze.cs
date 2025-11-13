/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // Makes things easier by combining common code
    public void Move(int x = 0, int y = 0)
    {
        int directionIndex;

        if (x == -1 && y == 0) directionIndex = 0; // left
        else if (x == 1 && y == 0) directionIndex = 1; // right
        else if (x == 0 && y == 1) directionIndex = 2; // up
        else if (x == 0 && y == -1) directionIndex = 3; // down
        else throw new ArgumentException("Invalid move direction.");

        var currentKey = (_currX, _currY);

        // Get current cell
        if (!_mazeMap.ContainsKey(currentKey))
            throw new InvalidOperationException("Can't go that way!");

        // Check if this direction is allowed
        if (!_mazeMap[currentKey][directionIndex])
            throw new InvalidOperationException("Can't go that way!");

        // Move
        _currX += x;
        _currY += y;

        Console.WriteLine(GetStatus());
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        Move(-1, 0);
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        Move(1, 0);
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        Move(0, 1);
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        Move(0, -1);
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}