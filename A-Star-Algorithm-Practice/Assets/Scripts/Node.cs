using UnityEngine;

//Node class is used to create a grid that checks if the player can walk on that
//grid or not and stores the world position of that grid.
public class Node
{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;
    public int gCost;
    public int hCost;
    public Node parent;

    //Constructor for the Node class that takes in a boolean value for walkable and a Vector3 for world position.
    public Node(bool _walkable, Vector3 _worldPosition , int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPosition;
        gridX = _gridX;
        gridY = _gridY;
    }
    
    public int fCost
    {
        get { return gCost + hCost; }
    }
}
