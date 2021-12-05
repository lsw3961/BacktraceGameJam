using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehavior : MonoBehaviour
{
    [SerializeField] PlayerInfo containerInfo;
    [SerializeField] string nameForGravity = "gravity";
    [SerializeField] string nameForBounce = "setActive";
    [SerializeField] string breakOnImpact = "ground";
    public void FixedUpdate()
    {
        ActiveCheck();
    }

    private void ActiveCheck()
    {
        for (int i = 0; i < containerInfo.names.Count; i++)
        {
             //Debug.Log("hit");
            if (containerInfo.names[i] == nameForGravity)
            {
                //Debug.Log("testing");
                if (int.TryParse( containerInfo.values[i], out int result) )
                {
                    GetComponent<Rigidbody2D>().gravityScale = result;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag.ToLower() == breakOnImpact.ToLower()) 
        {
            this.gameObject.SetActive(false);
        }
    }
}
