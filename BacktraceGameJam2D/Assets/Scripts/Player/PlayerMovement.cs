using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedX;

    [SerializeField]
    private float speedY;

    [SerializeField]
    private float gravity;

    [SerializeField]
    Rigidbody2D rgb;

    private Vector3 xMove;
    private Vector3 leftMove;
    private Vector3 upMove;
    void Update()
    {
        Movement();
    }
    //Movement Method
    private void Movement() 
    {
        #region KeyBinds
        if (Input.GetAxis("Horizontal") != 0)
        {
            rgb.velocity = new Vector2(speedX * Input.GetAxis("Horizontal"), rgb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rgb.AddForce(new Vector2(0, speedY));
        }
        #endregion
    }
}
