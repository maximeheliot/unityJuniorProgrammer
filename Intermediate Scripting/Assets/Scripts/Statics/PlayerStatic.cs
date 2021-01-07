using UnityEngine;

public class PlayerStatic : MonoBehaviour 
{
    //Static variables are shared across all instances
    //of a class. 
    public static int playerCount = 0;

    void Start()
    {
        //Increment the static variable to know how many
        //objects of this class have been created.
        playerCount++;
    }
}

