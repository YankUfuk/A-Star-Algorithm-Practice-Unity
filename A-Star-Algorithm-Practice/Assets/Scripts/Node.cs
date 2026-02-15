using UnityEngine;

//Node class is used to create a grid that checks if the player can walk on that
//grid or not and stores the world position of that grid.
public class Node
{
    public bool walkable;
    public Vector3 worldPosition;

    //Constructor for the Node class that takes in a boolean value for walkable and a Vector3 for world position.
    public Node(bool _walkable, Vector3 _worldPosition)
    {
        walkable = _walkable;
        worldPosition = _worldPosition;
    }
}
