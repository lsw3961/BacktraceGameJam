using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFloor : MonoBehaviour
{
    [SerializeField] PlayerInfo floorInfo;
    string nameForActive = "setActive";
    public void FixedUpdate()
    {
        ActiveCheck();
    }

    private void ActiveCheck() 
    {
        for (int i = 0; i < floorInfo.names.Count; i++)
        {
           // Debug.Log("hit");
            if (floorInfo.names[i] == nameForActive)
            {

                if (floorInfo.values[i] == "FALSE")
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
