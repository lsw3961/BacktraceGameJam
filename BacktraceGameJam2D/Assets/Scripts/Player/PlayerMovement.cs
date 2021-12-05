using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Global Variables
    [SerializeField]
    private float speedX;

    [SerializeField]
    private float speedY;

    [SerializeField]
    private float cosmeticDownForceValue;

    [SerializeField]
    Rigidbody2D rgb;

    [SerializeField] PlayerInfo playerInfo;
    [SerializeField] List<string> namesOfVariables;
    private bool inAir;

    #endregion

    #region Start/Update
    private void Start()
    {
        inAir = true;
    }
    void Update()
    {
        ModGravity();
        Movement();
        
    }

    #endregion

    #region Movement
    //Movement Method
    private void Movement()
    {
        #region L/R Movement

        //Left + Right Movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            rgb.velocity = new Vector2(speedX * Input.GetAxis("Horizontal"), rgb.velocity.y);
        }
        #endregion

        #region Jump Mechanics
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            rgb.AddForce(new Vector2(0, speedY * 100));
        }

        //Apply Cosmetic Downward Force
        if (rgb.velocity.y <= 1)
        {
            rgb.AddForce(new Vector2(0, (speedY / cosmeticDownForceValue) * (-1)));
        }
        #endregion
    }

    #endregion

    #region Collisions
    /// <summary>
    /// Triggers when Player hits object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
    }

    /// <summary>
    /// Triggers when Player exits Collision event
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        inAir = true;
    }

    #endregion

    #region ModValues   
    private void ModGravity()
    {
        int nameCounter = 0;
        for (int i = 0; i < playerInfo.values.Count; i++)
        {
            if (int.TryParse(playerInfo.values[i],out int result))
            {
                //mod gravity
                if (playerInfo.names[nameCounter] == namesOfVariables[1])
                {
                    rgb.mass = int.Parse(playerInfo.values[i]);
                    i++;
                }
                //mod speed
                if (playerInfo.names[nameCounter] == namesOfVariables[2])
                {
                    //Debug.Log("hit");
                    speedX = int.Parse(playerInfo.values[i]);
                    i++;
                }
            }
            nameCounter++;
        }
    }
    private void ModScale(){}
    private void ModSpeed(){}
    private void ModName(){}

    #endregion
}
