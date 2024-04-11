using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidScreenButton : MonoBehaviour
{
    public PlayerController pc;
    public Direction direction;

    public void OnPress()
    {
        //Debug.Log("MoveButton");
        if (direction == Direction.Right)
        {
            pc.movingRight = true;
            //Debug.Log("MoveRight");
        }
        else if (direction == Direction.Left)
        {
            pc.movingLeft = true;
            //Debug.Log("MoveLeft");
        }
    }
    public void OnRelease()
    {
        //Debug.Log("MoveButton");
        if (direction == Direction.Right)
        {
            pc.movingRight = false;
            //Debug.Log("MoveRight");
        }
        else if (direction == Direction.Left)
        {
            pc.movingLeft = false;
            //Debug.Log("MoveLeft");
        }
    }
}
public enum Direction
{
    Left,
    Right,
}
