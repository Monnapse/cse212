public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // Check if already exists
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
            return true;

        if (value < Data)
        {
            // Search to the left
            if (Left is null)
                return false;
            return Left.Contains(value);
        }
        else
        {
            // Search to the right
            if (Right is null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Base case: if leaf node
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return the greater height plus one for the current node
        if (leftHeight > rightHeight)
            return leftHeight + 1;
        else if (rightHeight > leftHeight)
            return rightHeight + 1;
        else if (leftHeight == rightHeight)
            return leftHeight + 1;
        else
            return 1;
    }
}