using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedX;

    [SerializeField]
    private float speedY;

   // [SerializeField]
   // private float gravity;

    private Vector3 rightMove;
    private Vector3 leftMove;
    private Vector3 upMove;
    void Update()
    {
        Movement();
    }
    //Movement Method
    private void Movement() 
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rightMove = new Vector3(speedX, 0, 0);
        }
        else
        {
            rightMove = new Vector3(0, 0, 0);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            leftMove = new Vector3(speedX * (-1), 0, 0);
        }
        else
        {
            leftMove = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            upMove = new Vector3(0, speedY , 0);
        }
        else
        {
            upMove = new Vector3(0, 0, 0);
        }

        Vector3 movement = new Vector3(rightMove.x + leftMove.x, upMove.y, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);

        //Debug.Log("Right: " + rightMove.x);
        //Debug.Log("Left: " + leftMove.x);
    }
}
